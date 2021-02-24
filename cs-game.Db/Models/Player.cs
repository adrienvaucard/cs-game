using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs_game.Db.Models
{
    public class Player : BaseDataObject
    {
        public string Name { get; set; }
        public int Hp { get; set; }
        public int Xp { get; set; }
        public int MaxHp { get; set; }
        public int Attack { get; set; }
        public int Defense { get; set; }
        public int Latitude { get; set; }
        public int Longitude { get; set; }

        public List<Weapon> Weapons { get; set; }
        public List<Item> Items { get; set; }

        public Player(string name, int latitude, int longitude, int hp = 20, int attack = 2, int defense = 2)
        {
            this.Name = name;
            this.Latitude = latitude;
            this.Longitude = longitude;
            this.Hp = hp;
            this.Attack = attack;
            this.Defense = defense;

            this.MaxHp = 20;
        }

        public Monster Hit(Weapon weapon, Monster monster)
        {
            var factory = new DbContextFactory();
            var context = factory.CreateDbContext(null);

            Random rnd = new Random();
            int damages = this.Attack + weapon.Attack;
            int chance = rnd.Next(0, 10);

            Monster hitMonster = context.Monsters.First(m => m.Id == monster.Id);

            if (((float) chance/10) < weapon.HitRate)
            {
                if (!(hitMonster.Defense >= damages))
                {
                    hitMonster.Hp -= damages - hitMonster.Defense;
                }
                
                Console.WriteLine("Vous attaquez le {0} et il perd {1} points de vie", monster.Name, damages <= hitMonster.Defense ? 0 : damages - hitMonster.Defense);
                context.SaveChanges();
            } else
            {
                Console.WriteLine("Vous glissez et loupez votre coup");
            }

            return monster;
        }

        public bool Run()
        {
            var factory = new DbContextFactory();
            var context = factory.CreateDbContext(null);
            Random rnd = new Random();
            int runChance = rnd.Next(0, 10);

            Player toUpdatePlayer = context.Players.First(player => player.Id == this.Id);

            Console.Clear();
            if (runChance < 5)
            {
                if (!(toUpdatePlayer.Longitude - 1 < 0))
                {
                    toUpdatePlayer.Longitude -= 1;
                } else if (!(toUpdatePlayer.Longitude + 1 > 9))
                {
                    toUpdatePlayer.Longitude += 1;
                } else if (!(toUpdatePlayer.Latitude - 1 < 0))
                {
                    toUpdatePlayer.Latitude -= 1;
                } else if (!(toUpdatePlayer.Latitude + 1 > 9))
                {
                    toUpdatePlayer.Latitude += 1;
                }
                context.SaveChanges();
                Console.WriteLine("Vous réussissez à vous enfuir");
                Console.ReadLine();
                return true;
            } else
            {
                Console.WriteLine("Vous trébuchez et loupez votre fuite");
                Console.ReadLine();
                return false;
            }
        }

        public void UseItem(Item item)
        {
            var factory = new DbContextFactory();
            var context = factory.CreateDbContext(null);

            Player player = context.Players.First(p => p.Id == item.PlayerId);

            Console.Clear();
            Console.WriteLine("Vous utilisez 1x {0}", item.Name);
            if (item.AttackBoost > 0)
            {
                player.Attack += item.AttackBoost;
                Console.WriteLine("Il vous donne {0} points d'attaque en plus", item.AttackBoost);
            }
            if (item.DefenseBoost > 0)
            {
                player.Defense += item.DefenseBoost;
                Console.WriteLine("Il vous donne {0} points de défense en plus", item.DefenseBoost);
            }
            if (item.HpBoost > 0)
            {
                player.Hp += item.HpBoost;
                Console.WriteLine("Il vous donne {0} points de vie en plus", item.HpBoost);
            }

            context.Items.Remove(item);
            context.SaveChanges();
            

        }

        public Player GainXp()
        {
            Random rnd = new Random();
            var factory = new DbContextFactory();
            var context = factory.CreateDbContext(null);

            Player player = context.Players.First(p => p.Id == this.Id);

            int gainedXp = rnd.Next(10, 21);
            player.Xp += gainedXp;
            context.SaveChanges();
            Console.WriteLine("Vous gagnez {0} XP", gainedXp);
            return player;
        }

        public bool DropItem()
        {
            Random rnd = new Random();
            var factory = new DbContextFactory();
            var context = factory.CreateDbContext(null);

            Player player = context.Players.First(p => p.Id == this.Id);
            List<Item> items = new List<Item>();

            int droppedItem = rnd.Next(0, 10);
            if (droppedItem >= 0 && droppedItem < 2)
            {
                items.Add(new Item("Flacon de Mercurochrome", 10));
                Console.WriteLine("Vous récupérez un Flacon de Mercurochrome");
                player.Items = items;
                context.SaveChanges();
                return true;
            } else if (droppedItem >= 2 && droppedItem < 4)
            {
                items.Add(new Item("Canette de Monster", 0, 2));
                Console.WriteLine("Vous récupérez une canette de Monster");
                player.Items = items;
                context.SaveChanges();
                return true;
            } else if (droppedItem >= 4 && droppedItem < 6)
            {
                items.Add(new Item("Rouleau de Flex tape", 0, 0 ,2));
                Console.WriteLine("Vous récupérez un rouleau de Flex Tape");
                player.Items = items;
                context.SaveChanges();
                return true;
            } else
            {
                return false;
            }
        }

        public void DropWeapon()
        {
            Random rnd = new Random();
            var factory = new DbContextFactory();
            var context = factory.CreateDbContext(null);

            Player player = context.Players.First(p => p.Id == this.Id);
            List<Weapon> weapons = new List<Weapon>();

            int droppedItem = rnd.Next(0, 10);
            if (droppedItem >= 0 && droppedItem < 2)
            {
                weapons.Add(new Weapon("Nerf de Boeuf", 0.60F, 5));
                Console.WriteLine("Vous récupérez un nerf de boeuf");
            }
            else if (droppedItem >= 2 && droppedItem < 4)
            {
                weapons.Add(new Weapon("Carabine à plomb mal réglée", 0.40F, 10));
                Console.WriteLine("Vous récupérez une carabine à plomb mal réglée");
            }
            else if (droppedItem >= 4 && droppedItem < 6)
            {
                weapons.Add(new Weapon("Parpaing bien lourd", 0.80F, 7));
                Console.WriteLine("Vous récupérez un parpaing bien lourd");
            }

            player.Weapons = weapons;
            context.SaveChanges();
        }

        public void ListInventory()
        {
            var factory = new DbContextFactory();
            var context = factory.CreateDbContext(null);

            Console.Clear();
            try
            {
                Weapons = context.Weapons.Where(weapon => weapon.PlayerId == this.Id).ToList();
            } catch
            {
                Weapons = null;
            }

            try
            {
                Items = context.Items.Where(item => item.PlayerId == this.Id).ToList();
            }
            catch
            {
                Items = null;
            }

            // Weapons
            if (Weapons == null || Weapons.Count <= 0)
            {
                Console.WriteLine("Vous n'avez aucune arme");
            }
            else
            {
                Console.WriteLine("Armes :");

                foreach (var weapon in Weapons)
                {
                    Console.WriteLine("- {0}", weapon.Name);
                }
            }

            Console.WriteLine("");

            // Items
            if (Items == null || Items.Count <= 0)
            {
                Console.WriteLine("Vous n'avez aucun objet");
            }
            else
            {
                Console.WriteLine("Objets :");

                foreach (var item in Items)
                {
                    Console.WriteLine("- {0}", item.Name);
                }
            }
            Console.ReadLine();
        }

        public List<Weapon> GetWeapons()
        {
            var factory = new DbContextFactory();
            var context = factory.CreateDbContext(null);

            Weapons = context.Weapons.Where(w => w.PlayerId == this.Id).ToList();

            return Weapons;
        }

        public List<Item> GetItems()
        {
            var factory = new DbContextFactory();
            var context = factory.CreateDbContext(null);

            Items = context.Items.Where(i => i.PlayerId == this.Id).ToList();

            return Items;
        }

        public void ListStats()
        {
            var factory = new DbContextFactory();
            var context = factory.CreateDbContext(null);

            Player player = context.Players.First(p => p.Id == this.Id);
            Console.Clear();
            Console.WriteLine("Statistiques");
            Console.WriteLine("HP - {0}", player.Hp);
            Console.WriteLine("Niveau - {0}", (int) player.Xp / 10);
            Console.WriteLine("Attack - {0}", player.Attack);
            Console.WriteLine("Defense - {0}", player.Defense);

            Console.ReadLine();
        }

    }
}

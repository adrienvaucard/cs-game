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

            if ((chance/10) < weapon.HitRate)
            {
                hitMonster.Hp -= damages;
                Console.WriteLine("Vous attaquez le {0} et il perd {1} points de vie", monster.Name, damages);
                context.SaveChanges();
            } else
            {
                Console.WriteLine("Vous glissez et loupez votre coup");
            }

            return monster;
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

    }
}

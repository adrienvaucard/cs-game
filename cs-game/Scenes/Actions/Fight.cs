using cs_game.Db;
using cs_game.Db.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace cs_game.Scenes.Actions
{
    class Fight
    {
        public Player Player;
        public Monster Monster;
        public bool isInputValid;
        public int selectorChoice;

        public Fight(Player player, Monster monster, bool isPlayerTurn)
        {
            var factory = new DbContextFactory();
            var context = factory.CreateDbContext(null);

            this.Player = player;
            this.Monster = monster;

            if (Monster.Hp > 0)
            {
                do
                {
                    if (isInputValid)
                    {
                        Console.WriteLine("Erreur : Veuillez rentrer une valeur correcte.");
                        Thread.Sleep(2000);
                    }

                    Console.Clear();

                    if (isPlayerTurn)
                    {
                        Console.WriteLine("Vous êtes en  X : {0} - Y : {1}", Player.Latitude, Player.Longitude);
                        Console.WriteLine("Un {0} vous bloque la route", Monster.Name);
                        Console.WriteLine("{0} points de vie restants", Monster.Hp);
                        Console.WriteLine("Que voulez-vous faire ?");
                        Console.WriteLine("");
                        Console.WriteLine("1 - Attaquer");
                        Console.WriteLine("2 - Afficher l'inventaire");
                        Console.WriteLine("3 - Afficher les statistiques");
                        Console.WriteLine("4 - Fuir");

                        selectorChoice = Int32.Parse(Console.ReadLine());

                        if (selectorChoice > 0 && selectorChoice < 5)
                        {
                            isInputValid = true;
                        }
                        else
                        {
                            isInputValid = false;
                        }
                    }
                    else
                    {
                        Console.Clear();
                        Player updatedPlayer = this.Monster.Hit(Player);
                        Console.ReadLine();
                        new Fight(updatedPlayer, monster, true);
                    }

                } while (!isInputValid);

                switch (selectorChoice)
                {
                    case 1:
                        new ChooseWeapon(Player, Monster);
                        break;
                    case 2:
                        new ListInventory(Player);
                        new Fight(Player, Monster, true);
                        break;
                    case 3:
                        new ListStats(Player);
                        new Fight(Player, Monster, true);
                        break;
                    case 4:
                        new Run(Player);
                        new Fight(Player, Monster, false);
                        break;
                    default:
                        Console.WriteLine("Erreur");
                        break;

                }
            } else
            {
                Console.Clear();
                Console.WriteLine("Le {0} est mort", Monster.Name);
                Player.GainXp();
                Player.DropItem();
                Player.DropWeapon();
                Save save = context.Saves.First(s => s.PlayerId == Player.Id);
                Monster.Die();
                Console.ReadLine();
                new Gameplay(save);
            }

            
        }
    }
}

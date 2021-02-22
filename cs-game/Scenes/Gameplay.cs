using cs_game.Classes;
using cs_game.Db;
using cs_game.Db.Models;
using cs_game.Scenes.Actions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace cs_game.Scenes
{
    class Gameplay
    {
        public Player Player;
        public Save Save;
        public bool isInputValid;
        public int selectorChoice;

        public Gameplay(Save save)
        {
            var factory = new DbContextFactory();
            var context = factory.CreateDbContext(null);

            this.Save = save;
            this.Player = context.Players.First(player => player.Id == Save.PlayerId);

            do
            {
                if (isInputValid)
                {
                    Console.WriteLine("Erreur : Veuillez rentrer une valeur correcte.");
                    Thread.Sleep(2000);
                }

                Console.Clear();
                Console.WriteLine("Vous êtes en  X : {0} - Y : {1}", Player.Latitude, Player.Longitude);
                Console.WriteLine("Que voulez-vous faire ?");
                Console.WriteLine("");
                Console.WriteLine("1 - Se déplacer");
                Console.WriteLine("2 - Afficher l'inventaire");
                Console.WriteLine("3 - Afficher les statistiques");
                Console.WriteLine("4 - Quitter");

                selectorChoice = Int32.Parse(Console.ReadLine());

                if (selectorChoice > 0 && selectorChoice < 5)
                {
                    isInputValid = true;
                } else
                {
                    isInputValid = false;
                }
            } while (!isInputValid);
           
            switch (selectorChoice)
            {
                case 1:
                    new Move(Player);
                    new Gameplay(save);
                    break;
                case 2:
                    new ListInventory(Player);
                    new Gameplay(save);
                    break;
                case 3:
                    new ListStats(Player);
                    new Gameplay(save);
                    break;
                case 4:
                    new Home();
                    break;
                default:
                    Console.WriteLine("Erreur");
                    break;

            }


        }
    }
}

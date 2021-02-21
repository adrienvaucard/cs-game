using cs_game.Classes;
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
        public bool isInputValid;

        public Gameplay(Save save)
        {
            this.Player = save.Player;

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
                Console.WriteLine("2 - Utiliser un objet");
                Console.WriteLine("3 - Quitter");

                if (Int32.Parse(Console.ReadLine()) > 0)
                {
                    isInputValid = true;
                } else
                {
                    isInputValid = false;
                }
            } while (isInputValid);
           
            switch (Int32.Parse(Console.ReadLine()))
            {
                case 1:
                    new Move();
                    break;
                case 2:
                    new Move();
                    break;
                default:
                    Console.WriteLine("Erreur");
                    break;

            }


        }
    }
}

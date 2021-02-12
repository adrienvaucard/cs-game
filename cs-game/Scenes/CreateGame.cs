using cs_game.Classes;
using cs_game.Maps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs_game.Scenes
{
    class CreateGame
    {
        public string PlayerName;
        public Labyrinth Map;

        public CreateGame()
        {
            Console.Clear();
            Console.WriteLine("Entrez votre nom :");
            this.PlayerName = Console.ReadLine();

            this.Map = new Labyrinth();

            // Place player randomly
            Random rnd = new Random();

            this.Map.Grid[rnd.Next(0, 10), rnd.Next(0, 10)] = 1;
        }

    }
}

using cs_game.Classes;
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

        public CreateGame()
        {
            Console.Clear();
            Console.WriteLine("Entrez votre nom :");
            this.PlayerName = Console.ReadLine();
        }

    }
}

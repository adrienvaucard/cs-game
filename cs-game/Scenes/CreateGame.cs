using cs_game.Classes;
using cs_game.Db.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs_game.Scenes
{
    class CreateGame
    {
        // Paramaters
        private int minMonsters = 9;
        private int maxMonsters = 11;

        public List<int[]> MonstersPos = new List<int[]>();
        public Player Player;
        public Map Map;
        Random rnd = new Random();

        public CreateGame()
        {
            Console.Clear();
            Console.WriteLine("Entrez votre nom :");
            this.Player = new Player(Console.ReadLine(), rnd.Next(0, 10), rnd.Next(0, 10));
            this.Map = new Map();
            this.Map.Grid[Player.Latitude, Player.Longitude] = 1;

            // Place Monsters
            for (int i = 0; i < rnd.Next(this.minMonsters, this.maxMonsters); i++)
            {
                int[] monsterPos = new int[] { rnd.Next(0, 10), rnd.Next(0, 10) };
                if (this.Map.Grid[monsterPos[0], monsterPos[1]] == 0)
                {
                    Monster monster = new Monster(rnd.Next(0, 10), rnd.Next(0, 10));
                }
            }

        }

    }
}

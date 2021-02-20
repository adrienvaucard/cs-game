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
        private int minObjects = 9;
        private int maxObjects = 11;
        private int minMonsters = 9;
        private int maxMonsters = 11;

        public List<int[]> ObjectsPos = new List<int[]>();
        public List<int[]> MonstersPos = new List<int[]>();
        public string PlayerName;
        public int[] PlayerPos;
        public Map Map;
        Random rnd = new Random();

        public CreateGame()
        {
            Console.Clear();
            Console.WriteLine("Entrez votre nom :");
            this.PlayerName = Console.ReadLine();

            this.Map = new Db.Models.Map();

            // Place player randomly
            this.PlayerPos = new int[] { rnd.Next(0, 10), rnd.Next(0, 10) };
            this.Map.Grid[PlayerPos[0], PlayerPos[1]] = 1;
            foreach(int pos in PlayerPos)
            {
                Console.WriteLine("Pos: " + pos);
            }

            // Generate few Objects
            for (int i = 0; i < rnd.Next(this.minObjects, this.maxObjects); i++)
            {
                int[] pos = new int[] { rnd.Next(0, 10), rnd.Next(0, 10) };
                if (this.Map.Grid[pos[0], pos[1]] == 0)
                {
                    this.ObjectsPos.Add(pos);
                }
            }

            /*foreach (int[] item in ObjectsPos)
            {
                Console.WriteLine("Object on Pos X : " + item[0] + " - Pos Y : " + item[1]);
            }*/

            // Place Monsters
            for (int i = 0; i < rnd.Next(this.minMonsters, this.maxMonsters); i++)
            {
                int[] pos = new int[] { rnd.Next(0, 10), rnd.Next(0, 10) };
                if (this.Map.Grid[pos[0], pos[1]] == 0)
                {
                    this.MonstersPos.Add(pos);
                }
            }

            /*foreach (int[] item in MonstersPos)
            {
                Console.WriteLine("Monster on Pos X : " + item[0] + " - Pos Y : " + item[1]);
            }*/



        }

    }
}

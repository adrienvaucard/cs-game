using cs_game.Db;
using cs_game.Db.Models;
using Microsoft.EntityFrameworkCore.Internal;
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

        public Player Player;
        public Map Map;
        Random rnd = new Random();

        public CreateGame()
        {
            var factory = new DbContextFactory();
            var context = factory.CreateDbContext(null);

            Console.Clear();
            Console.WriteLine("Entrez votre nom :");
            this.Player = new Player(Console.ReadLine(), rnd.Next(0, 10), rnd.Next(0, 10));
            context.Players.Add(Player);

            this.Map = new Map();
            this.Map.Grid[Player.Latitude, Player.Longitude] = 1;

            // Place Monsters
            List<Monster> monstersList = new List<Monster>();
            for (int i = 0; i < rnd.Next(this.minMonsters, this.maxMonsters); i++)
            {
                int[] monsterPos = new int[] { rnd.Next(0, 10), rnd.Next(0, 10) };
                if (this.Map.Grid[monsterPos[0], monsterPos[1]] == 0)
                {
                    Monster monster = new Monster(rnd.Next(0, 10), rnd.Next(0, 10));
                    monstersList.Add(monster);
                    context.Monsters.Add(monster);
                }
            }
            context.Saves.Add(new Save(Player.Name)
            {
                Player = Player,
                Monsters = monstersList
            });
            context.SaveChanges();

        }

    }
}

using cs_game.Db;
using cs_game.Db.Models;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace cs_game.Scenes
{
    class CreateGame
    {
        // Paramaters
        private int minMonsters = 9;
        private int maxMonsters = 11;
        private bool isPlayerExists;

        public Player Player;
        public Exit Exit;
        public Save Save;
        public Map Map;
        Random rnd = new Random();

        public CreateGame()
        {
            var factory = new DbContextFactory();
            var context = factory.CreateDbContext(null);

            // Create Map
            this.Map = new Map();

            // Create and place Player
            do
            {
                if (isPlayerExists)
                {
                    Console.WriteLine("Erreur : Ce nom est déjà pris. Veuillez en choisir un autre.");
                    Thread.Sleep(2000);
                }

                Console.Clear();
                Console.WriteLine("Entrez votre nom :");
                this.Player = new Player(Console.ReadLine(), rnd.Next(0, 10), rnd.Next(0, 10));
                this.Map.Grid[Player.Latitude, Player.Longitude] = 1;

                try
                {
                    context.Players.First(player => player.Name == Player.Name);
                    isPlayerExists = true;
                } catch
                {
                    isPlayerExists = false;
                    context.Players.Add(Player);
                }
            } while (isPlayerExists);

            // Place Exit
            int[] exitPos = new int[] { rnd.Next(0, 10), rnd.Next(0, 10) };
            if (this.Map.Grid[exitPos[0], exitPos[1]] == 0)
            {
                Exit = new Exit(rnd.Next(0, 10), rnd.Next(0, 10));
                this.Map.Grid[Exit.Latitude, Exit.Longitude] = 3;
                context.Exits.Add(Exit);
            }

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

            // Create Game
            Save = new Save(Player.Name)
            {
                Player = Player,
                Exit = Exit,
                Monsters = monstersList
            };
            context.Saves.Add(Save);
            context.SaveChanges();

            // Launch Game
            new Gameplay(Save);
        }

    }
}

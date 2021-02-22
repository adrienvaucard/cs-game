using cs_game.Classes;
using cs_game.Db;
using cs_game.Db.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs_game.Scenes.Actions
{
    class Move
    {

        private Player Player;
        private Save Save;
        public static List<Option> options = new List<Option>();
        public Move(Player player)
        {
            var factory = new DbContextFactory();
            var context = factory.CreateDbContext(null);

            this.Player = player;
            Player toUpdatePlayer = context.Players.First(player => player.Name == Player.Name);
            Save = context.Saves.First(save => save.Name == Player.Name);

            // Determine Player Possibilities
            if (!(Player.Longitude - 1 < 0))
            {
                options.Add(new Option("Aller au Nord", () => 
                {
                    toUpdatePlayer.Longitude -= 1;
                    context.SaveChanges();
                    Console.Clear();
                    options.Clear();
                    new Gameplay(Save);
                }));
            }

            if (!(Player.Longitude + 1 > 9))
            {
                options.Add(new Option("Aller au Sud", () =>
                {
                    toUpdatePlayer.Longitude += 1;
                    context.SaveChanges();
                    Console.Clear();
                    options.Clear();
                    new Gameplay(Save);
                }));
            }

            if (!(Player.Latitude - 1 < 0))
            {
                options.Add(new Option("Aller à l'Ouest", () =>
                {
                    toUpdatePlayer.Latitude -= 1;
                    context.SaveChanges();
                    Console.Clear();
                    options.Clear();
                    new Gameplay(Save);
                }));
            }

            if (!(Player.Latitude + 1 > 9))
            {
                options.Add(new Option("Aller à l'Est", () =>
                {
                    toUpdatePlayer.Latitude += 1;
                    context.SaveChanges();
                    Console.Clear();
                    options.Clear();
                    new Gameplay(Save);
                }));
            }

            options.Add(new Option("Annuler", () =>
            {
                Console.Clear();
                options.Clear();
                new Gameplay(Save);
            }));

            var selector = new OptionSelector(options);

        }
    }
}

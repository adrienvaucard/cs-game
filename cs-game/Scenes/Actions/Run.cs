using cs_game.Db;
using cs_game.Db.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs_game.Scenes.Actions
{
    class Run
    {
        private Player Player;
        private Save Save;
        public Run(Player player)
        {
            var factory = new DbContextFactory();
            var context = factory.CreateDbContext(null);

            this.Player = player;
            this.Save = context.Saves.First(save => save.PlayerId == Player.Id);

            Console.Clear();
            if (Player.Run())
            {
                new Gameplay(Save);
            }
        }
    }
}

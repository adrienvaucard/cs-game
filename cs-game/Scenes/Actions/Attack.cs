using cs_game.Db;
using cs_game.Db.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs_game.Scenes.Actions
{
    class Attack
    {
        private Player Player;
        private Monster Monster;

        public Attack(Player player, Weapon weapon, Monster monster)
        {
            var factory = new DbContextFactory();
            var context = factory.CreateDbContext(null);

            this.Player = player;
            this.Monster = monster;

            Console.Clear();
            this.Player.Hit(weapon, this.Monster);
            Console.ReadLine();   
        }
    }
}

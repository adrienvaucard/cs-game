using cs_game.Db.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs_game.Scenes.Actions
{
    class ListStats
    {
        private Player Player;
        public ListStats(Player player)
        {
            this.Player = player;

            this.Player.ListStats();
        }
    }
}

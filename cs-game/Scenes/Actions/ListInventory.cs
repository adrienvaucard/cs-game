using cs_game.Db;
using cs_game.Db.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs_game.Scenes.Actions
{
    class ListInventory
    {
        private Player Player;

        public ListInventory(Player player)
        {
            this.Player = player;
            Player.ListInventory();

        }
    }
}

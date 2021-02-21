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

            Console.Clear();
            Console.WriteLine("Statistiques");
            Console.WriteLine("HP - {0}", player.Hp);
            Console.WriteLine("XP - {0}", player.Xp);
            Console.WriteLine("Attack - {0}", player.Attack);
            Console.WriteLine("Defense - {0}", player.Defense);

            Console.ReadLine();
        }
    }
}

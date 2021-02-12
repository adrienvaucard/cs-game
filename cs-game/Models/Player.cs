using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs_game.Models
{
    class Player
    {
        public string Name;
        public int Attack;
        public int Defense;

        public string[] inventory;

        public Player(string name, int attack = 10, int defense = 10)
        {
            this.Name = name;
            this.Attack = attack;
            this.Defense = defense;
        }

    }
}

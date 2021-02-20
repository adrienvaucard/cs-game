using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs_game.Db.Models
{
    class Player : BaseDataObject
    {
        public string Name { get; set; }
        public int Hp { get; set; }
        public int Xp { get; set; }
        public int MaxHp { get; set; }
        public int Attack { get; set; }
        public int Defense { get; set; }

        public string[] inventory { get; set; }

        public Player(string name, int hp = 20, int attack = 2, int defense = 2)
        {
            this.Name = name;
            this.Hp = hp;
            this.Attack = attack;
            this.Defense = defense;

            this.MaxHp = 20;
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs_game.Db.Models
{
    class Monster : BaseDataObject
    {
        public string Name { get; set; }
        public int Hp { get; set; }
        public int Attack { get; set; }
        public int Defense { get; set; }
        public float HitRate { get; set; }
        public int Latitude { get; set; }
        public int Longitude { get; set; }

        public Monster(string name, int latitude, int longitude, int hp = 20, int attack = 2, int defense = 2, float hitRate = 0.7F)
        {
            this.Name = name;
            this.Latitude = latitude;
            this.Longitude = longitude;
            this.Hp = hp;
            this.Attack = attack;
            this.Defense = defense;
            this.HitRate = hitRate;
        }
    }
}

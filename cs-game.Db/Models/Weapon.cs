using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs_game.Db.Models
{
    public class Weapon : BaseDataObject
    {
        public string Name { get; set; }
        public int Attack { get; set; }
        public float HitRate { get; set; }

        public Player Player { get; set; }

        public Weapon(string name, float hitRate, int attack = 2 )
        {
            this.Name = name;
            this.Attack = attack;
            this.HitRate = hitRate;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs_game.Db.Models
{
    public class Item : BaseDataObject
    {
        public string Name { get; set; }
        public int HpBoost { get; set; }
        public int AttackBoost { get; set; }
        public int DefenseBoost { get; set; }

        public Player Player { get; set; }

        public Item(string name, int hpBoost = 0, int attackBoost = 0, int defenseBoost = 0)
        {
            this.Name = name;
            this.HpBoost = hpBoost;
            this.AttackBoost = attackBoost;
            this.DefenseBoost = defenseBoost;
        }
    }
}

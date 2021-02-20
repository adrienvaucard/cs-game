using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs_game.Db.Models
{
    public class Save : BaseDataObject
    {
        public string Name { get; set; }
        public List<Player> Player { get; set; }
        public List<Monster> Monsters { get; set; }

        public Save(string name)
        {
            this.Name = name;
        }
    }
}

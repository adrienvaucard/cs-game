using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs_game.Db.Models
{
    public class Save : BaseDataObject
    {
        [ForeignKey("Player")]
        public int PlayerId { get; set; }
        public string Name { get; set; }
        public virtual Player Player { get; set; }
        public virtual Exit Exit { get; set; }
        public List<Monster> Monsters { get; set; }

        public Save(string name)
        {
            this.Name = name;
        }
    }
}

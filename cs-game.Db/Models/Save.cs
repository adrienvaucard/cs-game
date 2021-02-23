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

        public void DeleteSave(Save save)
        {
            var factory = new DbContextFactory();
            var context = factory.CreateDbContext(null);

            save = context.Saves.First(s => s.Id == save.Id);
            Player player = context.Players.First(p => p.Id == save.Id);
            Exit exit = context.Exits.First(e => e.Id == save.Id);
            List<Monster> monsters = context.Monsters.Where(m => m.SaveId == save.Id).ToList();
            List<Weapon> weapons = context.Weapons.Where(w => w.PlayerId ==player.Id).ToList();
            List<Item> items = context.Items.Where(i => i.PlayerId == player.Id).ToList();

            context.Saves.Remove(save);
            context.Items.RemoveRange(items);
            context.Weapons.RemoveRange(weapons);
            context.Monsters.RemoveRange(monsters);
            context.Exits.Remove(exit);
            context.Players.Remove(player);
            context.SaveChanges();
        }
    }
}

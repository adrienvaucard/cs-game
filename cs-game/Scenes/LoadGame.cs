using cs_game.Classes;
using cs_game.Db;
using cs_game.Db.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs_game.Scenes
{
    class LoadGame
    {
        public List<Option> options = new List<Option>();
        public List<Save> Saves;

        public LoadGame()
        {
            var factory = new DbContextFactory();
            var context = factory.CreateDbContext(null);

            Saves = context.Saves.ToList();
            foreach (Save save in Saves)
            {
                options.Add(new Option(save.Name, () => new Gameplay(save)));
            }

            var selector = new OptionSelector(options);
        }

    }
}

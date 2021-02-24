using cs_game.Classes;
using cs_game.Db;
using cs_game.Db.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs_game.Scenes.Actions
{
    class UseItem
    {
        public static List<Option> options = new List<Option>();
        private Player Player;
        private Monster Monster;
        private List<Item> Items;
        public UseItem(Player player, Monster monster)
        {
            var factory = new DbContextFactory();
            var context = factory.CreateDbContext(null);

            this.Monster = monster;
            this.Player = context.Players.First(p => p.Id == player.Id);
            this.Items = Player.GetItems();

            foreach (Item item in Items)
            {
                options.Add(new Option(item.Name, () => 
                {
                    Player.UseItem(item);
                    Console.Read();
                    new Fight(this.Player, this.Monster, false);
                }));
            }

            options.Add(new Option("Annuler", () =>
            {
                options.Clear();
                Console.Clear();
                new Fight(Player, Monster, true);
            }));

            var selector = new OptionSelector(options);

        }
    }
}

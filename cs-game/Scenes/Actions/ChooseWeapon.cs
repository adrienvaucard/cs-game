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
    class ChooseWeapon
    {
        public static List<Option> options = new List<Option>();
        private Player Player;
        private Monster Monster;
        private List<Weapon> Weapons;

        public ChooseWeapon(Player player, Monster monster)
        {
            var factory = new DbContextFactory();
            var context = factory.CreateDbContext(null);

            this.Player = player;
            this.Monster = monster;
            Weapons = Player.GetWeapons();

            foreach (Weapon weapon in Weapons)
            {
                options.Add(new Option(weapon.Name, () =>
                {
                    options.Clear();
                    Console.Clear();
                    new Attack(Player, weapon, Monster);
                    this.Monster = context.Monsters.First(m => m.Id == Monster.Id);
                    new Fight(Player, Monster);
                }));
            }

            options.Add(new Option("Annuler", () =>
            {
                options.Clear();
                Console.Clear();
                new Fight(Player, Monster);
            }));

            var selector = new OptionSelector(options);
        }
    }
}

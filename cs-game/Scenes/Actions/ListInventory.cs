using cs_game.Db.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs_game.Scenes.Actions
{
    class ListInventory
    {
        private Player Player;
        private List<Weapon> Weapons;
        private List<Item> Items;

        public ListInventory(Player player)
        {
            Console.Clear();
            this.Player = player;

            Weapons = Player.Weapons;
            Items = Player.Items;

            // Weapons
            if (Weapons == null || Weapons.Count <= 0)
            {
                Console.WriteLine("Vous n'avez aucune arme");
            } else
            {
                Console.WriteLine("Armes :");

                foreach (var weapon in Weapons)
                {
                    Console.WriteLine("- {0}", weapon);
                }
            }

            Console.WriteLine("");

            // Items
            if (Items == null || Items.Count <= 0)
            {
                Console.WriteLine("Vous n'avez aucun objet");
            }
            else
            {
                Console.WriteLine("Objets :");

                foreach (var item in Items)
                {
                    Console.WriteLine("- {0}", item);
                }
            }
            Console.ReadLine();
        }
    }
}

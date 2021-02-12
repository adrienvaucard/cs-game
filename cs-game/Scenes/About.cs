using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs_game.Scenes
{
    class About
    {
        public About()
        {
            Console.Clear();
            Console.WriteLine("Crédits : ");
            Console.WriteLine("Développement : Adrien VAUCARD");
            Console.ReadLine();
            Console.Clear();
            new Home();
        }
    }
}

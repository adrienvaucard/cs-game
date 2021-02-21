using cs_game.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace cs_game.Scenes
{
    class Home
    {
        public static List<Option> options;

        public Home()
        {
            // Define Options
            options = new List<Option>
            {
                new Option("1 - Créer une partie", () => new CreateGame()),
                new Option("2 - Charger une partie", () =>  Console.WriteLine("Load Game")),
                new Option("3 - A propos", () =>  new About()),
                new Option("4 - Quitter", () => Environment.Exit(0)),
            };

            var selector = new OptionSelector(options);
        }
    }
}

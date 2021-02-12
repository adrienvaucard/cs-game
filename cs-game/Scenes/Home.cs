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
                new Option("1 - Create new game", () => new CreateGame()),
                new Option("2 - Load saved game", () =>  Console.WriteLine("Load Game")),
                new Option("3 - About", () =>  Console.WriteLine("About")),
                new Option("4 - Exit", () => Environment.Exit(0)),
            };

            var selector = new OptionSelector(options);
        }
    }
}

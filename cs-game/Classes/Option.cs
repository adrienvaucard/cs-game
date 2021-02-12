using System;
using System.Collections.Generic;
using System.Text;

namespace cs_game.Classes
{
    class Option
    {
        public string Name { get; }
        public Action Selected { get; }

        public Option(string name, Action selected)
        {
            Name = name;
            Selected = selected;
        }
    }
}

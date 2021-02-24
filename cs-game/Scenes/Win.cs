using cs_game.Db;
using cs_game.Db.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs_game.Scenes
{
    class Win
    {
        public Save Save;
        public Win(Save save)
        {
            this.Save = save;
            Console.Clear();
            Console.WriteLine("Félicitations, vous vous êtes échappés du labyrinthe !");
            Console.ReadLine();
            save.DeleteSave(save);
            
            new Home();
        }
    }
}

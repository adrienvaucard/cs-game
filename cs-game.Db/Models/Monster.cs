using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs_game.Db.Models
{
    public class Monster : BaseDataObject
    {
        public string Name { get; set; }
        public int Hp { get; set; }
        public int Attack { get; set; }
        public int Defense { get; set; }
        public float HitRate { get; set; }
        public int Latitude { get; set; }
        public int Longitude { get; set; }

        public Monster(int latitude, int longitude)
        {
            this.Latitude = latitude;
            this.Longitude = longitude;

            // Determine Random Mob Type
            Random rnd = new Random();
            int monsterType = rnd.Next(0, 11);

            if (monsterType >= 0 && monsterType <3)
            {
                this.Name = "Sumo";
                this.Hp = 15;
                this.Attack = 1;
                this.Defense = 3;
                this.HitRate = 0.5F;

            } else if (monsterType >= 3 && monsterType < 6)
            {
                this.Name = "Samurai";
                this.Hp = 7;
                this.Attack = 3;
                this.Defense = 1;
                this.HitRate = 0.9F;
            } else if (monsterType >= 6 && monsterType < 10)
            {
                this.Name = "Clown";
                this.Hp = 10;
                this.Attack = 2;
                this.Defense = 2;
                this.HitRate = 0.7F;
            }
        }
    }
}

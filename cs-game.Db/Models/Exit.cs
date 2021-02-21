using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs_game.Db.Models
{
    public class Exit : BaseDataObject
    {
        public int Latitude { get; set; }
        public int Longitude { get; set; }

        public Exit(int latitude, int longitude)
        {
            this.Latitude = latitude;
            this.Longitude = longitude;
        }
    }
}

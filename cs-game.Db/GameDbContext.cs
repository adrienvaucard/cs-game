using cs_game.Db.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs_game.Db
{
    public class GameDbContext : DbContext
    {
        public DbSet<Save> Saves { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Weapon> Weapons { get; set; }
        public DbSet<Monster> Monsters { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Map> Maps { get; set; }

        public GameDbContext(DbContextOptions<GameDbContext> options) : base(options)
        {

        }
    }
}

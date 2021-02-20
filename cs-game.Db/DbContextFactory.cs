using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs_game.Db
{
    class DbContextFactory : IDesignTimeDbContextFactory<GameDbContext>
    {
        public GameDbContext CreateDbContext(string[] args)
        {
            var dbContextBuilder = new DbContextOptionsBuilder<GameDbContext>();

            dbContextBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=ZorkDb;Trusted_Connection=true;",
                opt => opt.MigrationsAssembly("cs-game.Db"));

            return new GameDbContext(dbContextBuilder.Options);
        }
    }
}

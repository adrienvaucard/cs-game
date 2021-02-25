using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace cs_game.Db
{
    public class DbContextFactory : IDesignTimeDbContextFactory<GameDbContext>
    {
        public GameDbContext CreateDbContext(string[] args)
        {
            var dbContextBuilder = new DbContextOptionsBuilder<GameDbContext>();

            var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json");

            var configuration = builder.Build();

            dbContextBuilder.UseSqlServer(configuration.GetConnectionString("DB_URL"),
                opt => opt.MigrationsAssembly("cs-game.Db"));

            return new GameDbContext(dbContextBuilder.Options);
        }
    }
}

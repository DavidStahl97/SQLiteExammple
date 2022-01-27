using Microsoft.EntityFrameworkCore;

namespace SQLiteExammple
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {
        }

        public DbSet<WeatherForecast> WatherForecasts { get; set; }
    }
}

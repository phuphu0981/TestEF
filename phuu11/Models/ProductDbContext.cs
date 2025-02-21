using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace phuu11.Models
{
    public class ShopDbContext : DbContext
    {

        public static readonly ILoggerFactory loggerFactory = LoggerFactory.Create(builder => {
            builder.AddFilter(DbLoggerCategory.Query.Name, LogLevel.Information);
            builder.AddConsole();
        });
        public DbSet<Product> products {set;get;}
        public DbSet<Category> categories {set;get;}
        private const string connectionString = "Server=LAPTOP-P7MVM1FD;Database=vv;User ID=sa;Password=123;TrustServerCertificate=True;";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseLoggerFactory(loggerFactory);
            optionsBuilder.UseSqlServer(connectionString);
            optionsBuilder.UseLazyLoadingProxies();
        }
    }
}



using Microsoft.EntityFrameworkCore;

namespace EFCodeFirst
{
    public class AppDbContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source = UI\\MSSQLSERVER1; Initial Catalog = EFCore1jul; Integrated security = True; TrustServerCertificate = True;");
            }
            //base.OnConfiguring(optionsBuilder);
        }

    }
}


using Microsoft.EntityFrameworkCore;

namespace DemoWithOneProject2
{
    public class FruitContext : DbContext
    {
        public DbSet<Fruit> Fruits { get; set; }
        public DbSet<FruitCategory> FruitCategories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server = (localdb)\\mssqllocaldb; Database = DemoWithOneProject2;");
            }
            
        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Fruit>()
        //        .Property(x => x.Price)
        //        .HasColumnType("decimal(13,4)")
        //        .HasDefaultValue(123M);
        //         // Påverkar migration-script!


        //    base.OnModelCreating(modelBuilder);
        //}
    }
}
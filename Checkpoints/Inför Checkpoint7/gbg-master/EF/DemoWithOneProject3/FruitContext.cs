
using Microsoft.EntityFrameworkCore;

namespace DemoWithOneProject3
{
    public class FruitContext : DbContext
    {
        public DbSet<Fruit> Fruits { get; set; }
        public DbSet<FruitCategory> FruitCategories { get; set; }
        public DbSet<Basket> Baskets { get; set; }
        public DbSet<FruitInBasket> FruitInBaskets { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server = (localdb)\\mssqllocaldb; Database = DemoWithOneProject3;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FruitInBasket>()
                .HasKey(x => new { x.FruitId, x.BasketId });

            base.OnModelCreating(modelBuilder);
        }
    }
}


// Exempel hur man sätter datatypen decimal med ett visst defaultvärde
//protected override void OnModelCreating(ModelBuilder modelBuilder)
//{
//    modelBuilder.Entity<Fruit>()
//        .Property(x => x.Price)
//        .HasColumnType("decimal(13,4)")
//        .HasDefaultValue(123M);
//         // Påverkar migration-script!


//    base.OnModelCreating(modelBuilder);
//}
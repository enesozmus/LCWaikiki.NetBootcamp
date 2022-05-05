using Microsoft.EntityFrameworkCore;
using SecondWebAPI.DBOperations.Configurations;
using SecondWebAPI.Entities;
using SecondWebAPI.Entities.Common;

namespace SecondWebAPI.DBOperations
{
    public class SecondDbContext : DbContext
    {
        public SecondDbContext(DbContextOptions<SecondDbContext> options) : base(options) { }

        // ***** Entities ***** //
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product_Order> Products_Orders { get; set; }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            //ChangeTracker : Entityler üzerinden yapılan değişiklerin ya da yeni eklenen verinin yakalanmasını sağlayan propertydir. Update operasyonlarında Track edilen verileri yakalayıp elde etmemizi sağlar.

            var datas = ChangeTracker
                 .Entries<BaseEntity>();

            foreach (var data in datas)
            {
                _ = data.State switch
                {
                    EntityState.Added => data.Entity.CreatedDate = DateTime.Now,
                    EntityState.Modified => data.Entity.LastModifiedDate = DateTime.Now,
                    _ => DateTime.UtcNow
                };
            }

            return await base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configurations
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new OrderConfiguration());
            modelBuilder.ApplyConfiguration(new CustomerConfiguration());

            // çoka - çok ilişki
            modelBuilder.Entity<Product_Order>().HasKey(x => new { x.ProductId, x.OrderId });
            modelBuilder.Entity<Product_Order>().HasOne(m => m.Order).WithMany(am => am.Products_Orders).HasForeignKey(m => m.OrderId);
            modelBuilder.Entity<Product_Order>().HasOne(m => m.Product).WithMany(am => am.Products_Orders).HasForeignKey(m => m.ProductId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
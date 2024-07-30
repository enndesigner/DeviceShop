using DeviceShop.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace DeviceShop.Persistance.Data
{
    public class DeviceShopDbContext : DbContext
    {
        public DeviceShopDbContext(DbContextOptions<DeviceShopDbContext> options) : base(options) {}

        public DbSet<Product> Products { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Promocode> Promocodes { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<ProductProperty> ProductProperties { get; set; }
        public DbSet<Property> Properties { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Testimonial> Testimonials { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            modelBuilder.Entity<Customer>()
                .HasMany(c => c.Favourites)
                .WithMany(p => p.CustomersFavourite)
                .UsingEntity<Dictionary<string, object>>(
                    "CustomerProduct",
                    j => j.HasOne<Product>().WithMany().HasForeignKey("ProductId"),
                    j => j.HasOne<Customer>().WithMany().HasForeignKey("CustomerId"),
                    j =>
                    {
                        j.HasKey("CustomerId", "ProductId");
                    });
        
            modelBuilder.Entity<Customer>()
                .HasOne(c => c.Cart)
                .WithOne(cart => cart.Customer)
                .HasForeignKey<Cart>(cart => cart.CustomerId)
                .OnDelete(DeleteBehavior.Cascade); 

            modelBuilder.Entity<Customer>()
               .HasMany(c => c.Orders)
               .WithOne(o => o.Customer)
               .HasForeignKey(o => o.CustomerId)
               .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ProductProperty>()
                .HasKey(pp=> new {pp.ProductId, pp.PropertyId});

            base.OnModelCreating(modelBuilder);
        }
    }
}

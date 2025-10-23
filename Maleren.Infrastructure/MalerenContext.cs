using Maleren.Domain.Customers;
using Maleren.Domain.Orders;
using Maleren.Domain.Products;
using Microsoft.EntityFrameworkCore;

namespace Maleren.Infrastructure
{
    public class MalerenContext : DbContext
    {
        public MalerenContext(DbContextOptions<MalerenContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Order>()
                .ComplexProperty(x => x.CustomerSnapshot, x => x.IsRequired());

            modelBuilder.Entity<Order>()
                .OwnsOne(x => x.Discount);
        }
    }
}

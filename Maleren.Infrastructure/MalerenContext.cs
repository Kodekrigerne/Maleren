using Maleren.Domain.Products;
using Microsoft.EntityFrameworkCore;

namespace Maleren.Infrastructure
{
    public class MalerenContext : DbContext
    {
        public MalerenContext(DbContextOptions<MalerenContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }
    }
}

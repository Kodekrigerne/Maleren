using Maleren.Application;
using Maleren.Domain.Products;

namespace Maleren.Infrastructure
{
    public class ProductRepository : IProductRepository
    {
        private readonly MalerenContext _db;

        public ProductRepository(MalerenContext db)
        {
            _db = db;
        }

        async Task IProductRepository.AddProductAsync(Product product)
        {
            await _db.Products.AddAsync(product);
        }

        void IProductRepository.DeleteProduct(Product product)
        {
            _db.Products.Remove(product);
        }

        async Task<Product> IProductRepository.GetProductByGuidAsync(Guid id)
        {
            var product = await _db.Products.FindAsync(id) ?? throw new Exception();
            return product;
        }

        async Task IProductRepository.SaveChangesAsync()
        {
            await _db.SaveChangesAsync();
        }
    }
}

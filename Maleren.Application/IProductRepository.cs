using Maleren.Domain.Products;

namespace Maleren.Application
{
    public interface IProductRepository
    {
        Task AddProductAsync(Product product);
        void DeleteProduct(Product product);
        Task<Product> GetProductByGuidAsync(Guid id);
        Task SaveChangesAsync();
    }
}

using Maleren.Domain.Products;

namespace Maleren.Application
{
    public interface IProductRepository
    {
        Task AddProductAsync(Product product);
        Task DeleteProductAsync(Product product);
        Task<Product> GetProductByGuidAsync(Guid id);
        Task SaveProductAsync(Product product);
    }
}

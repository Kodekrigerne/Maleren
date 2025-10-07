using Maleren.Domain.Products;

namespace Maleren.Application
{
    public interface IProductRepository
    {
        void AddProduct(Product product);
        void DeleteProduct(Product product);
        Product GetProductByGuid(Guid id);
        void SaveProduct(Product product);
    }
}

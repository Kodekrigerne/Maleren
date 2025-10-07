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

        void IProductRepository.AddProduct(Product product)
        {
            _db.Products.Add(product);
            _db.SaveChanges();
        }

        void IProductRepository.DeleteProduct(Product product)
        {
            _db.Products.Remove(product);
            _db.SaveChanges();
        }

        Product IProductRepository.GetProductByGuid(Guid id)
        {
            var product = _db.Products.Find(id) ?? throw new Exception();

            return product;
        }

        void IProductRepository.SaveProduct(Product product)
        {
            _db.SaveChanges();
        }
    }
}

using Maleren.Ports.Driving;

namespace Maleren.Infrastructure
{
    public class ProductQueryHandler : IProductQuery
    {
        private readonly MalerenContext _db;

        public ProductQueryHandler(MalerenContext db)
        {
            _db = db;
        }

        ProductDTO IProductQuery.GetProductById(GetProductByIdQuery query)
        {
            var product = _db.Products.Find(query.Id) ?? throw new Exception();

            return new ProductDTO(product.Price, product.Category);
        }

        List<ProductDTO> IProductQuery.GetProductsByCategory(GetProductsByCategoryQuery query)
        {
            return _db.Products
                .Where(p => p.Category == query.Category)
                .Select(p => new ProductDTO(p.Price, p.Category))
                .ToList();
        }

        List<ProductDTO> IProductQuery.GetProductsByPriceRange(GetProductsByPriceRangeQuery query)
        {
            return _db.Products
                .Where(p => p.Price <= query.FromPrice && p.Price >= query.ToPrice)
                .Select(p => new ProductDTO(p.Price, p.Category))
                .ToList();
        }
    }
}

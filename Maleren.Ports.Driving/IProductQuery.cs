using Maleren.CrossCut;

namespace Maleren.Ports.Driving
{
    public interface IProductQuery
    {
        ProductDTO GetProductById(GetProductByIdQuery query);
        List<ProductDTO> GetProductsByCategory(GetProductsByCategoryQuery query);
        List<ProductDTO> GetProductsByPriceRange(GetProductsByPriceRangeQuery query);
    }

    public record GetProductsByPriceRangeQuery(decimal FromPrice, decimal ToPrice);

    public record GetProductsByCategoryQuery(ProductCategory Category);

    public record ProductDTO(decimal Price, ProductCategory Category);

    public record GetProductByIdQuery(Guid Id);
}

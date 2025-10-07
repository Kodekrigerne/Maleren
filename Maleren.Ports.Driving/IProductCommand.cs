using Maleren.CrossCut;

namespace Maleren.Ports.Driving
{
    public interface IProductCommand
    {
        void CreateProduct(CreateProductCommand command);
        void UpdateProduct(UpdateProductCommand command);
        void DeleteProduct(DeleteProductCommand command);
    }

    public record CreateProductCommand(decimal Price, ProductCategory ProductCategory);

    public record UpdateProductCommand(Guid Id, decimal Price, ProductCategory ProductCategory);

    public record DeleteProductCommand(Guid Id);
}

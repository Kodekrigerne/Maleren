using Maleren.CrossCut;

namespace Maleren.Ports.Driving
{
    public interface IProductCommand
    {
        Task CreateProductAsync(CreateProductCommand command);
        Task UpdateProductAsync(UpdateProductCommand command);
        Task DeleteProductAsync(DeleteProductCommand command);
    }

    public record CreateProductCommand(decimal Price, ProductCategory ProductCategory);

    public record UpdateProductCommand(Guid Id, decimal Price, ProductCategory ProductCategory);

    public record DeleteProductCommand(Guid Id);
}

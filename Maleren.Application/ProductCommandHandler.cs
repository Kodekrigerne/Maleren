using Maleren.Domain.Products;
using Maleren.Ports.Driving;

namespace Maleren.Application
{
    public class ProductCommandHandler : IProductCommand
    {
        private readonly IProductRepository _repo;

        public ProductCommandHandler(IProductRepository repo)
        {
            _repo = repo;
        }

        async Task IProductCommand.CreateProductAsync(CreateProductCommand command)
        {
            var product = Product.Create(command.Price, command.ProductCategory);

            await _repo.AddProductAsync(product);
            await _repo.SaveChangesAsync();
        }

        async Task IProductCommand.DeleteProductAsync(DeleteProductCommand command)
        {
            var product = await _repo.GetProductByGuidAsync(command.Id);

            _repo.DeleteProduct(product);
            await _repo.SaveChangesAsync();
        }

        async Task IProductCommand.UpdateProductAsync(UpdateProductCommand command)
        {
            var product = await _repo.GetProductByGuidAsync(command.Id);

            product.Update(command.Price, command.ProductCategory);

            await _repo.SaveChangesAsync();
        }
    }
}

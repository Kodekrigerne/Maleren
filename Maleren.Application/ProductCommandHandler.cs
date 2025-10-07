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

        void IProductCommand.CreateProduct(CreateProductCommand command)
        {
            var product = Product.Create(command.Price, command.ProductCategory);

            _repo.AddProduct(product);
        }

        void IProductCommand.DeleteProduct(DeleteProductCommand command)
        {
            var product = _repo.GetProductByGuid(command.Id);

            _repo.DeleteProduct(product);
        }

        void IProductCommand.UpdateProduct(UpdateProductCommand command)
        {
            var product = _repo.GetProductByGuid(command.Id);

            product.Update(command.Price, command.ProductCategory);

            _repo.SaveProduct(product);
        }
    }
}

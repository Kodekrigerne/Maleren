using Maleren.CrossCut;

namespace Maleren.Domain.Products
{
    //TODO: Tilføj invarianter
    public class Product : BaseEntity
    {
        public decimal Price { get; protected set; }
        public ProductCategory Category { get; protected set; }

        protected Product() { }

        private Product(decimal price, ProductCategory category)
        {
            if (price < 0) throw new ProductNegativePriceException("Price must be zero or positive");

            Price = price;
            Category = category;
        }

        public static Product Create(decimal price, ProductCategory category)
        {
            return new Product(price, category);
        }

        public void UpdatePrice(decimal price)
        {
            if (price < 0) throw new ProductNegativePriceException("Price must be zero or positive");

            Price = price;
        }

        public void UpdateCategory(ProductCategory category)
        {
            Category = category;
        }
    }
}

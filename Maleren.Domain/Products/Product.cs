namespace Maleren.Domain.Products
{
    //TODO: Tilføj invarianter
    public class Product : BaseEntity
    {
        public decimal Price { get; private set; }
        public ProductCategory Category { get; private set; }

        protected Product() { }

        private Product(decimal price, ProductCategory category)
        {
            Price = price;
            Category = category;
        }

        public static Product Create(decimal price, ProductCategory category)
        {
            return new Product(price, category);
        }
    }
}

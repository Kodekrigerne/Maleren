using Maleren.Domain.Products;

namespace Maleren.Domain.LineItems
{
    public class LineItem
    {
        public Product Product { get; private set; }
        public int Quantity { get; private set; }

        //protected LineItem() { }

        private LineItem(Product product, int quantity)
        {
            Product = product;
            Quantity = quantity;
        }

        public static LineItem Create(Product product, int quantity)
        {
            return new LineItem(product, quantity);
        }

        public decimal CalculatePrice() => Product.Price * Quantity;
    }
}

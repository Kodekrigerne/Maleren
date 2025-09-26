using Maleren.Domain.Customers;
using Maleren.Domain.Orders;
using Maleren.Domain.Products;

namespace Maleren.Domain.Discounts.DiscountStrategies
{
    public class B2bProductCategoryDiscountStrategy : IDiscountStrategy
    {
        public Customer Customer { get; protected set; }
        public ProductCategory ProductCategory { get; protected set; }
        public decimal Percent { get; protected set; }

#pragma warning disable CS8618
        protected B2bProductCategoryDiscountStrategy() { }
#pragma warning restore CS8618

        private B2bProductCategoryDiscountStrategy(Customer customer, ProductCategory productCategory, decimal percent)
        {
            Customer = customer;
            ProductCategory = productCategory;
            Percent = percent;
        }

        public static B2bProductCategoryDiscountStrategy Create(Customer customer, ProductCategory productCategory, decimal percent)
        {
            return new B2bProductCategoryDiscountStrategy(customer, productCategory, percent);
        }

        Discount IDiscountStrategy.CalculateDiscount(Order order)
        {
            if (order.Customer.CustomerType != CustomerType.B2B || order.Customer.Id != Customer.Id)
                return new Discount(GetType().Name);

            var sum = 0m;

            foreach (var lineitem in order.LineItems)
            {
                if (lineitem.Product.Category == ProductCategory)
                {
                    sum += lineitem.CalculatePrice() * Percent;
                }
            }

            return new Discount(GetType().Name, sum, sum > 0);
        }
    }
}

using Maleren.Domain.Customers;
using Maleren.Domain.Orders;

namespace Maleren.Domain.Discounts.DiscountStrategies
{
    public class B2nDiscountStrategy : IDiscountStrategy
    {
        const decimal Percent = 0.1m;

        public Discount CalculateDiscount(Order order)
        {
            if (order.Customer.CustomerType != CustomerType.B2N)
                return new Discount(GetType().Name);

            return new Discount(GetType().Name, order.CalculateOrderTotal() * Percent, true);
        }
    }
}

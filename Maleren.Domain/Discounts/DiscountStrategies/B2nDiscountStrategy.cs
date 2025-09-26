using Maleren.Domain.Customers;
using Maleren.Domain.Orders;

namespace Maleren.Domain.Discounts.DiscountStrategies
{
    public class B2nDiscountStrategy : IDiscountStrategy
    {
        public Discount CalculateDiscount(Order order)
        {
            if (order.Customer.CustomerType != CustomerType.B2N)
                return new Discount(GetType().Name, 0, false);

            return new Discount(GetType().Name, order.CalculateOrderTotal() * 0.1m, true);
        }
    }
}

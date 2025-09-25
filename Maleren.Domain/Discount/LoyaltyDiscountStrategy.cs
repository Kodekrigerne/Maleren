using Maleren.Domain.Customers;
using Maleren.Domain.Orders;

namespace Maleren.Domain.Discount
{
    public class LoyaltyDiscountStrategy : IDiscountStrategy
    {
        public int NoOfOrders { get; protected set; }
        public decimal MinPriceOfOrder { get; protected set; }
        public TimeSpan NoOfMonths { get; protected set; } = TimeSpan.FromDays(120);
        public decimal Percent { get; protected set; }

        decimal IDiscountStrategy.CalculateDiscount(Order order)
        {
            var customer = order.Customer;
            var orders = customer.Orders;

            if (customer.CustomerType != CustomerType.B2C) return 0;

            if (orders.Count(o => o.OrderDate >= order.OrderDate - NoOfMonths
                                  && o.CalculateOrderTotal() >= MinPriceOfOrder) >= NoOfOrders)
            {
                return order.CalculateOrderTotal() * Percent;
            }
            return 0;
        }
    }
}

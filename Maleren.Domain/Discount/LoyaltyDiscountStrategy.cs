using Maleren.Domain.Customers;
using Maleren.Domain.Orders;

namespace Maleren.Domain.Discount
{
    public class LoyaltyDiscountStrategy : BaseEntity, IDiscountStrategy
    {
        public int NoOfOrders { get; protected set; }
        public decimal MinPriceOfOrder { get; protected set; }
        public TimeSpan NoOfMonths { get; protected set; } = TimeSpan.FromDays(120);
        public decimal Percent { get; protected set; }

        protected LoyaltyDiscountStrategy() { }

        public LoyaltyDiscountStrategy(int noOfOrders, decimal minPriceOfOrder, TimeSpan noOfMonths, decimal percent)
        {
            NoOfOrders = noOfOrders;
            MinPriceOfOrder = minPriceOfOrder;
            NoOfMonths = noOfMonths;
            Percent = percent;
        }

        public static LoyaltyDiscountStrategy Create(int noOfOrders, decimal minPriceOfOrder, TimeSpan noOfMonths, decimal percent)
        {
            return new LoyaltyDiscountStrategy(noOfOrders, minPriceOfOrder, noOfMonths, percent);
        }

        decimal IDiscountStrategy.CalculateDiscount(Order order)
        {
            var customer = order.Customer;
            var orders = customer.Orders;

            if (customer is not B2cCustomer) return 0;

            if (orders.Count(o => o.OrderDate >= order.OrderDate - NoOfMonths
                                  && o.CalculateOrderTotal() >= MinPriceOfOrder) >= NoOfOrders)
            {
                return order.CalculateOrderTotal() * Percent;
            }
            return 0;
        }
    }
}

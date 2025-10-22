using Maleren.Domain.Customers;
using Maleren.Domain.Orders;

namespace Maleren.Domain.Discounts.DiscountStrategies
{
    public class LoyaltyDiscountStrategy : BaseEntity, IDiscountStrategy
    {
        private ICustomerOrdersService? _customerOrdersService;

        public int NoOfOrders { get; protected set; }
        public decimal MinPriceOfOrder { get; protected set; }
        public TimeSpan NoOfMonths { get; protected set; }
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

        Discount IDiscountStrategy.CalculateDiscount(Order order)
        {
            // TODO: Add Expection
            if (_customerOrdersService is null) throw new ArgumentException();

            if (order.Customer.CustomerType != CustomerType.B2C) return new Discount(GetType().Name);

            var orders = _customerOrdersService.GetOrders(order.Customer.CustomerId);

            if (orders.Count(o => o.OrderDate >= order.OrderDate - NoOfMonths
                                  && o.CalculateOrderTotal() >= MinPriceOfOrder) >= NoOfOrders)
            {
                return new Discount(GetType().Name, order.CalculateOrderTotal() * Percent, true);
            }
            return new Discount(GetType().Name);
        }
    }
}

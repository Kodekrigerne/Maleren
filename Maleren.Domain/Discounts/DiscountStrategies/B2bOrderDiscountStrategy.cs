using Maleren.Domain.Orders;

namespace Maleren.Domain.Discounts.DiscountStrategies
{
    public class B2bOrderDiscountStrategy : IDiscountStrategy
    {

        public Order Order { get; protected set; }
        public decimal Percent { get; protected set; }

#pragma warning disable CS8618
        protected B2bOrderDiscountStrategy() { }
#pragma warning restore CS8618

        private B2bOrderDiscountStrategy(Order order, decimal percent)
        {
            Order = order;
            Percent = percent;
        }

        public static B2bOrderDiscountStrategy Create(Order order, decimal percent)
        {
            return new B2bOrderDiscountStrategy(order, percent);
        }

        Discount IDiscountStrategy.CalculateDiscount(Order order)
        {
            if (order.Customer.CustomerType != Customers.CustomerType.B2B || Order.Id != order.Id)
                return new Discount(GetType().Name);

            return new Discount(GetType().Name, order.CalculateOrderTotal() * Percent, true);
        }
    }
}

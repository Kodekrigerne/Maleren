using Maleren.Domain.Customers;
using Maleren.Domain.Orders;

namespace Maleren.Domain.Discounts.DiscountStrategies
{
    public class B2bLoyaltyDiscountStrategy : IDiscountStrategy
    {
        private ICustomerOrdersService? _customerOrdersService;
        public Customer Customer { get; protected set; }
        public int NoOfOrders { get; protected set; }
        public decimal MinPriceOfOrder { get; protected set; }
        public TimeSpan NoOfMonths { get; protected set; } = TimeSpan.FromDays(120);
        public decimal Percent { get; protected set; }

#pragma warning disable CS8618
        protected B2bLoyaltyDiscountStrategy() { }
#pragma warning restore CS8618

        private B2bLoyaltyDiscountStrategy(Customer customer, int noOfOrders, decimal minPriceOfOrder, TimeSpan noOfMonths, decimal percent)
        {
            Customer = customer;
            NoOfOrders = noOfOrders;
            MinPriceOfOrder = minPriceOfOrder;
            NoOfMonths = noOfMonths;
            Percent = percent;
        }

        public static B2bLoyaltyDiscountStrategy Create(Customer customer, int noOfOrders, decimal minPriceOfOrder, TimeSpan noOfMonths, decimal percent)
        {
            return new B2bLoyaltyDiscountStrategy(customer, noOfOrders, minPriceOfOrder, noOfMonths, percent);
        }

        Discount IDiscountStrategy.CalculateDiscount(Order order)
        {
            // TODO: Add Exception 
            if (_customerOrdersService is null) throw new ArgumentException();

            if (order.Customer.CustomerType != CustomerType.B2B || Customer.Id != order.Customer.Id)
                return new Discount(GetType().Name);

            var orders = _customerOrdersService.GetOrders(order.Customer.Id);


            if (orders.Count(o => o.OrderDate >= order.OrderDate - NoOfMonths
                                  && o.CalculateOrderTotal() >= MinPriceOfOrder) >= NoOfOrders)
            {
                return new Discount(GetType().Name, order.CalculateOrderTotal() * Percent, true);
            }

            return new Discount(GetType().Name);
        }

        public void SetCustomerOrdersService(ICustomerOrdersService customerOrdersService)
        {
            _customerOrdersService = customerOrdersService;
        }
    }
}

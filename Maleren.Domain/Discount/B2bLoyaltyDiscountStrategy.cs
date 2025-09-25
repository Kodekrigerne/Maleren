using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Maleren.Domain.Customers;
using Maleren.Domain.Orders;

namespace Maleren.Domain.Discount
{
    public class B2bLoyaltyDiscountStrategy : IDiscountStrategy
    {
        public B2bCustomer Customer { get; protected set; }
        public int NoOfOrders { get; protected set; }
        public decimal MinPriceOfOrder { get; protected set; }
        public TimeSpan NoOfMonths { get; protected set; } = TimeSpan.FromDays(120);
        public decimal Percent { get; protected set; }

    #pragma warning disable CS8618 
        protected B2bLoyaltyDiscountStrategy() { }
    #pragma warning restore CS8618 

        private B2bLoyaltyDiscountStrategy(B2bCustomer customer, int noOfOrders, decimal minPriceOfOrder, TimeSpan noOfMonths, decimal percent)
        {
            Customer = customer;
            NoOfOrders = noOfOrders;
            MinPriceOfOrder = minPriceOfOrder;
            NoOfMonths = noOfMonths;
            Percent = percent;
        }

        public static B2bLoyaltyDiscountStrategy Create(B2bCustomer customer, int noOfOrders, decimal minPriceOfOrder, TimeSpan noOfMonths, decimal percent)
        {
            return new B2bLoyaltyDiscountStrategy(customer, noOfOrders, minPriceOfOrder, noOfMonths, percent);
        }

        decimal IDiscountStrategy.CalculateDiscount(Order order)
        {
            var orders = order.Customer.Orders;

            if (Customer.Id != order.Customer.Id) return 0;
            
            if (orders.Count(o => o.OrderDate >= order.OrderDate - NoOfMonths
                                  && o.CalculateOrderTotal() >= MinPriceOfOrder) >= NoOfOrders)
            {
                return order.CalculateOrderTotal() * Percent;
            }
            return 0;
        }
    }
}

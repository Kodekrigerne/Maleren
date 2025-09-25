using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Maleren.Domain.Orders;

namespace Maleren.Domain.Discount
{
    public class B2bOrderDiscountStrategy : IDiscountStrategy
    {

        public Order Order { get; protected set; }
        public decimal Percent { get; protected set; }

#pragma warning disable CS8618
        protected B2bOrderDiscountStrategy() {}
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

        decimal IDiscountStrategy.CalculateDiscount(Order order)
        {
            if (Order.Id != order.Id) return 0;

            return order.CalculateOrderTotal() * Percent;
        }
    }
}

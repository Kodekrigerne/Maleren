using Maleren.Domain.Customers;
using Maleren.Domain.LineItems;

namespace Maleren.Domain.Orders
{
    //TODO: Tilføj invarianter
    public class Order : BaseEntity
    {
        public IEnumerable<LineItem> LineItems { get; protected set; }
        public DateTime OrderDate { get; protected set; }
        public BaseCustomer Customer { get; protected set; }

#pragma warning disable CS8618 
        protected Order() { }
#pragma warning restore CS8618 

        private Order(IEnumerable<LineItem> lineItems, DateTime orderDate, BaseCustomer customer)
        {
            LineItems = lineItems;
            OrderDate = orderDate;
            Customer = customer;
        }

        public static Order Create(IEnumerable<LineItem> lineItems, DateTime orderDate, BaseCustomer customer)
        {
            return new Order(lineItems, orderDate, customer);
        }

        public decimal CalculateOrderTotal()
        {
            return LineItems.Sum(item => item.CalculatePrice());
        }
    }
}

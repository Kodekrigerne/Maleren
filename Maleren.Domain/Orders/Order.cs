using Maleren.Domain.Customers;
using Maleren.Domain.LineItems;

namespace Maleren.Domain.Orders
{
    //TODO: Tilføj invarianter
    public class Order
    {
        public IEnumerable<LineItem> LineItems { get; protected set; }
        public DateTime OrderDate { get; protected set; }
        public Customer Customer { get; protected set; }

        //TODO: Uncomment, null!;, eller pragma
        //protected Order() { }

        private Order(IEnumerable<LineItem> lineItems, DateTime orderDate)
        {
            LineItems = lineItems;
            OrderDate = orderDate;
        }

        public static Order Create(IEnumerable<LineItem> lineItems, DateTime orderDate)
        {
            return new Order(lineItems, orderDate);
        }

        public decimal CalculateOrderTotal()
        {
            return LineItems.Sum(item => item.CalculatePrice());
        }
    }
}

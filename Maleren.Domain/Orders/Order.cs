using Maleren.Domain.LineItems;

namespace Maleren.Domain.Orders
{
    //>> Tilføj invarianter
    public class Order
    {
        public IEnumerable<LineItem> LineItems { get; private set; }
        public DateTime OrderDate { get; private set; }

        //Uncomment, null!;
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
    }
}

using Maleren.Domain.Customers;
using Maleren.Domain.Discounts;
using Maleren.Domain.LineItems;

namespace Maleren.Domain.Orders
{
    //TODO: Tilføj invarianter
    public class Order : BaseEntity
    {
        public IEnumerable<LineItem> LineItems { get; protected set; }
        public DateTime OrderDate { get; protected set; }
        public OrderCustomer OrderCustomer { get; protected set; }
        //TODO: What do?
        public Customer Customer { get; protected set; }
        public Discount? Discount { get; protected set; }

#pragma warning disable CS8618 
        protected Order() { }
#pragma warning restore CS8618 

        private Order(IEnumerable<LineItem> lineItems, DateTime orderDate, OrderCustomer orderCustomer, Customer customer)
        {
            LineItems = lineItems;
            OrderDate = orderDate;
            OrderCustomer = orderCustomer;
            Customer = customer;
        }

        public static Order Create(IEnumerable<LineItem> lineItems, DateTime orderDate, OrderCustomer orderCustomer, Customer customer)
        {
            return new Order(lineItems, orderDate, orderCustomer, customer);
        }

        public decimal CalculateOrderTotal()
        {
            return LineItems.Sum(item => item.CalculatePrice());
        }

        public void GetDiscount(IDiscountCalculatorService discountCalculatorService)
        {
            Discount = discountCalculatorService.GetBestDiscount(this);
        }
    }
}

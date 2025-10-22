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
        public Customer Customer { get; protected set; }
        public CustomerSnapshot CustomerSnapshot { get; protected set; }
        public Discount? Discount { get; protected set; }

#pragma warning disable CS8618 
        protected Order() { }
#pragma warning restore CS8618 

        private Order(IEnumerable<LineItem> lineItems, DateTime orderDate, Customer customer)
        {
            LineItems = lineItems;
            OrderDate = orderDate;
            Customer = customer;
            CustomerSnapshot = CustomerSnapshot.FromCustomer(customer);
        }

        public static Order Create(IEnumerable<LineItem> lineItems, DateTime orderDate, Customer customer)
        {
            return new Order(lineItems, orderDate, customer);
        }

        public decimal CalculateOrderTotal()
        {
            return LineItems.Sum(item => item.CalculatePrice());
        }

        public void GetDiscount(IDiscountCalculatorService discountCalculatorService)
        {
            Discount = discountCalculatorService.GetBestDiscount(this);
        }

        //TODO: Add method for order after discount. Check for null/discount inactive.
    }
}

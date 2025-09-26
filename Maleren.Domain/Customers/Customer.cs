using Maleren.Domain.Orders;

namespace Maleren.Domain.Customers
{
    public class Customer : BaseEntity
    {
        public List<Order> Orders { get; protected set; }
        public CustomerType CustomerType { get; protected set; }

#pragma warning disable CS8618
        protected Customer() { }
#pragma warning restore CS8618

        private Customer(List<Order> orders, CustomerType customerType)
        {
            Orders = orders;
            CustomerType = customerType;
        }

        public static Customer Create(List<Order> orders, CustomerType customerType)
        {
            return new Customer(orders, customerType);
        }
    }
}

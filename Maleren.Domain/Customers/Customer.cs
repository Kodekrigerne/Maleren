using Maleren.Domain.Orders;

namespace Maleren.Domain.Customers
{
    public class Customer
    {
        public List<Order> Orders { get; protected set; }
        public CustomerType CustomerType { get; protected set; }
    }
}

using System.ComponentModel.DataAnnotations.Schema;
using Maleren.Domain.Customers;

namespace Maleren.Domain.Orders
{
    [ComplexType]
    public record CustomerSnapshot
    {
        public Guid CustomerId { get; }
        public CustomerType CustomerType { get; }

        protected CustomerSnapshot() { }

        private CustomerSnapshot(Customer customer)
        {
            CustomerId = customer.Id;
            CustomerType = customer.CustomerType;
        }

        public static CustomerSnapshot FromCustomer(Customer customer) => new(customer);
    }
}

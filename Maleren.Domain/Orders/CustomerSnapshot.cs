using Maleren.Domain.Customers;

namespace Maleren.Domain.Orders
{
    public record CustomerSnapshot
    {
        public Guid CustomerId { get; private init; }
        public CustomerType CustomerType { get; private init; }

        protected CustomerSnapshot() { }

        private CustomerSnapshot(Customer customer)
        {
            CustomerId = customer.Id;
            CustomerType = customer.CustomerType;
        }

        public static CustomerSnapshot FromCustomer(Customer customer) => new(customer);
    }
}

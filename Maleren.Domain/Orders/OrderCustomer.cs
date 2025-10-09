using System.ComponentModel.DataAnnotations.Schema;
using Maleren.Domain.Customers;

namespace Maleren.Domain.Orders
{
    [ComplexType]
    public record OrderCustomer
    {
        public Guid Id { get; }
        public CustomerType CustomerType { get; }

        protected OrderCustomer() { }

        private OrderCustomer(Customer customer)
        {
            Id = customer.Id;
            CustomerType = customer.CustomerType;
        }

        public static OrderCustomer FromCustomer(Customer customer) => new(customer);
    }
}

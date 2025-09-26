using Maleren.Domain.Customers;

namespace Maleren.Domain.Orders
{
    public record OrderCustomer(Guid Id, CustomerType CustomerType);
}

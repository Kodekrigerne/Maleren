using Maleren.Domain.Orders;

namespace Maleren.Domain.Discounts.DiscountStrategies;

public interface ICustomerOrdersService
{
    List<Order> GetOrders(Guid customerId);
}
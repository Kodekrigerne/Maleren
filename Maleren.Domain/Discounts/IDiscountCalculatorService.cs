using Maleren.Domain.Orders;

namespace Maleren.Domain.Discounts
{
    public interface IDiscountCalculatorService
    {
        Discount? GetBestDiscount(Order order);
    }
}

using System.Collections.Concurrent;
using Maleren.Domain.Discounts;
using Maleren.Domain.Orders;

namespace Maleren.Application;

public class DiscountCalculatorService : IDiscountCalculatorService
{
    public List<IDiscountStrategy> DiscountStrategies { get; protected set; } = [];

    Discount? IDiscountCalculatorService.GetBestDiscount(Order order)
    {
        ConcurrentBag<Discount> discounts = [];

        Parallel.ForEach(DiscountStrategies, discountStrategy =>
        {
            discounts.Add(discountStrategy.CalculateDiscount(order));
        });

        return discounts.Where(x => x.DiscountActive).MaxBy(x => x.DiscountAmount);
    }
}
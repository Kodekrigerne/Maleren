using Maleren.Domain.Orders;

namespace Maleren.Domain.Discount
{
    public class CampaignDiscountStrategy : IDiscountStrategy
    {
        protected CampaignDiscountStrategy() { }

        decimal IDiscountStrategy.CalculateDiscount(Order order)
        {
            throw new NotImplementedException();
        }
    }
}

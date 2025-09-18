using Maleren.Domain.Orders;
using Maleren.Domain.Products;

namespace Maleren.Domain.Discount
{
    public class CampaignDiscountStrategy : IDiscountStrategy
    {
        public ProductCategory ProductCategory { get; private set; }
        public DateTime StartTime { get; private set; }
        public DateTime EndTime { get; private set; }
        public decimal Percent { get; private set; }

        protected CampaignDiscountStrategy() { }

        //private CampaignDiscountStrategy() { }

        public static CampaignDiscountStrategy Create()
        {
            return new CampaignDiscountStrategy();
        }

        decimal IDiscountStrategy.CalculateDiscount(Order order)
        {
            var discount = 0m;

            foreach (var lineItem in order.LineItems)
            {
                if (lineItem.Product.Category == ProductCategory
                    && order.OrderDate > StartTime
                    && order.OrderDate < EndTime)
                {
                    discount += lineItem.CalculatePrice() * Percent;
                }
            }

            return discount;
        }
    }
}

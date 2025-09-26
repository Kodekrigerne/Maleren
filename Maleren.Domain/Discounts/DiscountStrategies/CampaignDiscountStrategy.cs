using Maleren.Domain.Orders;
using Maleren.Domain.Products;

namespace Maleren.Domain.Discounts.DiscountStrategies
{
    //>> Summary her
    //>> Tilføj invarianter (fx endtime før starttime), procent positiv
    public class CampaignDiscountStrategy : BaseEntity, IDiscountStrategy
    {
        public ProductCategory ProductCategory { get; protected set; }
        public DateTime StartTime { get; protected set; }
        public DateTime EndTime { get; protected set; }
        public decimal Percent { get; protected set; }

        protected CampaignDiscountStrategy() { }

        private CampaignDiscountStrategy(ProductCategory productCategory, DateTime startTime, DateTime endTime, decimal percent)
        {
            ProductCategory = productCategory;
            StartTime = startTime;
            EndTime = endTime;
            Percent = percent;
        }

        public static CampaignDiscountStrategy Create(ProductCategory productCategory, DateTime startTime, DateTime endTime, decimal percent)
        {
            return new CampaignDiscountStrategy(productCategory, startTime, endTime, percent);
        }

        Discount IDiscountStrategy.CalculateDiscount(Order order)
        {
            var sum = 0m;

            foreach (var lineItem in order.LineItems)
            {
                if (lineItem.Product.Category == ProductCategory
                    && order.OrderDate > StartTime
                    && order.OrderDate < EndTime)
                {
                    sum += lineItem.CalculatePrice() * Percent;
                }
            }

            return new Discount(GetType().Name, sum, sum > 0);
        }
    }
}

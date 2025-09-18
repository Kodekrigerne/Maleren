using Maleren.Domain.Orders;
using Maleren.Domain.Products;

namespace Maleren.Domain.Discount
{
    //>> Summary her
    //>> Tilføj invarianter (fx endtime før starttime), procent positiv
    public class CampaignDiscountStrategy : IDiscountStrategy
    {
        public ProductCategory ProductCategory { get; private set; }
        public DateTime StartTime { get; private set; }
        public DateTime EndTime { get; private set; }
        public decimal Percent { get; private set; }

        //>> Uncomment
        //protected CampaignDiscountStrategy() { }

        //>> Tilføj constructor parameters
        private CampaignDiscountStrategy() { }

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

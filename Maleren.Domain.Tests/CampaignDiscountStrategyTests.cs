using Maleren.Domain.Discounts;
using Maleren.Domain.LineItems;
using Maleren.Domain.Orders;
using Maleren.Domain.Products;

//namespace Maleren.Domain.Tests
//{
//    public class CampaignDiscountStrategyTests
//    {

//        [Test]
//        public void CalculateDiscount_Given_Order_Returns_AtLeastZero()
//        {

//            //TODO: Fiksturer på alle object creations
//            // Arrange
//            var product = Product.Create(5.99m, ProductCategory.Pensler);
//            var lineItem = LineItem.Create(product, 5);
//            var order = Order.Create([lineItem], DateTime.Now);
//            IDiscountStrategy campaignDiscountStrategy = CampaignDiscountStrategy.Create();

//            // Act
//            var actual = campaignDiscountStrategy.CalculateDiscount(order);

//            // Assert
//            Assert.That(actual, Is.AtLeast(0));
//        }
//    }

//    //TODO: Test af specifikke beløb

//    //TODO: Test for ordre med 0 lineItems
//}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Maleren.Domain.Products;

namespace Maleren.Domain.Tests.ProductTests
{
    public class UpdatePriceTests
    {
        [Test]
        public void Given_NegativePrice_Then_ThrowsException()
        {
            //Arrange
            var price = -10;
            var testProduct = new ProductTestFixture { Price = 5, Category = ProductCategory.Maling };

            //Act & Assert
            Assert.Throws<ProductNegativePriceException>(() => testProduct.UpdatePrice(price));
        }

        [Test]
        public void Given_PositivePrice_Then_UpdatesProduct()
        {
            //Arrange
            var price = 1;
            var testProduct = new ProductTestFixture { Price = 5, Category = ProductCategory.Maling };

            //Act
            testProduct.UpdatePrice(price);

            //Assert
            Assert.That(testProduct.Price, Is.EqualTo(price));
        }

        [Test]
        public void Given_ZeroPrice_Then_UpdatesPrice()
        {
            //Arrange
            var price = 0;
            var testProduct = new ProductTestFixture { Price = 5, Category = ProductCategory.Maling };

            //Act
            testProduct.UpdatePrice(price);

            //Assert
            Assert.That(testProduct.Price, Is.EqualTo(price));
        }
    }
}

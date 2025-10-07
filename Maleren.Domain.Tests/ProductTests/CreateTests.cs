using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Maleren.Domain.Products;

namespace Maleren.Domain.Tests.ProductTests
{
    public class CreateTests
    {
        [Test]
        public void Given_NegativePrice_Then_ThrowsException()
        {
            //Arrange
            var price = -10;

            //Act & Assert
            Assert.Throws<ProductNegativePriceException>(() => Product.Create(price, ProductCategory.Maling));

        }

        [Test]
        public void Given_PositivePrice_Then_CreatesProduct()
        {
            //Arrange
            var price = 1;

            //Act
            var product = Product.Create(price, ProductCategory.Maling);

            //Assert
            Assert.That(product.Price, Is.EqualTo(price));
        }

        [Test]
        public void Given_ZeroPrice_Then_CreatesProduct()
        {
            //Arrange
            var price = 0;

            //Act
            var product = Product.Create(price, ProductCategory.Maling);

            //Assert
            Assert.That(product.Price, Is.EqualTo(price));
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Maleren.Domain.Discounts;

namespace Maleren.Domain.Tests
{
    public class DiscountPercentTests
    {
        [Test]
        public void Given_NegativePercent_Then_ThrowsException()
        {
            //Arrange
            decimal percentToGive = -0.1m;

            //Act & Assert
            Assert.Throws<InvalidDiscountPercentException>(() => new DiscountPercent(percentToGive));
        }

        [Test]
        public void Given_PercentOver1_Then_ThrowsException()
        {
            //Arrange
            decimal percentToGive = 1.1m;

            //Act & Assert
            Assert.Throws<InvalidDiscountPercentException>(() => new DiscountPercent(percentToGive));
        }

        [TestCase("0")]
        [TestCase("1")]
        [TestCase("0,5")]
        public void Given_ValidPercent_Then_CreatesDiscountPercent(string percent)
        {
            //Arrange
            decimal percentToGive = decimal.Parse(percent);

            //Act
            var discountPercent = new DiscountPercent(percentToGive);

            //Assert
            Assert.That(percentToGive, Is.EqualTo(discountPercent.Percent));
        }
    }
}

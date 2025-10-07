using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Maleren.Domain.Products;

namespace Maleren.Domain.Tests.ProductTests
{
    public class UpdateCategoryTests
    {
        [Test]
        public void Given_NewCategory_Then_CategoryUpdated()
        {
            //Arrange
            var currentCategory = ProductCategory.Pensler;
            var newCategory = ProductCategory.Maling;
            var testProduct = new ProductTestFixture() { Price = 5, Category = currentCategory };

            //Act
            testProduct.UpdateCategory(newCategory);

            //Assert
            Assert.That(testProduct.Category, Is.EqualTo(newCategory));
        }
    }
}

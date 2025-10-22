using Maleren.Application;
using Maleren.CrossCut;
using Maleren.Domain.Products;
using Microsoft.EntityFrameworkCore;

namespace Maleren.Infrastructure.Tests.ProductRepositoryTests
{
    public class ProductAsyncTests
    {
        private DbContextOptions<MalerenContext> _options;
        private MalerenContext _db;

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            _options = new DbContextOptionsBuilder<MalerenContext>().UseSqlite("Data Source=:memory:").Options;
            _db = new MalerenContext(_options);
            _db.Database.OpenConnection();
            _db.Database.EnsureCreated();
        }

        [SetUp]
        public void Setup()
        {
            _db.Database.EnsureDeleted();
            _db.Database.EnsureCreated();
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            _db.Dispose();
        }

        [Test]
        public void Given_NewProduct_Then_AddsProductToDatabase()
        {
            // Arrange
            var repo = new ProductRepository(_db) as IProductRepository;
            var product = Product.Create(200, ProductCategory.Pensler);

            // Act
            repo.AddProductAsync(product);
            repo.SaveChangesAsync();

            // Assert
            var actualProduct = _db.Products.First();
            Assert.Multiple(() =>
            {
                Assert.That(actualProduct.Price, Is.EqualTo(product.Price));
                Assert.That(actualProduct.Category, Is.EqualTo(product.Category));
            });
        }

        [Test]
        public void Given_ProductExistsInDatabase_ThenDeletesProduct()
        {
            // Arrange
            var repo = new ProductRepository(_db) as IProductRepository;
            var product = Product.Create(300, ProductCategory.Maling);
            repo.AddProductAsync(product);
            repo.SaveChangesAsync();
            var productToDelete = _db.Products.First();

            // Act
            repo.DeleteProduct(productToDelete);
            repo.SaveChangesAsync();

            // Assert
            var maybeNullProduct = _db.Products.Find(productToDelete.Id);
            Assert.That(maybeNullProduct, Is.EqualTo(null));
        }
    }
}

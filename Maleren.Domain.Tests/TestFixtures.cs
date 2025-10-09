using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Maleren.CrossCut;
using Maleren.Domain.Products;

namespace Maleren.Domain.Tests
{
    public class ProductTestFixture : Product
    {
        public new decimal Price { get => base.Price; set => base.Price = value; }
        public new ProductCategory Category { get => base.Category; set => base.Category = value; }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maleren.Domain.Products
{
    public class ProductException : Exception
    {
        public ProductException(string message) : base(message) { }
        public ProductException(string message, Exception innerException) : base(message, innerException) { }

    }

    public class ProductNegativePriceException : ProductException
    {
        public ProductNegativePriceException(string message) : base(message) { }
        public ProductNegativePriceException(string message, Exception innerException) : base(message, innerException) { }

    }
}

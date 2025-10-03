using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maleren.Domain.Discounts
{
    public class DiscountPercentException : Exception
    {
        public DiscountPercentException(string message) : base(message) { }
        public DiscountPercentException(string message, Exception innerException) : base(message, innerException) { }
    }

    public class InvalidDiscountPercentException : DiscountPercentException
    {
        public InvalidDiscountPercentException(string message) : base(message) { }
        public InvalidDiscountPercentException(string message, Exception innerException) : base(message, innerException) { }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maleren.Domain.Discounts
{
    public record DiscountPercent
    {
        public decimal Percent { get; }
        public DiscountPercent(decimal percent)
        {
            if (percent < 0 || percent > 1)
                throw new InvalidDiscountPercentException("Discount percent must not be outside of 0-1.");

            Percent = percent;
        }
    }
}

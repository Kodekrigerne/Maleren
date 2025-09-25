using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Maleren.Domain.Customers;
using Maleren.Domain.Orders;
using Maleren.Domain.Products;

namespace Maleren.Domain.Discount
{
    public class B2bProductCategoryDiscountStrategy : IDiscountStrategy
    {
        public B2bCustomer Customer { get; protected set; }
        public ProductCategory ProductCategory { get; protected set; }
        public decimal Percent { get; protected set; }

#pragma warning disable CS8618
        protected B2bProductCategoryDiscountStrategy() { }
#pragma warning restore CS8618

        private B2bProductCategoryDiscountStrategy(B2bCustomer customer, ProductCategory productCategory, decimal percent)
        {
            Customer = customer;
            ProductCategory = productCategory;
            Percent = percent;
        }

        public static B2bProductCategoryDiscountStrategy Create(B2bCustomer customer, ProductCategory productCategory, decimal percent)
        {
            return new B2bProductCategoryDiscountStrategy(customer, productCategory, percent);
        }

        decimal IDiscountStrategy.CalculateDiscount(Order order)
        {
            if (order.Customer.Id != Customer.Id) return 0;

            var sum = 0m;

            foreach (var lineitem in order.LineItems)
            {
                if (lineitem.Product.Category == ProductCategory)
                {
                    sum += lineitem.CalculatePrice() * Percent;
                }
            }

            return sum;
        }
    }
}

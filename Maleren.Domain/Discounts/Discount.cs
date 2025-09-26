namespace Maleren.Domain.Discounts
{
    public record Discount(string DiscountName, decimal DiscountAmount, bool DiscountActive)
    {
        public Discount(string discountName) : this(discountName, 0m, false) { }
    }
}

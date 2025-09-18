using Maleren.Domain.Orders;

namespace Maleren.Domain.Discount
{
    public interface IDiscountStrategy
    {
        /// <summary>
        /// Calculates a discount for a given order
        /// </summary>
        /// <remarks>
        /// Preconditions:<br />
        ///  - The order has more than 0 items<br />
        /// Postconditions:<br />
        ///  - Calculated discount is a positive value<br />
        /// </remarks>
        /// <param name="order">The order to calculate a discount for</param>
        /// <returns>A decimal of value at least 0 representing the discount amount</returns>
        decimal CalculateDiscount(Order order);
    }
}

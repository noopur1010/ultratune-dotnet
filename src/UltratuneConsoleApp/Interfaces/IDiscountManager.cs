// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace UltraTune.Interfaces;
internal interface IDiscountManager
{
    /// <summary>
    /// Gets the discount for a product based on the specified discount type.
    /// </summary>
    /// <param name="product">The product for which to calculate the discount.</param>
    /// <param name="discountType">The type of discount to apply.</param>
    /// <returns>The calculated discount for the product.</returns>
    decimal GetProductDiscount(IProduct product, DiscountType discountType);
}

// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace UltraTune.Interfaces;
internal interface IDiscount
{
    /// <summary>
    /// Gets the discounted price for a product.
    /// </summary>
    /// <param name="product">The product to calculate the discount for.</param>
    /// <returns>The discounted price.</returns>
    decimal GetDiscountPrice(IProduct product);

    /// <summary>
    /// Gets the type of discount.
    /// </summary>
    /// <returns>The discount type.</returns>
    DiscountType GetDiscountType { get; }
}

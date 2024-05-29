// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using UltraTune.Interfaces;

namespace UltraTune;
internal class DiscountManager : IDiscountManager
{
    private readonly IEnumerable<IDiscount> _discounts;

    public DiscountManager(IEnumerable<IDiscount> discount) => _discounts = discount;
    

    public decimal GetProductDiscount(IProduct product, DiscountType discountType) => GetDiscountType(discountType).GetDiscountPrice(product);

    private IDiscount GetDiscountType(DiscountType discountType) => _discounts.SingleOrDefault(d => d.GetDiscountType == discountType) ?? throw new InvalidOperationException("Discount type not found.");  
}

// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using UltraTune.Interfaces;

namespace UltraTune;
internal class FixedAmountDiscount : IDiscount
{
    private const decimal _fixedAmountDiscount = 10m;
    private const decimal _threshold = 100m;

    public DiscountType GetDiscountType => DiscountType.FixedAmount;

    public decimal GetDiscountPrice(IProduct product) => (product.Price > _threshold && product.Price > _fixedAmountDiscount) ? product.Price - _fixedAmountDiscount : product.Price;
}

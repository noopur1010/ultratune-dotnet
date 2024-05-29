// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using UltraTune.Interfaces;

namespace UltraTune;
internal class PercentageDiscount : IDiscount
{
    private const decimal _percentage = 5m;
    private const decimal _threshold = 100m;

    public DiscountType GetDiscountType => DiscountType.Percentage;

    public decimal GetDiscountPrice(IProduct product) =>
        (product.Price > _threshold && product.Price > _percentage) ? product.Price - (product.Price * _percentage) / 100 : product.Price;

}

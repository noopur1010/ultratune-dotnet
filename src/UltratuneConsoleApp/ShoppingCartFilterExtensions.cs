// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using UltraTune.Interfaces;

namespace UltraTune;
internal static class ShoppingCartFilterExtensions
{
    public static void GetProductsByPriceRange(this IShoppingCart cart, decimal minPrice, decimal maxPrice) =>
       DisplayExtension.DisplayProducts(cart.GetProducts().Where(p => p.Price >= minPrice && p.Price <= maxPrice));

    public static void GetProductsByName(this IShoppingCart cart, string name) =>
        DisplayExtension.DisplayProducts(cart.GetProducts().Where(p => p.Name.Equals(name)));
}

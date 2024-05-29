// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using UltraTune.Interfaces;

namespace UltraTune;
internal static class DisplayExtension
{
    public static void DisplayProducts(this IEnumerable<IProduct> products)
    {
        if (products == null || !products.Any())
        {
            Console.WriteLine("No products to display.");
            return;
        }

        products.ToList().ForEach(p => Console.WriteLine(p.DisplayDetails()));
    }
}

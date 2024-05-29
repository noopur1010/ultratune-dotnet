// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace UltraTune.Interfaces;
internal interface IProduct
{
    int Id { get; }
    string Name { get; }
    decimal Price { get; }

    /// <summary>
    /// Displays the details of the product.
    /// </summary>
    string DisplayDetails();
}

// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace UltraTune.Interfaces;
internal interface IOrder
{
    /// <summary>
    /// Adds a product to the order with the specified quantity.
    /// </summary>
    /// <param name="product">The product to add.</param>
    /// <param name="quantity">The quantity of the product to add.</param>
    void AddProduct(Product product, int quantity);

    /// <summary>
    /// Calculates and returns the total price of the order.
    /// </summary>
    /// <returns>The total price of the order.</returns>
    decimal GetTotalOrderPrice();

    /// <summary>
    /// Displays the details of the order.
    /// </summary>
    void DisplayOrderDetails();
}

// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace UltraTune.Interfaces;
internal interface IShoppingCart
{
    /// <summary>
    /// Adds a product to the shopping cart.
    /// </summary>
    /// <param name="product">The product to add.</param>
    void AddProduct(IProduct product);

    /// <summary>
    /// Removes a product from the shopping cart.
    /// </summary>
    /// <param name="product">The product to remove.</param>
    void RemoveProduct(Product product);

    /// <summary>
    /// Gets all the products in the shopping cart.
    /// </summary>
    /// <returns>An enumerable collection of products.</returns>
    IEnumerable<IProduct> GetProducts();

    /// <summary>
    /// Calculates the total price of all products in the shopping cart.
    /// </summary>
    /// <returns>The total price.</returns>
    decimal GetTotalPrice();

    /// <summary>
    /// Applies a discount to the shopping cart.
    /// </summary>
    /// <param name="discountType">The type of discount to apply.</param>
    void ApplyDiscount(DiscountType discountType);

    /// <summary>
    /// Saves the shopping cart to a file.
    /// </summary>
    /// <param name="filePath">The path of the file to save to.</param>
    void SaveToFile(string filePath);

    /// <summary>
    /// Loads the shopping cart from a file.
    /// </summary>
    /// <param name="filePath">The path of the file to load from.</param>
    void LoadFromFile(string filePath);
}


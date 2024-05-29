// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using UltraTune.Interfaces;

namespace UltraTune;
internal class Order : IOrder
{
    private Dictionary<Product, int> _orderItems = new();

    public void AddProduct(Product product, int quantity)
    {
        if(ValidateProductQuantity(product, quantity))
            throw new ArgumentException("Invalid product quantity");

        if (_orderItems.ContainsKey(product))
        {
            UpdateProductQuantity(product, quantity);
        }
        AddProductQuantity(product, quantity);
    }

    private bool ValidateProductQuantity(Product product, int quantity) => product == null || quantity <= 0;

    private void AddProductQuantity(Product product, int quantity) => _orderItems.Add(product, quantity);   

    private void UpdateProductQuantity(Product product, int quantity) => _orderItems[product] = quantity;

    public decimal GetTotalOrderPrice() => _orderItems.Sum(item => item.Key.Price * item.Value);

    public void DisplayOrderDetails()
    {
        if (_orderItems.Any())
        {
            DisplayAllOrderitems();
        }
        else
        {
            Console.WriteLine("The order is empty.");
        }
    }

    private void DisplayAllOrderitems() => _orderItems.ToList().ForEach(item => Console.WriteLine($"{item.Key.DisplayDetails()}, Quantity: {item.Value}"));
}

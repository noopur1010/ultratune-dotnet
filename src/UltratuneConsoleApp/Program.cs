// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace UltraTune;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using UltraTune.Interfaces;

internal static class Program
{
    static void Main(string[] args)
    {
        var host = CreateHostBuilder(args).Build();

        var shoppingCart = host.Services.GetRequiredService<IShoppingCart>();

        var product1 = new Product(1, "Laptop", 999.99m);
        var product2 = new Product(2, "Smartphone", 499.99m);
        var product3 = new Product(3, "Headphones", 199.99m);
        var product4 = new Product(4, "Headphones_V2", 299.99m);

        shoppingCart.AddProduct(product1);
        shoppingCart.AddProduct(product2);
        shoppingCart.AddProduct(product3);
        shoppingCart.AddProduct(product4);

        /* Display all products */
        Console.WriteLine("All products from cart");
        shoppingCart.GetProducts().DisplayProducts();

        /* remove specific product product */
        shoppingCart.RemoveProduct(product4);
        /* Display all products after remove */
        Console.WriteLine("All products from cart");
        shoppingCart.GetProducts().DisplayProducts();

        /* add duplicate product */
        try
        {
            shoppingCart.AddProduct(product1);
        }
        catch (DuplicateProductException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }

        Console.WriteLine("Apply Discount");
        shoppingCart.ApplyDiscount(DiscountType.FixedAmount);
        /* Display all products after applying discount */
        Console.WriteLine("All products from cart");
        shoppingCart.GetProducts().DisplayProducts();

        // Filter products
        Console.WriteLine("Filtering products by price range");
        shoppingCart.GetProductsByPriceRange(200, 5000);
        Console.WriteLine("Filtering products by name");
        shoppingCart.GetProductsByName("Laptop");

        // Create order
        var order = host.Services.GetRequiredService<IOrder>();
        order.AddProduct(product1, 2);
        order.AddProduct(product2, 1);

        Console.WriteLine("Order details");
        order.DisplayOrderDetails();
        Console.WriteLine($"Total Order Price: {order.GetTotalOrderPrice()}");


        // Save and load cart
        shoppingCart.SaveToFile("cart.json");
        shoppingCart.LoadFromFile("cart.json");
        shoppingCart.GetProducts().DisplayProducts();

    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureServices((_, services) =>
                services.AddTransient<IProduct, Product>()
                        .AddScoped<IShoppingCart, ShoppingCart>()
                        .AddTransient<IDiscountManager, DiscountManager>()
                        .AddTransient<IDiscount, FixedAmountDiscount>()
                        .AddTransient<IDiscount, PercentageDiscount>()
                        .AddScoped<IOrder, Order>()
                        );
}

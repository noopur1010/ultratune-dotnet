// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Text.Json;
using UltraTune.Interfaces;

namespace UltraTune;
internal class ShoppingCart : IShoppingCart
{
    private List<IProduct>? _products;

    private readonly IDiscountManager _discountManager;


    public ShoppingCart(IDiscountManager discountManager)
    {
        _products = new List<IProduct>();
        _discountManager = discountManager; 
    }

    public void AddProduct(IProduct product)
    {
        if (!ApplyAddValidationRules(product))
        {
            Console.WriteLine($"Product not added: {product.DisplayDetails()}");
            return;
        }
        _products!.Add(product);
        Console.WriteLine($"Product added: {product.DisplayDetails()}");
    }

    private bool ApplyAddValidationRules(IProduct product) => NullValidation(product) && DuplicateValidation(product);

    private bool DuplicateValidation(IProduct product) => _products!.Exists(p => p.Id == product.Id) ? throw new DuplicateProductException(product) : true;

    private bool NullValidation(IProduct product) => (product == null) ? throw new ArgumentNullException(nameof(product)) : true;


    private bool RemoveProductFromList(Product product) => _products!.Remove(product);

    public void RemoveProduct(Product product)
    {
        NullValidation(product);

        if (!RemoveProductFromList(product))
        {
            Console.WriteLine($"Product not removed: {product.DisplayDetails()}");
            return;
        }

        Console.WriteLine($"Product removed: {product.DisplayDetails()}");
    }

    public IEnumerable<IProduct> GetProducts() => _products ?? Enumerable.Empty<IProduct>();
    public decimal GetTotalPrice() => (_products == null || !_products.Any()) ? 0 : _products.Sum(p => p.Price);


    public void ApplyDiscount(DiscountType discountType)
    {
        if (_products != null && _products.Any())
        {
            var _discountedRateProducts = _products
                .Select(product =>
                new Product(
                    product.Id,
                    product.Name,
                    _discountManager.GetProductDiscount(product, DiscountType.FixedAmount)))
                .Cast<IProduct>()
                .ToList();

            _products = _discountedRateProducts!;
        }
    }

    public void SaveToFile(string filePath)
    {
        var json = JsonSerializer.Serialize(_products);
        File.WriteAllText(filePath, json);
        Console.WriteLine($"Shopping cart saved to {filePath}");
    }

    public void LoadFromFile(string filePath)
    {
        if (File.Exists(filePath))
        {
            var json = File.ReadAllText(filePath);
            var productsFromFile = JsonSerializer.Deserialize<List<Product>>(json);

            if (productsFromFile != null && productsFromFile.Any())
            {
                _products = productsFromFile.Cast<IProduct>().ToList();
                Console.WriteLine($"Shopping cart loaded from {filePath}");
            }
            else
            {
                Console.WriteLine("Failed to load products from the file.");
            }
        }
        else
        {
            Console.WriteLine($"File {filePath} does not exist.");
        }
    }

}

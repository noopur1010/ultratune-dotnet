// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using UltraTune.Interfaces;

namespace UltraTune;

internal record Product(int Id, string Name, decimal Price) : IProduct
{
    public string DisplayDetails() => ToString();
    public override string ToString() => $"Id: {Id}, Name: {Name}, Price: {Price}";
    
}

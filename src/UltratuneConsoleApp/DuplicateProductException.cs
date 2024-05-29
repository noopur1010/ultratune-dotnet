// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using UltraTune.Interfaces;

namespace UltraTune;
public class DuplicateProductException : Exception
{
    
    internal DuplicateProductException(IProduct product)
        : base($"{product} already exists in the cart.")
    {
        
    }

    internal DuplicateProductException(string message, IProduct product)
        : base(message)
    {
        
    }

    internal DuplicateProductException(string message, Exception inner, IProduct product)
        : base(message, inner)
    {
        
    }
}

﻿using Domain.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Domain.Handlers.Data
{
    internal class InvalidProductData
    {
        public static IEnumerable<object[]> GetData()
        {
            yield return new object[] { new CreateProductCommand("", 10, "Description 1", 1, 1) };
            yield return new object[] { new CreateProductCommand("Product 1", 0, "Description 1", 1, 0) };
            yield return new object[] { new CreateProductCommand("Product 1", 10, "", 1, 1) };
            yield return new object[] { new CreateProductCommand("Product 1", 10, "Description 1", 0, 0) };
            yield return new object[] { new CreateProductCommand("", 0, "", 0, 1) };
            yield return new object[] { new CreateProductCommand(null, 10, "Description 1", 1, 0) };
            yield return new object[] { new CreateProductCommand("Product 1", 0, "Description 1", 1, 1) };
            yield return new object[] { new CreateProductCommand("Product 1", 10, null, 1, 0) };
            yield return new object[] { new CreateProductCommand("Product 1", 10, "Description 1", 0, 1) };
            yield return new object[] { new CreateProductCommand(null, 0, null, 0, 0) };
        }
    }
}

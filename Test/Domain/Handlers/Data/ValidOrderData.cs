using Domain.Commands.OrderCommands;
using Domain.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Domain.Handlers.Data
{
    internal class ValidOrderData
    {
        public static IEnumerable<object[]> GetData()
        {
            return new List<object[]>
            {
                new object[] { new List<Product> { new Product("Product 1", 10, "Description", 1) }, 1 },
                new object[] { new List<Product> { new Product("Product 1", 10, "Description", 1), new Product("Product 2", 20, "Description", 1) }, 1 },
                new object[] { new List<Product> { new Product("Product 1", 10, "Description", 1), new Product("Product 2", 20, "Description", 1), new Product("Product 3", 30, "Description", 1) }, 1 },
                new object[] { new List<Product> { new Product("Product 1", 10, "Description", 1), new Product("Product 2", 20, "Description", 1), new Product("Product 3", 30, "Description", 1), new Product("Product 4", 40, "Description", 1) }, 1 },
            };
        }
    }
}

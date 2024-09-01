using Domain.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Domain.Handlers.Data
{
    internal class ValidProductData
    {
        public static IEnumerable<object[]> GetData()
        {
            yield return new object[] { new CreateProductCommand("Product 1", 10, "Description 1", 1, 1) };
        }
    }
}

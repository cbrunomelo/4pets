using Domain.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Domain.Handlers.Data
{
    internal class InvalidOrderData
    {
        public static List<object[]> Data()
        {
            return new List<object[]>
            {
                new object[] { new List<OrderItem> { new OrderItem(null, 3) }, 1, 0 },
                new object[] { new List<OrderItem> { new OrderItem(new Product("Product 2", 2, "Produto test", 2),3) }, 2, 0 },
                new object[] { new List<OrderItem> { new OrderItem(new Product("Product 3", 2, "Produto test", 2),0) }, 3, 2 },
                new object[] { new List<OrderItem> { new OrderItem(new Product("Product 4", 2, "Produto test", 2),3) }, 0, 2 }
            };
        }
    }
}

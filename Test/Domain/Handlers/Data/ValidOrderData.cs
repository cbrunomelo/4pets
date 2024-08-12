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
                new object[] { new List<OrderItem> { new OrderItem(new Product("Product 1", 2, "Produto test", 2),3) }, 1, 2 },
                new object[] { new List<OrderItem> { new OrderItem(new Product("Product 2", 2, "Produto test", 2),3) }, 2, 2 },
                new object[] { new List<OrderItem> { new OrderItem(new Product("Product 3", 2, "Produto test", 2),3) }, 3, 2 },
            };
        }
    }
}

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
                new object[] {new List<OrderItem> { new OrderItem(new Product("teste", 2, "none", 2), 1) }, 2, 1 },
                new object[] {new List<OrderItem> { new OrderItem(new Product("teste2", 21, "none", 2), 1) }, 2, 2 },
                new object[] {new List<OrderItem> { new OrderItem(new Product("teste3", 12, "none", 2), 1) }, 2, 3 }
            };
        }
    }
}

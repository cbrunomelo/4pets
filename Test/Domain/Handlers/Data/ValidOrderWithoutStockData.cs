using Domain.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Domain.Handlers.Data
{
    public class ValidOrderWithoutStockData
    {
        public static IEnumerable<object[]> GetData()
        {
            var product1 = new Product("Product 1", 2, "Produto test", 2);
            product1.SetId(1);
            product1.Stock = new Stock("Stock 1", 0, 2, 20, product1);

            var product2 = new Product("Product 2", 2, "Produto test", 2);
            product2.SetId(2);
            product2.Stock = new Stock("Stock 2", 0, 2, 20, product2);

            var product3 = new Product("Product 3", 2, "Produto test", 2);
            product3.SetId(3);
            product3.Stock = new Stock("Stock 3", 0, 2, 20, product3);

            return new List<object[]>
            {
                new object[] { new List<OrderItem> { new OrderItem(product1,3) }, 1, 2 },
                new object[] { new List<OrderItem> { new OrderItem(product2,3) }, 2, 2 },
                new object[] { new List<OrderItem> { new OrderItem(product3, 2)}, 3, 2 },
            };
        }
    }
}

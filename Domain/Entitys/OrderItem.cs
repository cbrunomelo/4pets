using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entitys
{
    public class OrderItem
    {
        public int Id { get; private set; }
        public Product Product { get; private set; }
        public int ProductId 
        { get
            {
                if (Product is null)
                    return 0;
                return Product.Id;
            }
            private set{ } }
        public int Quantity { get; private set; }
        public decimal Total { get; private set; }
        public Order Order { get; private set; }
        public int OrderId { get; private set; }
        public History History { get; private set; }
        public int HistoryId { get; private set; }

        public OrderItem(Product product, int quantity)
        {
            Product = product;
            ProductId = product is null ? 0 : product.Id;
            Quantity = quantity;
            SetTotal();
        }
        private OrderItem()
        {
        }

        private void SetTotal() => Total = Quantity * (Product is null ? 1 : Product.Price);        
        internal void SetId(int id) => Id = id;
        
    }
}

using Application.Dtos.Contracts;
using Domain.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos
{
    public class OrderItemDto : IDto
    {
        public int Id { get; set; }
        public ProductDto? Product { get; set; }
        public int Quantity { get; set; }
        public decimal Total
        {
            get
            {
                if (Product is not null)
                    return Product.Price * Quantity;
                return 0;
            }
        }

       
    }
}

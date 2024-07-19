using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entitys
{
    public class Stock : Entity
    {
        public string Name { get; private set; }       
        public decimal Quantity { get; private set; }
        public decimal AvaragePrice { get; private set; }
        public decimal Total { get; private set; }

        public Product Product { get; private set; }

        public void setEntry(decimal quantity, decimal total)
        {
            Quantity += quantity;
            Total += total;
            AvaragePrice = Total / Quantity;
        }

    }
}

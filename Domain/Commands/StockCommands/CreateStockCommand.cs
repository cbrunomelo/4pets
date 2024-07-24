using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Commands.StockCommands
{
    public class CreateStockCommand
    {
        public string Name { get; set; }
        public decimal Quantity { get; set; }
        public int ProductId { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Commands.StockCommands
{
    public class EntryStockCommand
    {
        public int StockId { get; set; }
        public decimal Quantity { get; set; }

        public decimal TotalValue { get; set; }
    }
}

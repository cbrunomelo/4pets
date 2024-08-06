using Domain.Commands.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Commands.StockCommands
{
    public record EntryStockCommand(int StockId, decimal Quantity, decimal TotalValue, int UserId) : ICommand;
}

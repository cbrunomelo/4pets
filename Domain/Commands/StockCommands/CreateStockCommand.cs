﻿using Domain.Commands.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Commands.StockCommands
{
    public record CreateStockCommand(string Name, decimal Quantity, int ProductId, int UserId) : ICommand;
}

﻿using Domain.Commands.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Commands
{
    public record CreateProductCommand(string Name, decimal Price, string Description, int CategoryId, int UserId) : ICommand;

}

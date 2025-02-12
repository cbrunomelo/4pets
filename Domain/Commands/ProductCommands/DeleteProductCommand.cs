using Domain.Commands.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Commands.ProductCommands
{
    public record DeleteProductCommand(int Id, int UserId) : ICommand;
}

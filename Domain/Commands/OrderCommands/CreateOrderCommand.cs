using Domain.Commands.Contracts;
using Domain.Entitys;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Commands.OrderCommands
{
    public record CreateOrderCommand(List<OrderItem> Itens, int ClientId, int UserId) : ICommand;
}

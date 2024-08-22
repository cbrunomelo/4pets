using Domain.Commands.OrderCommands;
using Domain.Handlers.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class OrderService
    {
        private readonly IHandler<CreateOrderCommand> _orderHandler;
        public OrderService()
        {

            _orderHandler = new OrderHandler(
        }
    }
}

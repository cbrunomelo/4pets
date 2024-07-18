using Domain.Commands.Contracts;
using Domain.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Commands.OrderCommands
{
    public class CreateOrderCommand : ICommand
    { 
        public CreateOrderCommand(List<OrderItem> itens, int clientId)
        {
            Itens = itens;
            ClientId = clientId;
        }
        public List<OrderItem> Itens { get; set; }
        public int ClientId { get; set; }

    }
}

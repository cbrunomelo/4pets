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
        public CreateOrderCommand(List<Product> products, int clientId)
        {
            Products = products;
            ClientId = clientId;
        }
        public List<Product> Products { get; set; }
        public int ClientId { get; set; }

    }
}

using Application.Dtos.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos
{
    public record OrderDto(int Id, string Name, 
                            string Description, decimal Value, 
                            DateTime CreatedAt, List<OrderItemDto> Itens,
                            ClientDto Client) : IDto;    
}

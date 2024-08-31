using Application.Dtos.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos
{
    public record ClientDto(int Id, string Name, string Email, string Phone, 
        string Address, string City, string State, string ZipCode, DateTime CreatedAt) : IDto;

}

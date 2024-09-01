using Application.Dtos.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos
{
    public record ProductDto(int Id, string Name, string Description, Decimal Price, int Category) : IDto;

}

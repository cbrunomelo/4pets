using Application.Dtos.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos
{
    public record PaginacaoDto (int Page, int PageSize, int Total = 0, int TotalPages = 0) : IDto;
  
}

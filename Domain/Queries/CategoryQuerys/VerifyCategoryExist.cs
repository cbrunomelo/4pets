using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Queries.CategoryQuerys
{
    public record VerifyCategoryExist(int Id) : IRequest<bool>;
}

using Domain.Entitys;
using Domain.Handlers.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Commands.Contracts
{
    public interface ICommand : IRequest<IHandleResult>
    {
        int UserId { get; init; }
    }
}

using Domain.Commands.Contracts;
using MediatR;

namespace Domain.Handlers.Contracts
{
    public interface IHandler<T> : IRequestHandler<T, IHandleResult> where T : ICommand
    {
    }
}
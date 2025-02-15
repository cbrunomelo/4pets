namespace Domain.Handlers.Contracts
{
    public interface IHandler<T>
    {
        Task<IHandleResult> Handle(T command);
    }
}
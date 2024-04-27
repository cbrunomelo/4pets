namespace Domain.Handlers.Contracts
{
    public interface IHandler<T>
    {
        IHandleResult Handle(T command);
    }
}
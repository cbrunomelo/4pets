namespace Infra.Logger;

public interface ILoggerRepo
{
    Task Create(object log);
}
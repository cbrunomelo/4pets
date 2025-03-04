using Infra.Logger;
using Microsoft.Extensions.Logging;
using System.Collections.Concurrent;

namespace Application.Logger;

public class CustomLoggerProvider : ILoggerProvider
{
    private readonly ILoggerRepo _repo;
    private readonly CustomLoggerProviderConfiguration _config;

    readonly ConcurrentDictionary<string, CustomerLogger> loggers = new ConcurrentDictionary<string, CustomerLogger>();

    public CustomLoggerProvider(ILoggerRepo repo, CustomLoggerProviderConfiguration config)
    {
        _repo = repo;
        _config = config;
    }

    public ILogger CreateLogger(string categoryName) => loggers.GetOrAdd(categoryName, name => new CustomerLogger(name, _config, _repo));        
    public void Dispose() => loggers.Clear();
}

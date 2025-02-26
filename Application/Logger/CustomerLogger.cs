using Infra.Logger;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Application.Logger;

public class CustomerLogger : ILogger
{
    private readonly string _name;
    private readonly CustomLoggerProviderConfiguration _config;
    private readonly ILoggerRepo _repo;

    public CustomerLogger(string name, CustomLoggerProviderConfiguration config, ILoggerRepo repo)
    {
        _name = name;
        _config = config;
        _repo = repo;
    }

    public IDisposable? BeginScope<TState>(TState state) where TState : notnull => null;

    public bool IsEnabled(LogLevel logLevel) => logLevel >= _config.LogLevel;

    public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
    {
        if (!IsEnabled(logLevel)) return;

        var logEntry = new
        {
            Timestamp = DateTime.UtcNow.ToString("o"), 
            Level = logLevel.ToString(),
            EventId = eventId.Id,
            Message = formatter(state, exception),
            Exception = exception?.ToString(),
            Trace = exception?.StackTrace,
            MachineName = Environment.MachineName
        };

        _repo.Create(logEntry);
    }
}

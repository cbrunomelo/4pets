using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Logger;

public record CustomLoggerProviderConfiguration(LogLevel LogLevel = LogLevel.Error, int EventId = 0);

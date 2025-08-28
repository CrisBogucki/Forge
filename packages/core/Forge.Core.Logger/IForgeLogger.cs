using Microsoft.Extensions.Logging;

namespace Forge.Core.Logger;

public interface IForgeLogger
{
    void Log(LogLevel level, string message, Exception? exception = null);
}
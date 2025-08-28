using Microsoft.Extensions.Logging;

namespace Forge.Core.Logger.Abstractions;

public interface ILogSink: IDisposable
{
    void Write(LogLevel level, string message, Exception? exception = null);
}
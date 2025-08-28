using System.Reflection;
using Microsoft.Extensions.Logging;

namespace Forge.Core.Logger.Abstractions;

internal class ForgeLogger(IEnumerable<ILogSink> sinks) : IForgeLogger, IDisposable
{
    private readonly List<ILogSink> _sinks = [..sinks];
    private bool _disposed;

    public void Log(LogLevel level, string message, Exception? exception = null)
    {
        foreach (var sink in _sinks)
        {
            sink.Write(level, message, exception);
        }
    }

    public virtual void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    private void Dispose(bool disposing)
    {
        if (_disposed) return;

        if (disposing)
        {
            foreach (var sink in _sinks)
            {
                sink.Dispose();
            }
        }

        _disposed = true;
    }
}
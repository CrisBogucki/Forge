using Microsoft.Extensions.Logging;

namespace Forge.Core.Logger.Abstractions;

internal sealed class ForgeLoggerProvider(ForgeLogger forgeLogger) : ILoggerProvider
{
    private bool _disposed;

    public Microsoft.Extensions.Logging.ILogger CreateLogger(string categoryName)
    {
        return new ForgeLoggerAdapter(forgeLogger, categoryName);
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    private void Dispose(bool disposing)
    {
        if (_disposed) return;
        if (disposing) forgeLogger.Dispose();
        _disposed = true;
    }
}
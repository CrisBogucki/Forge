using Serilog;

namespace Forge.Core.Logger.Abstractions;

/// <summary>
/// A Serilog-based implementation of the ILogger interface for logging operations.
/// </summary>
internal class Logger : ILogger
{
    private readonly Serilog.ILogger _logger;

    /// <summary>
    /// Initializes a new instance of the Logger class with a default configuration.
    /// Logs only to console with Information level.
    /// </summary>
    public Logger()
    {
        _logger = new LoggerConfiguration()
            .MinimumLevel.Information()
            .WriteTo.Console() 
            .CreateLogger();
    }

    /// <summary>
    /// Initializes a new instance of the Logger class with a custom Serilog configuration.
    /// </summary>
    public Logger(LoggerConfiguration configuration)
    {
        _logger = configuration.CreateLogger();
    }

    public void LogInformation(string message) => _logger.Information(message);
    public void LogWarning(string message) => _logger.Warning(message);
    public void LogError(string message, Exception? exception = null) => _logger.Error(exception, message);
}
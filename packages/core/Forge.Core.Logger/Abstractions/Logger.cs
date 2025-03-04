using Serilog;

namespace Forge.Core.Logger.Abstractions;

/// <summary>
/// A Serilog-based implementation of the ILogger interface for logging operations.
/// </summary>
internal class Logger : ILogger
{
    private readonly Serilog.ILogger _logger;

    /// <summary>
    /// Initializes a new instance of the Logger class with a default configuration that logs to the console.
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
    /// <param name="configuration">The custom LoggerConfiguration to be used for creating the logger.</param>
    public Logger(LoggerConfiguration configuration)
    {
        _logger = configuration.CreateLogger();
    }

    public Logger(Serilog.ILogger logger)
    {
        _logger = logger;
    }

    /// <summary>
    /// Logs a message at the Information level.
    /// </summary>
    /// <param name="message">The message content to be logged.</param>
    public void LogInformation(string message)
    {
        _logger.Information(message);
    }

    /// <summary>
    /// Logs a message at the Warning level.
    /// </summary>
    /// <param name="message">The message content to be logged.</param>
    public void LogWarning(string message)
    {
        _logger.Warning(message);
    }

    /// <summary>
    /// Logs a message at the Error level with an optional exception.
    /// </summary>
    /// <param name="message">The message content to be logged.</param>
    /// <param name="exception">An optional exception related to the error, can be null.</param>
    public void LogError(string message, Exception? exception = null)
    {
        _logger.Error(exception, message);
    }
}
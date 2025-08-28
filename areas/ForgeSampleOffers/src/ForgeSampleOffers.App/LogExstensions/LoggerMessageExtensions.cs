using Microsoft.Extensions.Logging;

namespace ForgeSampleOffers.App.LogExstensions;

public static class LoggerMessageExtensions
{
    
    public static void LogInformationQueryHandlerPingMessage(this ILogger logger, string details) => _logInformationPingMessage(logger, details, null);
    public static void LogInformationQueryHandlerPongMessage(this ILogger logger, string details) => _logInformationPongMessage(logger, details, null);
    
    public static void LogInformationQueryHandler(this ILogger logger, string details) => _logInformationQueryHandler(logger, details, null);
    
    private static readonly Action<ILogger, string, Exception?> _logInformationPingMessage =
        LoggerMessage.Define<string>(
            LogLevel.Information,
            new EventId(1001, nameof(LogInformationQueryHandlerPingMessage)),
            "Information {Details} log message");
    
    private static readonly Action<ILogger, string, Exception?> _logInformationPongMessage =
        LoggerMessage.Define<string>(
            LogLevel.Information,
            new EventId(1003, nameof(LogInformationQueryHandlerPongMessage)),
            "Information {Details} log message");
    
    private static readonly Action<ILogger, string, Exception?> _logInformationQueryHandler =
        LoggerMessage.Define<string>(
            LogLevel.Information,
            new EventId(1002, nameof(LogInformationQueryHandler)),
            "{Details}");
}
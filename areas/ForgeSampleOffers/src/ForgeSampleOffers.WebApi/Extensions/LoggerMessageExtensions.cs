namespace ForgeSampleOffers.WebApi.Extensions;

public static class LoggerMessageExtensions
{
    public static void LogTraceMessage(this ILogger logger, string details) => _logTraceMessage(logger, details, null);
    public static void LogDebugMessage(this ILogger logger, string details) => _logDebugMessage(logger, details, null);
    public static void LogInformationMessage(this ILogger logger, string details) => _logInformationMessage(logger, details, null);
    public static void LogWarningMessage(this ILogger logger, string details) => _logWarningMessage(logger, details, null);
    public static void LogErrorMessage(this ILogger logger, string details, Exception? exception = null) => _logErrorMessage(logger, details, exception);
    public static void LogCriticalMessage(this ILogger logger, string details, Exception? exception = null) => _logCriticalMessage(logger, details, exception);
    
    private static readonly Action<ILogger, string, Exception?> _logTraceMessage =
        LoggerMessage.Define<string>(
            LogLevel.Trace,
            new EventId(2001, nameof(LogTraceMessage)),
            "Trace log: {Details}");

    private static readonly Action<ILogger, string, Exception?> _logDebugMessage =
        LoggerMessage.Define<string>(
            LogLevel.Debug,
            new EventId(2002, nameof(LogDebugMessage)),
            "Debug log: {Details}");

    private static readonly Action<ILogger, string, Exception?> _logInformationMessage =
        LoggerMessage.Define<string>(
            LogLevel.Information,
            new EventId(2003, nameof(LogInformationMessage)),
            "Information log: {Details}");
    
    private static readonly Action<ILogger, string, Exception?> _logWarningMessage =
        LoggerMessage.Define<string>(
            LogLevel.Warning,
            new EventId(2004, nameof(LogWarningMessage)),
            "Warning log: {Details}");

    private static readonly Action<ILogger, string, Exception?> _logErrorMessage =
        LoggerMessage.Define<string>(
            LogLevel.Error,
            new EventId(2005, nameof(LogErrorMessage)),
            "Error log: {Details}");
    
    private static readonly Action<ILogger, string, Exception?> _logCriticalMessage =
        LoggerMessage.Define<string>(
            LogLevel.Critical,
            new EventId(2006, nameof(LogCriticalMessage)),
            "Critical log: {Details}");
}
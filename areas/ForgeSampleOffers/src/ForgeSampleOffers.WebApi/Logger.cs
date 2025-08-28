using ForgeSampleOffers.WebApi.Extensions;

namespace ForgeSampleOffers.WebApi;

public static class Logger
{
    public static void LogStartupMessages(WebApplication app)
    {
        var logger = app.Services.GetRequiredService<ILogger<Program>>();

        logger.LogTraceMessage("detailed information for debugging.");
        logger.LogDebugMessage("useful for development.");
        logger.LogInformationMessage("Application started.");
        logger.LogWarningMessage("something might be wrong.");
        logger.LogErrorMessage("an error occurred!", new Exception("Sample exception"));
        logger.LogCriticalMessage("critical failure!");
    }
}
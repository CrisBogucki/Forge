using Forge.Core.Mediator;
using ForgeSampleOffers.App.LogExstensions;

namespace ForgeSampleOffers.WebApi.Handlers;

public class LoggingBehavior<TRequest, TResponse>(
    ILogger<LoggingBehavior<TRequest, TResponse>> logger)
    : IPipelineLoggingBehavior<TRequest, TResponse>
{
    public async Task<TResponse> Handle(
        TRequest request,
        CancellationToken cancellationToken,
        Func<Task<TResponse>> next)
    {
        logger.LogInformationQueryHandler($"Pipeline is working - Handling {typeof(TRequest).Name}");
        var response = await next();
        logger.LogInformationQueryHandler($"Pipeline is working - Handled {typeof(TRequest).Name}");
        return response;
    }
}
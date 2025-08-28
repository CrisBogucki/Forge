using Forge.Core.Mediator;
using ForgeSampleOffers.App.LogExstensions;
using Microsoft.Extensions.Logging;

namespace ForgeSampleOffers.App.Handlers.Query;

public class SampleQueryHandler(ILogger<SampleQueryHandler> logger) : IRequestHandler<SampleQuery, SampleQueryResult>
{
    public Task<SampleQueryResult> Handle(SampleQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformationQueryHandler("Handler log message");
        return Task.FromResult(new SampleQueryResult("pong"));
    }
}
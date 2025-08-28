using Forge.Core.Mediator;

namespace ForgeSampleOffers.WebApi.Handlers;

public interface IPipelineLoggingBehavior<in TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
{
    Task<TResponse> Handle(
        TRequest request, 
        CancellationToken cancellationToken,
        Func<Task<TResponse>> next);
}

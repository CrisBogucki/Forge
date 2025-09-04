namespace Forge.Core.Mediator;

public interface IPipelineBehavior<in TRequest, TResponse>
{
    Task<string> Handle(TRequest request, CancellationToken cancellationToken, Func<Task<TResponse>> next);
}

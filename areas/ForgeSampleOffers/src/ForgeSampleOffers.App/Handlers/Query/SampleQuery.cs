using Forge.Core.Mediator;

namespace ForgeSampleOffers.App.Handlers.Query;

public record SampleQuery(string Message) : IRequest<SampleQueryResult>;
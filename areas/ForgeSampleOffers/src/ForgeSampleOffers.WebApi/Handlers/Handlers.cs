using Forge.Core.Mediator;
using ForgeSampleOffers.App.Handlers.Query;
using ForgeSampleOffers.App.LogExstensions;

namespace ForgeSampleOffers.WebApi.Handlers;

public static class Handlers
{
    public static async Task Handle(WebApplication app)
    {
        var mediator = app.Services.GetRequiredService<ISender>();

        var requestQuery = new SampleQuery("ping");
        app.Logger.LogInformationQueryHandlerPingMessage(requestQuery.Message); 
        var responseQuery = await mediator.Send(requestQuery);
        app.Logger.LogInformationQueryHandlerPongMessage(responseQuery.Message);
    }
}
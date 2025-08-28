using Forge.Core.Logger.Extensions;
using Forge.Core.Mediator;
using Forge.Core.Mediator.Extensions;
using ForgeSampleOffers.WebApi.Handlers;

namespace ForgeSampleOffers.WebApi;

public static class Startup
{
    public static void ConfigureBuilder(WebApplicationBuilder builder)
    {
        builder.Logging.AddForgeLogger(builder.Configuration);
    }

    public static void ConfigureMiddleware(WebApplication app)
    {
        app.UseHttpsRedirection();
    }

    public static void ConfigureEndpoints(WebApplication app)
    {
        var summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm",
            "Balmy", "Hot", "Sweltering", "Scorching"
        };

        app.MapGet("/weatherforecast", () =>
        {
            var forecast = Enumerable.Range(1, 5).Select(index =>
                    new WeatherForecast
                    (
                        DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                        Random.Shared.Next(-20, 55),
                        summaries[Random.Shared.Next(summaries.Length)]
                    ))
                .ToArray();
            return forecast;
        });
    }

    public static void ConfigureServices(IServiceCollection services, ConfigurationManager configuration)
    {
        services.AddForgeMediator(options =>
        {
            options.AddAssemblies(WebApi.AssemblyInfo.Assembly, App.AssemblyInfo.Assembly);
            options.AddPipelineBehavior(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));
        });
    }
}
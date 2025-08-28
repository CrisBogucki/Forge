using ForgeSampleOffers.WebApi;
using ForgeSampleOffers.WebApi.Handlers;

var builder = WebApplication.CreateBuilder(args);

Startup.ConfigureBuilder(builder);
Startup.ConfigureServices(builder.Services, builder.Configuration);

var app = builder.Build();

Startup.ConfigureMiddleware(app);
Startup.ConfigureEndpoints(app);

Logger.LogStartupMessages(app);
await Handlers.Handle(app);

await app.RunAsync();
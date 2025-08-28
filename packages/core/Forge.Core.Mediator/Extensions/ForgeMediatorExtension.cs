using System.Reflection;
using Forge.Core.Mediator.Abstractions;
using Forge.Core.Mediator.Options;
using Microsoft.Extensions.DependencyInjection;

namespace Forge.Core.Mediator.Extensions;

public static class ForgeMediatorExtension
{
    public static IServiceCollection AddForgeMediator(this IServiceCollection services, Action<MediatorOptions>? configure = null)
    {
        var options = new MediatorOptions();
        configure?.Invoke(options);

        var assemblies = options.Assemblies.Any()
            ? options.Assemblies
            : new List<Assembly> { Assembly.GetCallingAssembly() };

        services.AddScoped<ISender, Sender>();

        foreach (var assembly in assemblies)
        {
            var handlerInterface = typeof(IRequestHandler<,>);
            var handlerTypes = assembly
                .GetTypes()
                .Where(t => !t.IsAbstract && !t.IsInterface)
                .SelectMany(t => t.GetInterfaces()
                    .Where(i => i.IsGenericType && i.GetGenericTypeDefinition() == handlerInterface)
                    .Select(i => new { Interface = i, Implementation = t }));

            foreach (var handler in handlerTypes)
            {
                services.AddScoped(handler.Interface, handler.Implementation);
            }
        }

        foreach (var (serviceType, implementationType) in options.PipelineBehaviors)
        {
            services.AddScoped(serviceType, implementationType);
        }
        
        return services;
    }

    public static IServiceCollection AddPipeline<T>(this IServiceCollection services)
        where T : class
    {
        services.AddScoped(typeof(IPipelineBehavior<,>), typeof(T));
        return services;
    }
}
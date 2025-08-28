# 🚀 Forge.Core.Mediator

[![NuGet](https://img.shields.io/nuget/v/Forge.Core.Mediator.svg)](https://www.nuget.org/packages/Forge.Core.Mediator/)
[![License](https://img.shields.io/badge/license-MIT-blue.svg)](LICENSE)

### 📝 Lightweight Mediator Pattern for .NET

**Forge.Core.Mediator** is a lightweight and flexible implementation of the Mediator pattern for .NET.
It enables easy request/response messaging (`IRequest`) and handler-based processing (`IRequestHandler`),
while supporting **pipeline behaviors** for cross-cutting concerns like logging, validation, and caching.

## ✨ Features

✅ Clean and simple Mediator pattern
✅ Supports `IRequest<T>` and `IRequestHandler<TRequest, TResponse>`
✅ Built-in pipeline behaviors support (logging, validation, caching, etc.)
✅ Automatic handler registration from selected assemblies
✅ Full Dependency Injection (DI) integration
✅ Available as a NuGet package

## 📦 Installation

```sh
# Install via NuGet
Install-Package Forge.Core.Mediator
```

```sh
# Install via .NET CLI
dotnet add package Forge.Core.Mediator
```

## 🚀 Quick Start

```csharp
using Forge.Core.Mediator;
using Microsoft.Extensions.DependencyInjection;

// 1. Define a request
public record GetUserQuery(int Id) : IRequest<User>;

// 2. Implement a handler
public class GetUserQueryHandler : IRequestHandler<GetUserQuery, User>
{
    public Task<User> Handle(GetUserQuery request, CancellationToken cancellationToken)
    {
        return Task.FromResult(new User(request.Id, "John Doe"));
    }
}

// 3. Register Mediator
var services = new ServiceCollection()
    .AddForgeMediator() // automatically registers handlers from calling assembly
    .BuildServiceProvider();

var sender = services.GetRequiredService<ISender>();
var user = await sender.Send(new GetUserQuery(1));
Console.WriteLine(user.Name); // "John Doe"
```

## ⚙️ Pipeline Behaviors

Pipeline behaviors allow you to insert steps before and after the handler execution,
making them ideal for logging, validation, caching, or transaction handling.

### Example:

```csharp
public class LoggingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
{
    public async Task<TResponse> Handle(
        TRequest request, 
        RequestHandlerDelegate<TResponse> next, 
        CancellationToken cancellationToken)
    {
        Console.WriteLine($"Handling {typeof(TRequest).Name}");
        var response = await next();
        Console.WriteLine($"Handled {typeof(TRequest).Name}");
        return response;
    }
}

// Registration
services.AddPipeline<LoggingBehavior<,>>();
```

## 🔗 Dependency Injection (DI)

```csharp
using Forge.Core.Mediator;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection()
    .AddForgeMediator(options =>
    {
        // Specify which assemblies to scan for handlers
        options.TargetAssemblies.Add(typeof(Program).Assembly);

        // Register custom pipeline behaviors
        options.PipelineBehaviors.Add(
            (typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>))
        );
    })
    .BuildServiceProvider();
```

## 📂 Project Structure

* **ISender** – interface for sending requests
* **IRequest / IRequestHandler** – mediator contracts
* **IPipelineBehavior** – interface for pipeline behaviors
* **ForgeMediatorExtension** – DI extensions and configuration

## 📋 Requirements

* **.NET Standard** 2.0+
* **Microsoft.Extensions.DependencyInjection**
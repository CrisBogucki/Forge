# 🚀 Forge.Core.Logger

[![NuGet](https://img.shields.io/nuget/v/Forge.Core.Logger.svg)](https://www.nuget.org/packages/Forge.Core.Logger/)  
[![License](https://img.shields.io/badge/license-MIT-blue.svg)](LICENSE)

### 📝 Minimalist logging wrapper for Serilog

**Forge.Core.Logger** is a lightweight and flexible wrapper around [Serilog](https://serilog.net/) for .NET.  
It provides a simple `ILogger` interface for easy logging integration while allowing full customization of Serilog.

## ✨ Features
✅ Simple and clean `ILogger` interface  
✅ Default console logging  
✅ Fully customizable Serilog configuration  
✅ Built-in Dependency Injection (DI) support  
✅ Available as a NuGet package

## 📦 Installation
```sh
# Install via NuGet
Install-Package Forge.Core.Logger
```
```sh
# Install via .NET CLI
dotnet add package Forge.Core.Logger
```

🚀 Quick Start
```csharp
using Forge.Core.Logger;

class Program
{
    static void Main()
    {
        ILogger logger = new Logger();
        logger.LogInformation("Application started.");
        logger.LogWarning("This is a warning.");
        logger.LogError("An error occurred!", new Exception("Sample exception"));
    }
}
```

⚙️ Custom Configuration
```csharp
using Forge.Core.Logger;
using Serilog;

class Program
{
    static void Main()
    {
        var config = new LoggerConfiguration()
            .MinimumLevel.Debug()
            .WriteTo.Console()
            .WriteTo.File("logs/app.log");

        ILogger logger = new Logger(config);
        logger.LogInformation("Logging with custom configuration.");
    }
}
```

🔗 Dependency Injection (DI)
```csharp
using Forge.Core.Logger.Extensions;
using Microsoft.Extensions.DependencyInjection;

class Program
{
    static void Main()
    {
        var services = new ServiceCollection()
            .AddForgeLogger()
            .BuildServiceProvider();

        var logger = services.GetRequiredService<ILogger>();
        logger.LogInformation("Hello from DI!");
    }
}
```

📌 With custom configuration:

```csharp
    var services = new ServiceCollection()
    .AddForgeLogger(config => 
        config.MinimumLevel.Information()
              .WriteTo.Console()
              .WriteTo.File("logs/app.log"))
    .BuildServiceProvider();    
```


## 📂 Project Structure
 - **ILogger** – logging interface
 - **Logger** – Serilog-based implementation
 - **ServiceCollectionExtensions** – DI extensions

## 📋 Requirements
- **.NET Standard** 2.0+
- **Serilog** >= 4.2.0
- **Serilog.Sinks.Console** >= 6.0.0
- (Optional) **Microsoft.Extensions.DependencyInjection**

## 🙌 Acknowledgments
Special thanks to Serilog for providing a great logging framework!


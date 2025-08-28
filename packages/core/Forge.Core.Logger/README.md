# 🚀 Forge.Core.Logger

[![NuGet](https://img.shields.io/nuget/v/Forge.Core.Logger.svg)](https://www.nuget.org/packages/Forge.Core.Logger/)  
[![License](https://img.shields.io/badge/license-MIT-blue.svg)](LICENSE)

### 📝 Lightweight logging library for .NET

**Forge.Core.Logger** is a lightweight, flexible logging library for .NET.  
It provides a simple `ILogger` interface, **colorful console logging**, timestamped messages, and seamless integration with **Dependency Injection (DI)**.

---

## ✨ Features

- ✅ Simple and clean `ILogger` interface  
- ✅ Console sink with configurable timestamp and colors  
- ✅ Fully configurable logging options (minimum level, templates, sinks)  
- ✅ Integrates with `Microsoft.Extensions.Logging`  
- ✅ Available as a NuGet package  

---

## 📦 Installation

```bash
# Install via NuGet
Install-Package Forge.Core.Logger
````

```bash
# Install via .NET CLI
dotnet add package Forge.Core.Logger
```

---

## 🚀 Quick Start

```csharp
public static void ConfigureBuilder(WebApplicationBuilder builder)
{
    builder.Logging.AddForgeLogger(builder.Configuration);
}
```

---

## ⚙️ Custom Configuration

You can configure:

* **Minimum log level**
* **Multiple sinks**
* **Timestamp format**
* **Message template**

```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Trace",
      "Microsoft.AspNetCore": "Information"
    },
    "ForgeLogger": {
      "Sinks": {
        "Console": {
          "UseColors": true,
          "TimestampFormat": "HH:mm:ss",
          "Template": "{Timestamp} [{Level}] {Message}",
          "ShortenLevel": true
        }
      }
    }
  }
}
```

---

## 📋 Requirements

* **.NET Standard 2.0+**
* (Optional) **Microsoft.Extensions.DependencyInjection**

# 🚀 Forge - A .NET Demonstration Project

Forge is a demonstration project showcasing best practices and architectural approaches in .NET.  
It serves as a sandbox for implementing and testing various techniques, patterns, and technologies used in modern .NET development.


## ✨ Goals & Key Features
✅ Exploring clean and modular .NET architectures  
✅ Implementing best practices for maintainability and scalability  
✅ Demonstrating Dependency Injection (DI) and IoC containers  
✅ Showcasing logging strategies with Serilog (Forge.Logger)  
✅ Working with ASP.NET Core and .NET API design  
✅ Applying CQRS, Mediator, and Domain-Driven Design (DDD) principles  
✅ Automated builds, testing, and CI/CD pipeline integration


## 🏗️ Technologies & Tools

Forge leverages modern .NET technologies and best practices, including:

🚀 **.NET 8** – Latest runtime for high-performance applications  
🌐 **ASP.NET Core** – Web API development with modularity and performance in mind  
🗃️ **Entity Framework Core** – ORM for data access and migrations  
📜 **Serilog** – Structured logging with support for various sinks  
🎯 **MediatR** – Implementation of the Mediator pattern for clean architecture  
✅ **FluentValidation** – Model validation using expressive rules  
📖 **Swagger (Swashbuckle)** – API documentation for better usability  
🧪 **xUnit & Moq** – Unit testing framework and mocking library


## 📂 Project Structure
The project follows a modular architecture for maintainability and scalability:
```
Forge  
├── areas                                  # Forge areas for modular components  
│   └── ForgeSampleOffers                  # Sample component for testing solutions  
│       ├── Directory.Build.props          # MSBuild properties for the component  
│       ├── ForgeSampleOffers.App          # Application project for the component  
│       ├── ForgeSampleOffers.Deployment   # Deployment project for the component  
│       ├── ForgeSampleOffers.Domain       # Domain project for the component  
│       ├── ForgeSampleOffers.E2eTests     # End-to-end tests project for the component  
│       ├── ForgeSampleOffers.IntegrationTests # Integration tests project for the component  
│       ├── ForgeSampleOffers.Tests        # Unit tests project for the component  
│       └── ForgeSampleOffers.WebApi       # Web API project for the component  
├── packages                               # Forge core packages  
│   └── core/  
│       ├── Forge.Core.Logger/             # Forge core logger package  
│       └── Forge.Core.Mediator/           # Forge core mediator package  
├── scripts                                # Build and deployment scripts  
│   ├── areas/                             # Scripts related to areas  
│   ├── packages/                          # Scripts for package management  
│   │   ├── build.sh                       # NuGet package script for build, pack, publish, and clean  
│   │   ├── config.yaml                    # Build script configuration  
│   │   └── README.md                      # Script documentation  
│   └── output/                            # Temp build NuGet package output  
└── README.md                              # Project documentation  
```  

## 🚀 Getting Started
To run the project locally, follow these steps:
1. **Clone the repository:**
   ```sh
    git clone https://github.com/CrisBogucki/Forge.git  
    cd Forge  
   ```  
2. **Nuget build dependencies:**`
   ```sh
    ./scripts/packages/build.sh  build
   ```  
3. **Nuget pack dependencies:**`
   ```sh
    ./scripts/packages/build.sh  pack
   ``` 
4. **Nuget publish dependencies:**`
   ```sh
    ./scripts/packages/build.sh  publish
   ```  
5. **Build the application:**
   ```sh
      dotnet build ./areas/ForgeSampleOffers/ForgeSampleOffers.WebApi/ForgeSampleOffers.WebApi.csproj  
   ```  
6. **Run the application:**
   ```sh
    dotnet run --project ./areas/ForgeSampleOffers/ForgeSampleOffers.WebApi/ForgeSampleOffers.WebApi.csproj  
   ```
7. **Access the API:**
    - Open Swagger UI at: `http://localhost:5000/swagger`
    - Use Postman or another client to test the API

## 🛠️ Contributing
Contributions, issues, and feature requests are welcome! Feel free to fork the repository, create a new branch, and submit a pull request.

## 📜 License
This project is licensed under the MIT License.

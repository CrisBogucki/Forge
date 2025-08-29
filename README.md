# 🔥 Forge – Modular .NET Demonstration Project

Forge is a **.NET sandbox project** focused on modular architecture, scalability, and maintainability.  
It provides a foundation for exploring clean architecture principles and building reusable components for modern .NET applications.


---

## ✨ Key Features

- 🧩 **Modular and extensible architecture**
- 🌐 **Sample Web API implementation**
- 📦 **Reusable core libraries**
- 🧪 **Unit, integration, and end-to-end tests**
- ⚙️ **Automated build and packaging scripts**
- 📜 **Swagger-based API documentation**

---

## 🚀 Getting Started

1. **Clone the repository:**
    ```bash
    git clone https://github.com/CrisBogucki/Forge.git
    cd Forge
    ```

2. **Build the packages:**
    ```bash
    ./scripts/packages/build.sh build
    ```

3. **Pack the packages:**
    ```bash
    ./scripts/packages/build.sh pack
    ```

4. **(Optional) Publish packages:**
    ```bash
    ./scripts/packages/build.sh publish
    ```

5. **Build and run the sample Web API:**
    ```bash
    dotnet build ./areas/ForgeSampleOffers/ForgeSampleOffers.WebApi/ForgeSampleOffers.WebApi.csproj
    dotnet run --project ./areas/ForgeSampleOffers/ForgeSampleOffers.WebApi/ForgeSampleOffers.WebApi.csproj
    ```

6. **Access the Swagger UI:**
    ```
    http://localhost:5000/swagger
    ```

---

## 🤝 Contributing

Contributions, ideas, and feature requests are welcome!  
- Fork the repository  
- Create a new feature branch  
- Submit a pull request  

---

## 📄 License

Licensed under the **MIT License**.

---

## 🧭 About

Forge is an **experimental platform** for:  
- designing modular .NET applications  
- developing reusable NuGet packages  
- testing clean architecture principles  
- building and automating CI/CD pipelines
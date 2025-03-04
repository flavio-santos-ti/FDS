# FDS .NET Core Libraries

![.NET Core](https://img.shields.io/badge/.NET%20Core-8.0-blueviolet?style=flat&logo=dotnet) 
![NuGet ApiResponse](https://img.shields.io/nuget/v/Flavio.Santos.NetCore.ApiResponse?label=NuGet%20ApiResponse) 
![NuGet UuidV7](https://img.shields.io/nuget/v/Flavio.Santos.UuidV7.NetCore?label=NuGet%20UuidV7)  

This repository contains various .NET libraries developed to improve performance, security, and maintainability in .NET applications.

## 📦 FDS.UuidV7.NetCore

🚀 **FDS.UuidV7.NetCore** is a .NET library that provides efficient and seamless UUID v7 generation.

### 📌 Features
✅ **UUID v7** generation (timestamp-based).  
✅ Fully compatible with **.NET 8**.  
✅ Easy integration with **ASP.NET Core, Console, and APIs**.  
✅ No external dependencies.  


### 🛠 Installation

You can install the package directly via NuGet:

```sh
dotnet add package Flavio.Santos.UuidV7.NetCore
```

Or via Visual Studio Package Manager:

1. Open the **NuGet Package Manager**.
2. Search for **Flavio.Santos.UuidV7.NetCore**.
3. Install the package into your project.

### 🚀 Usage

```csharp
using System;
using Flavio.Santos.UuidV7.NetCore;

class Program
{
    static void Main()
    {
        Guid newUuid = UuidV7.Generate();
        Console.WriteLine($"Generated UUID v7: {newUuid}");
    }
}
```

## 📦 FDS.NetCore.ApiResponse

🚀 **FDS.NetCore.ApiResponse** is a .NET library designed to standardize API responses, ensuring consistency and maintainability in .NET applications.

### 📌 Features
✅ **Encapsulated API response model** for structured handling.  
✅ Supports **success and error responses** with clear messaging.  
✅ Built-in **action types** for standardized response categorization.  
✅ **JSON serialization** with automatic configurations.  
✅ Fully compatible with **.NET 8**.  

### 🛠 Installation

You can install the package directly via NuGet:

```sh
dotnet add package Flavio.Santos.NetCore.ApiResponse
```

Or via Visual Studio Package Manager:

1. Open the **NuGet Package Manager**.
2. Search for **Flavio.Santos.NetCore.ApiResponse**.
3. Install the package into your project.

### 🚀 Usage

#### 1️⃣ Creating a Standard API Response

```csharp
using FDS.NetCore.ApiResponse.Models;
using FDS.NetCore.ApiResponse.Results;
using FDS.NetCore.ApiResponse.Types;

public class ClientService : IClientService
{
    private readonly IClientRepository _clientRepository;

    public ClientService(IClientRepository clientRepository)
    {
        _clientRepository = clientRepository;
    }

    public async Task<Response<ClientDto>> AddAsync(ClientRequestDto request)
    {
        if (await _clientRepository.ExistsByNameAsync(request.Name))
        {
            return Result.Create<ClientDto>(
                ActionType.VALIDATION_ERROR,
                "A client with this name already exists."
            );
        }

        var client = new Client(Guid.NewGuid(), request.Name);
        await _clientRepository.AddAsync(client);
        var clientDto = new ClientDto { Id = client.Id, Name = client.Name };

        return Result.Create(ActionType.CREATE, "Client created successfully.", clientDto);
    }
}
```

#### 2️⃣ Handling Different Response Types

```csharp
var successResponse = Result.Create<bool>(ActionType.READ, "Data retrieved successfully.", new { Value = 42 });

var notFoundResponse = Result.Create<object>(ActionType.NOT_FOUND, "Resource not found.");

var errorResponse = Result.Create<object>(ActionType.ERROR, "An unexpected error occurred.");

return Result.Create(ActionType.CREATE, "Client created successfully.", clientDto);
```

### 📜 Example Response Format

```json
{
    "isSuccess": true,
    "message": "Client created successfully.",
    "statusCode": 201,
    "data": {
        "id": "43589501-c92a-4f73-9d1f-06101bbd579b",
        "name": "Pessoal"
    }
}
```

```json
{
    "isSuccess": false,
    "message": "A client with this name already exists.",
    "statusCode": 400
}
```

## 🔗 Author & Contact

📌 **Developed by:** [Flavio dos Santos](https://www.linkedin.com/in/flavio-santos-ti/)  
📌 **NuGet Packages:**  
&nbsp;&nbsp;&nbsp;&nbsp;🔹 `Flavio.Santos.NetCore.ApiResponse`  
&nbsp;&nbsp;&nbsp;&nbsp;🔹 `FDS.UuidV7.NetCore`

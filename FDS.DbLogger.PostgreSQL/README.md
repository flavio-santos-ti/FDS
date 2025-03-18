# FDS.DBLogger.PostgreSQL

🚀 **FDS.DBLogger.PostgreSQL** is a robust .NET library for structured **audit logging** in PostgreSQL, designed to track and log application events efficiently.

[![NuGet](https://img.shields.io/nuget/v/Flavio.Santos.UuidV7.NetCore.svg)](https://www.nuget.org/packages/Flavio.Santos.UuidV7.NetCore/)
[![NuGet Downloads](https://img.shields.io/nuget/dt/Flavio.Santos.UuidV7.NetCore.svg)](https://www.nuget.org/packages/Flavio.Santos.UuidV7.NetCore/)
[![License](https://img.shields.io/badge/license-MIT-blue.svg)](LICENSE)
![.NET Core](https://img.shields.io/badge/.NET%20Core-8.0-blue?logo=dotnet)

## 📦 Installation

You can install this package via **NuGet Package Manager**:

```sh
dotnet add package Flavio.Santos.DBLogger.PostgreSQL --version 1.0.0
```

Or using Package Manager Console:

```powershell
Install-Package Flavio.Santos.DBLogger.PostgreSQL -Version 1.0.0
```

## 🚀 Usage

### **Logging a Create Event**
Use `LogCreateAsync()` to log the creation of an entity, capturing relevant request and response data.

#### **Example: Logging Client Creation in `ClientService`**
```csharp
public async Task<Response<ClientDto>> AddAsync(ClientRequestDto request)
{
    try
    {
        if (await _clientRepository.ExistsByNameAsync(request.Name))
        {
            return Result.CreateValidationError<ClientDto>("A client with this name already exists.");
        }

        var client = new Client(Guid.NewGuid(), request.Name);
        await _clientRepository.AddAsync(client);
        var clientDto = new ClientDto { Id = client.Id, Name = client.Name };

        string msg = "Client created successfully.";
        await _auditLogService.LogCreateAsync(msg, request, clientDto);

        return Result.CreateSuccess(msg, clientDto);
    }
    catch (Exception ex)
    {
        return Result.CreateError<ClientDto>($"An unexpected error occurred: {ex.Message}");
    }
}
```

## 🎯 Features

- Standardized API response format  
- Built-in status codes and messages  
- Easy integration with Clean Architecture  
- Fully compatible with **.NET 8**  

## 📜 License

This project is licensed under the MIT License - see the LICENSE file for details.

## 🔗 Links

- [NuGet Package: Flavio.Santos.NetCore.ApiResponse](https://www.nuget.org/packages/Flavio.Santos.NetCore.ApiResponse/)  
- [Author LinkedIn: Flavio Santos](https://www.linkedin.com/in/flavio-santos-ti/)

### 🔙 [Back to Main README](../README.md)

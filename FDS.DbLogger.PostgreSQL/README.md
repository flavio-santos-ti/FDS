# FDS.NetCore.ApiResponse

🚀 **FDS.UuidV7.NetCore** is a lightweight .NET library for generating **UUID v7** (time-based UUIDs) according to the official specification.

[![NuGet](https://img.shields.io/nuget/v/Flavio.Santos.UuidV7.NetCore.svg)](https://www.nuget.org/packages/Flavio.Santos.UuidV7.NetCore/)
[![NuGet Downloads](https://img.shields.io/nuget/dt/Flavio.Santos.UuidV7.NetCore.svg)](https://www.nuget.org/packages/Flavio.Santos.UuidV7.NetCore/)
[![License](https://img.shields.io/badge/license-MIT-blue.svg)](LICENSE)
![.NET Core](https://img.shields.io/badge/.NET%20Core-8.0-blue?logo=dotnet)

## 📦 Installation

You can install this package via **NuGet Package Manager**:

```sh
dotnet add package Flavio.Santos.NetCore.ApiResponse --version 1.0.2
```

Or using Package Manager Console:

```powershell
Install-Package Flavio.Santos.NetCore.ApiResponse -Version 1.0.2
```

## 🚀 Usage

### Creating a Standard API Response

#### Adding a New Client
```csharp
public async Task<Response<ClientDto>> AddAsync(ClientRequestDto request)
{
    if (await _clientRepository.ExistsByNameAsync(request.Name))
    {
        return Result.Create<ClientDto>(
            actionType: ActionType.VALIDATION_ERROR,
            message: "A client with this name already exists."
        );
    }

    var client = new Client(Guid.NewGuid(), request.Name);
    await _clientRepository.AddAsync(client);
    var clientDto = new ClientDto { Id = client.Id, Name = client.Name };

    return Result.Create(
        actionType: ActionType.CREATE,
        message: "Client created successfully.",
        data: clientDto
    );
}
```

#### Deleting a Client
```csharp
public async Task<Response<bool>> DeleteAsync(Guid id)
{
    var client = await _clientRepository.GetByIdAsync(id);

    if (client is null)
    {
        return Result.Create<bool>(
            actionType: ActionType.NOT_FOUND,
            message: "Client not found."
        );
    }

    await _clientRepository.DeleteAsync(id);

    return Result.Create<bool>(
        actionType: ActionType.DELETE,
        message: "Client deleted successfully."
    );
}
```

## 📌 Output Example

#### Client Not Found (404)
```json
{
  "isSuccess": false,
  "message": "Client not found.",
  "statusCode": 404
}
```

#### Client Created Successfully (201)
```json
{
  "isSuccess": true,
  "message": "Client created successfully.",
  "statusCode": 201,
  "data": {
    "id": "bf5d9501-032f-447b-bfaf-8cc4fff19e61",
    "name": "Teste"
  }
}
```

#### Client Already Exists (400)
```json
{
  "isSuccess": false,
  "message": "A client with this name already exists.",
  "statusCode": 400
}
```

#### Client Deleted Successfully (200)
```json
{
  "isSuccess": true,
  "message": "Client deleted successfully.",
  "statusCode": 200
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

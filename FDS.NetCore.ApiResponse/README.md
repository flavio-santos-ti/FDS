# FDS.NetCore.ApiResponse

🚀 **FDS.UuidV7.NetCore** is a lightweight .NET library for generating **UUID v7** (time-based UUIDs) according to the official specification.

[![NuGet](https://img.shields.io/nuget/v/Flavio.Santos.NetCore.ApiResponse.svg)](https://www.nuget.org/packages/Flavio.Santos.NetCore.ApiResponse/)
[![NuGet Downloads](https://img.shields.io/nuget/dt/Flavio.Santos.NetCore.ApiResponse.svg)](https://www.nuget.org/packages/Flavio.Santos.NetCore.ApiResponse/)
[![License](https://img.shields.io/badge/license-MIT-blue.svg)](LICENSE)
![.NET Core](https://img.shields.io/badge/.NET%20Core-8.0-blue?logo=dotnet)

## 📦 Installation

You can install this package via **NuGet Package Manager**:

```sh
dotnet add package Flavio.Santos.NetCore.ApiResponse --version 1.0.15
```

Or using Package Manager Console:

```powershell
Install-Package Flavio.Santos.NetCore.ApiResponse -Version 1.0.15
```

## 🚀 Usage

### Creating a Standard API Response

#### Adding a New Client
```csharp
public async Task<Response<ClientDto>> AddAsync(ClientRequestDto request)
{
    // Here I implement the update logic.

    return Result.CreateAdd(msg, clientDto);
}
```

#### Deleting a Client
```csharp
public async Task<Response<bool>> DeleteAsync(Guid id)
{
    // Here I implement the update logic.

    return Result.CreateRemove<bool>(msg);
}
```

#### Updating  a Client
```csharp
public async Task<Response<ClientDto>> UpdateAsync(ClientDto request)
{
    // Here I implement the update logic.
    
    return Result.CreateUpdate(updatedClientDto);   
}
```

### Retrieving All Clients
```csharp
public async Task<Response<IEnumerable<ClientDto>>> GetAllAsync()
{
    // Here I implement the update logic.
    
    return Result.CreateGet<IEnumerable<ClientDto>>(msg, clientDtos);
}
```

###  Handling Not Found (404)
```csharp
public async Task<Response<ClientDto>> GetByIdAsync(Guid id)
{
    var client = await _repository.FindByIdAsync(id);

    if (client is null)
        return Result.CreateNotFound<ClientDto>("Client not found.");

    return Result.CreateGet("Client found.", client);
}
```

### Handling Validation Errors (400)
```csharp
public async Task<Response<ClientDto>> AddAsync(ClientRequestDto request)
{
    if (string.IsNullOrWhiteSpace(request.Name))
        return Result.CreateValidationError<ClientDto>("Client name is required.");

    // Continuação do fluxo normal se for válido
    var newClient = new ClientDto { Name = request.Name };
    
    return Result.CreateAdd("Client created successfully.", newClient);
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

### [← Back to Main Project](https://github.com/flavio-santos-ti/FDS)

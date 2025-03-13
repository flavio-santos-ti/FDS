# FDS.FDS.RequestTracking

🚀 **FDS.RequestTracking** is a lightweight .NET library for tracking and logging **HTTP requests**, providing an isolated and configurable context for auditing, debugging, and monitoring application requests.

[![NuGet](https://img.shields.io/nuget/v/Flavio.Santos.RequestTracking.svg)](https://www.nuget.org/packages/Flavio.Santos.RequestTracking/)
[![NuGet Downloads](https://img.shields.io/nuget/dt/Flavio.Santos.RequestTracking.svg)](https://www.nuget.org/packages/Flavio.Santos.RequestTracking/)
[![License](https://img.shields.io/badge/license-MIT-blue.svg)](LICENSE)
![.NET Core](https://img.shields.io/badge/.NET%20Core-8.0-blue?logo=dotnet)

## 📦 Installation

You can install this package via **NuGet Package Manager**:

```sh
dotnet add package Flavio.Santos.RequestTracking --version 1.0.0
```

Or using Package Manager Console:

```powershell
Install-Package Flavio.Santos.RequestTracking -Version 1.0.0
```

## 🚀 Usage

### Registering Request Tracking in the Dependency Injection Container

To enable request tracking, add the following extension method in your `Startup.cs` or `Program.cs`:

```csharp
using FDS.RequestTracking.Extensions;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRequestTracking();
```

### Applying Request Tracking to Controllers

Once registered, the `RequestDataFilter` will automatically log HTTP request details.

```csharp
[ServiceFilter(typeof(RequestDataFilter))]
[ApiController]
[Route("api/[controller]")]
public class SampleController : ControllerBase
{
    [HttpGet("track")]
    public IActionResult GetTrackedRequest()
    {
        return Ok("Request is being tracked.");
    }
}
```

### Retrieving Logged Request Data

The tracked request data can be retrieved using `RequestDataStorage`:

```csharp
var requestData = RequestDataStorage.GetData(requestId);
if (requestData != null)
{
    Console.WriteLine($"Tracked Request: {requestData.Method} {requestData.Path}");
}
```

### Using Request Tracking in a Service Layer

Here is an example of how you can integrate **Request Tracking** in a service layer following Clean Architecture principles:

```csharp
using BaseHours.Application.Dtos;
using BaseHours.Application.Interfaces;
using BaseHours.Domain.Entities;
using BaseHours.Domain.Interfaces;
using FDS.DbLogger.PostgreSQL.Published;
using FDS.NetCore.ApiResponse.Models;
using FDS.NetCore.ApiResponse.Results;
using FDS.NetCore.ApiResponse.Types;
using FDS.RequestTracking.Storage;
using Microsoft.AspNetCore.Http;

public class ClientService : IClientService
{
    private readonly IClientRepository _clientRepository;
    private readonly IAuditLogService _auditLogService;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public ClientService(IClientRepository clientRepository, IAuditLogService auditLogService, IHttpContextAccessor httpContextAccessor)
    {
        _clientRepository = clientRepository;
        _auditLogService = auditLogService;
        _httpContextAccessor = httpContextAccessor;
    }

    public async Task<Response<ClientDto>> AddAsync(ClientRequestDto request)
    {
        try
        {
            var requestId = _httpContextAccessor.HttpContext?.TraceIdentifier;

            if (!string.IsNullOrEmpty(requestId))
            {
                var requestData = RequestDataStorage.GetData(requestId);
                if (requestData is not null)
                {
                    await _auditLogService.LogInfoAsync($"Request Data - {requestData.Method} {requestData.Path}{requestData.QueryParams} - {requestData.Timestamp}");
                    RequestDataStorage.ClearData(requestId);
                }
            }

            if (await _clientRepository.ExistsByNameAsync(request.Name))
            {
                string msg = "A client with this name already exists.";
                await _auditLogService.LogValidationErrorAsync(msg, request);
                return Result.Create<ClientDto>(
                    actionType: ActionType.VALIDATION_ERROR,
                    message: msg
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
        catch (Exception ex)
        {
            return Result.Create<ClientDto>(
                actionType: ActionType.ERROR,
                message: $"An unexpected error occurred: {ex.Message}"
            );
        }
    }
}
```

## 📌 Output Example

### Example Logged Request Data
```json
{
  "requestId": "abc123",
  "method": "GET",
  "path": "/api/sample/track",
  "queryParams": "?filter=test",
  "timestamp": "2024-03-12T14:30:00Z"
}
```

## 🎯 Features

- Lightweight and easy-to-integrate request tracking
- Structured logging for HTTP requests
- Works seamlessly with Clean Architecture and SOLID principles
- Provides an audit log for debugging and monitoring
- Built-in request data storage for easy retrieval
- Fully compatible with **.NET 8**

## 📜 License

This project is licensed under the MIT License - see the LICENSE file for details.

## 🔗 Links

- [NuGet Package: FDS.RequestTracking](https://www.nuget.org/packages/FDS.RequestTracking/)
- [Author LinkedIn](https://www.linkedin.com/in/flavio-santos-ti/)

### 🔙 [Back to Main README](../README.md)


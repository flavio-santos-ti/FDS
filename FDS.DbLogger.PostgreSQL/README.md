# FDS.DBLogger.PostgreSQL

🚀 **FDS.DBLogger.PostgreSQL** is a robust .NET library for structured **audit logging** in PostgreSQL, designed to track and log application events efficiently.

[![NuGet](https://img.shields.io/nuget/v/Flavio.Santos.DbLogger.PostgreSQL.svg)](https://www.nuget.org/packages/Flavio.Santos.DbLogger.PostgreSQL/)
[![NuGet Downloads](https://img.shields.io/nuget/dt/Flavio.Santos.DbLogger.PostgreSQL.svg)](https://www.nuget.org/packages/Flavio.Santos.DbLogger.PostgreSQL/)
[![License](https://img.shields.io/badge/license-MIT-blue.svg)](LICENSE)
![.NET Core](https://img.shields.io/badge/.NET%20Core-8.0-blue?logo=dotnet)

## 📦 Installation

You can install this package via **NuGet Package Manager**:

```sh
dotnet add package Flavio.Santos.DBLogger.PostgreSQL --version 1.0.2
```

Or using Package Manager Console:

```powershell
Install-Package Flavio.Santos.DBLogger.PostgreSQL -Version 1.0.2
```

## 📂 Database Schema

The `audit_logs` table stores all audit log entries in a structured format in a PostgreSQL database.

### **Table Structure: `audit_logs`**

```sql
CREATE TABLE audit_logs (
    id UUID PRIMARY KEY,
    event_timestamp_local TIMESTAMP WITHOUT TIME ZONE,
    event_timestamp_utc TIMESTAMP WITH TIME ZONE,
    event_action VARCHAR(255) NOT NULL,
    context_name VARCHAR(255) NOT NULL,
    trace_identifier VARCHAR(50),
    http_method VARCHAR(10) NOT NULL, 
    request_path VARCHAR(500),
    http_status_code INTEGER,
    event_message TEXT,
    request_data JSONB, 
    response_data JSONB,
    user_id UUID
);

CREATE INDEX idx_audit_logs_user_id ON audit_logs (user_id);
```
## Grid Database

![Grid Database](https://raw.githubusercontent.com/flavio-santos-ti/FDS/main/FDS.DbLogger.PostgreSQL/Assets/grid-database.png)

## 🚀 Usage

### **Logging a Create Event**
Use `LogCreateAsync()` to log the creation of an entity, capturing relevant request and response data.

#### **Example: Logging Client Creation in `ClientService`**
```csharp
using FDS.DbLogger.PostgreSQL.Published;

public async Task<Response<ClientDto>> AddAsync(ClientRequestDto request)
{
    string requestId = string.Empty;
    string msg = string.Empty;
    try
    {
        requestId = await _auditLogService.LogInfoAsync("[START] - Client creation process started.", request);

        msg = await _clientRepository.ExistsByNameAsync(request.Name);

        if (!string.IsNullOrEmpty(msg))
        {
            await _auditLogService.LogValidationErrorAsync(msg, request);
            return Result.CreateValidationError<ClientDto>(msg);
        }

        var client = new Client(request.Name);
        msg = await _clientRepository.AddAsync(client);
        var clientDto = new ClientDto { Id = client.Id, Name = client.Name };

        await _auditLogService.LogCreateAsync(msg, request, clientDto);

        return Result.CreateAdd(msg, clientDto);
    }
    catch (Exception ex)
    {
        msg = $"An unexpected error occurred: {ex.Message}";
        await _auditLogService.LogErrorAsync(msg);
        return Result.CreateError<ClientDto>(msg);
    }
    finally
    {
        msg = "Client creation process completed.";
        await _auditLogService.LogEndAsync(msg);
        RequestDataStorage.ClearData(requestId);
    }
}
```

## 🎯 Features

- **Structured Audit Logging**: Capture and store structured logs for every important action in your system.
- **Standardized API Response Format**: Ensures consistency in API responses with built-in status codes and messages.
- **Integration with Clean Architecture**: Designed to fit into modern, well-structured .NET applications.
- **Event Categorization**: Supports multiple log action types (`CREATE`, `DELETE`, `UPDATE`, `ERROR`, etc.).
- **Seamless Database Persistence**: Logs are stored in PostgreSQL using `Entity Framework Core`.
- **Asynchronous Logging**: Uses async methods like `LogCreateAsync()` to avoid blocking API execution.
- **Automatic Timestamping**: All log entries include precise timestamps for accurate tracking.
- **Easy Querying & Analysis**: Leverage PostgreSQL’s powerful querying capabilities to analyze logs efficiently.
- **Compatible with .NET 8**: Fully tested and optimized for the latest .NET version.

## 📜 License

This project is licensed under the MIT License - see the LICENSE file for details.

## 🔗 Links

- [NuGet Package: Flavio.Santos.NetCore.ApiResponse](https://www.nuget.org/packages/Flavio.Santos.NetCore.ApiResponse/)  
- [Author LinkedIn: Flavio Santos](https://www.linkedin.com/in/flavio-santos-ti/)

### [← Back to Main Project](https://github.com/flavio-santos-ti/FDS)

# FDS.UuidV7.NetCore

🚀 **FDS.UuidV7.NetCore** is a lightweight .NET library for generating **UUID v7** (time-based UUIDs) according to the official specification.

[![NuGet](https://img.shields.io/nuget/v/Flavio.Santos.UuidV7.NetCore.svg)](https://www.nuget.org/packages/Flavio.Santos.UuidV7.NetCore/)
[![NuGet Downloads](https://img.shields.io/nuget/dt/Flavio.Santos.UuidV7.NetCore.svg)](https://www.nuget.org/packages/Flavio.Santos.UuidV7.NetCore/)
[![License](https://img.shields.io/badge/license-MIT-blue.svg)](LICENSE)

## 📦 Installation

You can install this package via **NuGet Package Manager**:

```sh
dotnet add package Flavio.Santos.UuidV7.NetCore --version 1.0.3
```

Or using Package Manager Console:

```powershell
Install-Package Flavio.Santos.UuidV7.NetCore -Version 1.0.3
```

## 🚀 Usage

Generating a UUID v7 is simple:

```csharp
using FDS.UuidV7.NetCore;

Guid uuidV7 = UuidV7.Generate();
Console.WriteLine(uuidV7);
```

## 📝 Output Example:

```sh
018d3f29-8c6f-7123-bf0e-365bfae8b45f
```

## 🎯 Features

✅ Generates UUID v7 based on the official specification
✅ Fully compatible with .NET 6+ and .NET 8
✅ No dependencies, lightweight and fast

📜 License

This project is licensed under the MIT License - see the LICENSE file for details.

## 🔗 Links

-🔹 NuGet Package: Flavio.Santos.UuidV7.NetCore
-🔹 Author LinkedIn: Flavio Santos

### 🔙 [Back to Main README](../../README.md)

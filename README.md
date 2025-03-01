# FDS .NET Core Libraries

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

Open the NuGet Package Manager.
Search for Flavio.Santos.UuidV7.NetCore.
Install the package into your project.


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

1. Open the **NuGet Package Manager**.
2. Search for **Flavio.Santos.UuidV7.NetCore**.
3. Install the package into your project.


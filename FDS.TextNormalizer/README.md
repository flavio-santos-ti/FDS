# FDS.TextNormalizer

A lightweight C# library for text normalization.  
Removes diacritics (accents), trims whitespace, and converts text to uppercase invariant — ideal for standardizing input data before processing, searching, or indexing.

[![NuGet](https://img.shields.io/nuget/v/Flavio.Santos.TextNormalizer.svg)](https://www.nuget.org/packages/Flavio.Santos.TextNormalizer/)
[![NuGet Downloads](https://img.shields.io/nuget/dt/Flavio.Santos.TextNormalizer.svg)](https://www.nuget.org/packages/Flavio.Santos.TextNormalizer/)
[![License](https://img.shields.io/badge/license-MIT-blue.svg)](LICENSE)
![.NET Core](https://img.shields.io/badge/.NET%20Core-8.0-blue?logo=dotnet)

## 📦 Installation

You can install this package via **NuGet Package Manager**:

```sh
dotnet add package Flavio.Santos.TextNormalizer --version 1.0.5
```

Or using Package Manager Console:

```powershell
Install-Package Flavio.Santos.TextNormalizer -Version 1.0.5
```

## 🧪 Usage

```csharp
using TextNormalizer;

string input = " João da Silva ";
string normalized = Normalizer.Normalize(input);

// Output: "JOAO DA SILVA"
Console.WriteLine(normalized);
```

---

## ✨ Features

- Removes accents (e.g. "ação" → "ACAO")
- Trims leading and trailing whitespace
- Converts text to uppercase using culture-invariant rules
- Simple and dependency-free

---

## 📦 Installation

Install via NuGet Package Manager:


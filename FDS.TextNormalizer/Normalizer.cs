using System.Globalization;
using System.Text;

namespace TextNormalizer;

/// <summary>
/// Provides utilities to normalize text input by applying
/// transformations such as diacritic removal and case conversion.
///
/// Fornece utilitários para normalizar texto, aplicando
/// transformações como remoção de acentuação e conversão de maiúsculas.
/// </summary>
public static class Normalizer
{
    /// <summary>
    /// Normalizes the input string by removing diacritics,
    /// trimming, and converting to uppercase invariant.
    ///
    /// Normaliza a string removendo acentuação,
    /// espaços excedentes e convertendo para maiúsculas.
    /// </summary>
    public static string Normalize(string input)
    {
        if (string.IsNullOrWhiteSpace(input))
            return string.Empty;

        string normalizedFormD = input.Normalize(NormalizationForm.FormD);
        var sb = new StringBuilder();

        foreach (char c in normalizedFormD)
        {
            if (CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)
                sb.Append(c);
        }

        return sb.ToString()
            .Normalize(NormalizationForm.FormC)
            .Trim()
            .ToUpperInvariant();
    }
}

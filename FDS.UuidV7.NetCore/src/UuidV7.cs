using System;
using System.Security.Cryptography;

namespace FDS.UuidV7.NetCore;

/// <summary>
/// Provides methods to generate UUID v7 (time-based) according to the UUIDv7 specification.
/// </summary>
public static class UuidV7
{
    /// <summary>
    /// Generates a new UUID v7 (timestamp-based UUID).
    /// </summary>
    /// <returns>A UUID v7 (Guid) with a timestamp-based structure.</returns>
    public static Guid Generate()
    {
        byte[] guidBytes = new byte[16];

        // Get the current Unix timestamp in milliseconds
        long timestamp = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();

        // Set the first 6 bytes with the timestamp (Big Endian)
        guidBytes[0] = (byte)(timestamp >> 40);
        guidBytes[1] = (byte)(timestamp >> 32);
        guidBytes[2] = (byte)(timestamp >> 24);
        guidBytes[3] = (byte)(timestamp >> 16);
        guidBytes[4] = (byte)(timestamp >> 8);
        guidBytes[5] = (byte)timestamp;

        // Generate randomness for bytes 6 to 15
        using (RandomNumberGenerator rng = RandomNumberGenerator.Create())
        {
            rng.GetBytes(guidBytes, 6, 10); // Preenche os bytes 6 a 15 com valores aleatórios
        }

        // Set the UUID version to 7
        guidBytes[6] = (byte)((guidBytes[6] & 0x0F) | 0x70);

        // Set the variant bits (RFC 4122)
        guidBytes[8] = (byte)((guidBytes[8] & 0x3F) | 0x80);

        return new Guid(guidBytes);
    }
}
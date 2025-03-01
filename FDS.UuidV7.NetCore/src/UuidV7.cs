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
        byte[] guidBytes = Guid.NewGuid().ToByteArray();

        // Get the current Unix timestamp in milliseconds
        long timestamp = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();

        // Set the first bytes with the timestamp to follow the UUID v7 specification
        guidBytes[0] = (byte)((timestamp >> 40) & 0xFF);
        guidBytes[1] = (byte)((timestamp >> 32) & 0xFF);
        guidBytes[2] = (byte)((timestamp >> 24) & 0xFF);
        guidBytes[3] = (byte)((timestamp >> 16) & 0xFF);
        guidBytes[4] = (byte)((timestamp >> 8) & 0xFF);
        guidBytes[5] = (byte)(timestamp & 0xFF);

        // Set the UUID version to 7
        guidBytes[6] = (byte)((guidBytes[6] & 0x0F) | 0x70);

        return new Guid(guidBytes);
    }
}

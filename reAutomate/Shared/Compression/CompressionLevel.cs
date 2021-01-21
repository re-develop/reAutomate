namespace reAutomate.Shared.Models.Compression
{
    public static class Compression
    {
        public static int CompressionLevelToZPAC(this CompressionLevel level)
        {
            return level switch
            {
                CompressionLevel.HighestSpeed => 0,
                CompressionLevel.HigherSpeed => 1,
                CompressionLevel.Balanced => 2,
                CompressionLevel.HigherCompression => 3,
                CompressionLevel.HighestCompression => 4,
                // Difference between Level 4 and 5 are minimal, Level 4 still takes 9 hours per 1GB (estimated)
                _ => 2,
            };
        }
    }

    public enum CompressionLevel
    {
        HighestSpeed,
        HigherSpeed,
        Balanced,
        HigherCompression,
        HighestCompression
    }
}
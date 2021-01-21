using reAutomate.Shared.Models.Compression;
using System.Threading.Tasks;

namespace reAutomate.Shared.Compression
{
    public interface ICompressor
    {
        Task Compress(string sourceDirectory, string targetFile, CompressionLevel level);

        Task Decompress(string sourceFile, string targetDirectory);
    }
}
using reAutomate.Shared.Helper;
using reAutomate.Shared.Models.Compression;
using System.Threading.Tasks;

namespace reAutomate.Shared.Compression
{
    public class ZPAC : ICompressor
    {
        private static readonly string Executable = "Library/ZPAC/zpaq.exe";

        public async Task Compress(string sourceDirectory, string targetFile, CompressionLevel level)
        {
            int compressionLevel = level.CompressionLevelToZPAC();

            sourceDirectory = sourceDirectory.GetDirectoryFullName();

            ProcessHelper compressionProcess = ProcessHelper.Create(Executable,
                GenerateCompressionArguments(sourceDirectory, targetFile, compressionLevel));

            await compressionProcess.RunAsync();
        }

        public async Task Decompress(string sourceFile, string targetDirectory)
        {
            sourceFile = sourceFile.GetFileFullName();
            targetDirectory = targetDirectory.GetDirectoryFullName();

            ProcessHelper decompressionProcess = ProcessHelper.Create(Executable,
                GenerateDecompressionArguments(sourceFile, targetDirectory));

            await decompressionProcess.RunAsync();
        }

        private string GenerateCompressionArguments(string sourceDirectory, string targetFile, int level)
            => $"add {targetFile} {sourceDirectory} -method {level}"; // doesn't work if contains space

        private string GenerateDecompressionArguments(string sourceFile, string targetDirectory)
            => $"extract {sourceFile} -to {targetDirectory}"; // doesn't work if contains space
    }
}
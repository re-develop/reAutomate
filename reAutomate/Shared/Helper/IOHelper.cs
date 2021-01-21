using System;
using System.IO;
using System.Threading.Tasks;

namespace reAutomate.Shared.Helper
{
    internal static class IOHelper
    {
        internal static string ReadFile(string path)
        {
            FileInfo fileInfo = new FileInfo(path);
            string result = string.Empty;

            if (!fileInfo.Exists)
                return string.Empty;

            try
            {
                StreamReader streamReader = CreateStreamReader(fileInfo);
                result = streamReader.ReadToEnd();

                streamReader.Close();
                streamReader.Dispose();
            }
            catch (Exception e)
            {
                // Todo: Logging
            }

            return result;
        }

        internal static async Task<string> ReadFileAsync(string path)
        {
            FileInfo fileInfo = new FileInfo(path);
            string result = string.Empty;

            if (!fileInfo.Exists)
                return string.Empty;

            try
            {
                StreamReader streamReader = CreateStreamReader(fileInfo);
                result = await streamReader.ReadToEndAsync();

                streamReader.Close();
                streamReader.Dispose();
            }
            catch (Exception e)
            {
                // Todo: Logging
            }

            return result;
        }

        internal static FileStream GetFileStream(string path)
        {
            FileInfo fileInfo = new FileInfo(path);

            try
            {
                FileStream fileStream = CreateFileStream(fileInfo);
                return fileStream;
            }
            catch (Exception e)
            {
                // Todo: Logging
            }

            return default;
        }

        internal static async Task WriteFileAsync(string path, string content)
        {
            FileInfo fileInfo = new FileInfo(path);

            try
            {
                StreamWriter streamWriter = CreateStreamWriter(fileInfo);

                await streamWriter.WriteAsync(content);

                streamWriter.Close();
                streamWriter.Dispose();
            }
            catch (Exception e)
            {
                // Todo: Logging
            }
        }

        internal static void WriteFile(string path, string content)
        {
            FileInfo fileInfo = new FileInfo(path);

            try
            {
                StreamWriter streamWriter = CreateStreamWriter(fileInfo);

                streamWriter.Write(content);

                streamWriter.Close();
                streamWriter.Dispose();
            }
            catch (Exception e)
            {
                // Todo: Logging
            }
        }

        internal static string GetDirectoryFullName(this string directory)
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(directory);

            if (!directoryInfo.Exists)
                return string.Empty;

            return directoryInfo.FullName;
        }

        internal static string GetFileFullName(this string file)
        {
            FileInfo fileInfo = new FileInfo(file);

            if (!fileInfo.Exists)
                return string.Empty;

            return fileInfo.FullName;
        }

        private static StreamReader CreateStreamReader(FileInfo file)
            => new StreamReader(new FileStream(file.FullName, FileMode.Open, FileAccess.Read, FileShare.Read));

        private static StreamWriter CreateStreamWriter(FileInfo file)
        {
            StreamWriter streamWriter;

            if (file.Exists)
                streamWriter = new StreamWriter(new FileStream(file.FullName, FileMode.CreateNew, FileAccess.Write, FileShare.None));
            else
                streamWriter = new StreamWriter(File.Create(file.FullName));

            return streamWriter;
        }

        private static FileStream CreateFileStream(FileInfo file)
        {
            FileStream fileStream;

            if (file.Exists)
                fileStream = new FileStream(file.FullName, FileMode.Open, FileAccess.ReadWrite, FileShare.None);
            else
                fileStream = File.Create(file.FullName);

            return fileStream;
        }
    }
}
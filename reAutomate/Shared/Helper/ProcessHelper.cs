using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;

namespace reAutomate.Shared.Helper
{
    public class ProcessHelper
    {
        private static readonly TaskCompletionSource<bool> TaskCompletionSource = new TaskCompletionSource<bool>();
        private readonly Process ContainedProcess;

        public ProcessHelper(Process process)
        {
            ContainedProcess = process;

            process.Exited += HandleProcessExit;
        }

        public static ProcessHelper Create(string exePath, string arguments)
        {
            FileInfo exeFile = new FileInfo(exePath);

            if (!exeFile.Exists)
                return null;

            Process process = new Process()
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = exeFile.FullName,
                    Arguments = arguments,
                    CreateNoWindow = false,
                    UseShellExecute = false
                }
            };

            return new ProcessHelper(process);
        }

        public Task<bool> RunAsync()
        {
            ContainedProcess.Start();

            return TaskCompletionSource.Task;
        }

        public void Cancel()
        {
            TaskCompletionSource?.TrySetCanceled();

            ContainedProcess.Kill();
        }

        private void HandleProcessExit(object sender, EventArgs args)
            => TaskCompletionSource.SetResult(ContainedProcess.ExitCode == 0);
    }
}
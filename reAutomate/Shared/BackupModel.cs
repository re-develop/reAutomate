using reAutomate.Shared.Steam;
using System;

namespace reAutomate.Shared
{
    public class BackupModel
    {
        public int Id { get; set; }

        public Game SteamGame { get; set; }

        public string BackupFile { get; set; }

        public string SourceDirectory { get; set; }

        public DateTime LastBackup { get; set; }

        public BackupStatus Status { get; set; }
    }

    public enum BackupStatus
    {
        NotCreated,
        Queued,
        Processing,
        Done
    }
}
using reAutomate.Shared.Steam;
using System;
using System.ComponentModel.DataAnnotations;

namespace reAutomate.Shared.Models
{
    public class BackupModel
    {
        [Key]
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
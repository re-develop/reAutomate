using System;
using System.ComponentModel.DataAnnotations;

namespace reAutomate.Shared.Models
{
    public class DownloadModel
    {
        [Key]
        public int Id { get; set; }

        public string Link { get; set; }

        public string Name { get; set; }

        public long Size { get; set; }

        public DateTime Started { get; set; }

        public DateTime Finished { get; set; }

        public DownloadStatus Status { get; set; }

        public string Error { get; set; }
    }

    public enum DownloadStatus
    {
        Created = 0,
        Queued = 1,
        Preparing = 2,
        Downloading = 3,
        Processing = 4,
        Done = 5,
        Error = 99
    }
}
using Microsoft.EntityFrameworkCore;
using reAutomate.Shared.Models;

namespace reAutomate.Server.Database
{
    public partial class Context : DbContext
    {
        public DbSet<DownloadModel> Downloads { get; set; }

        public DbSet<BackupModel> Backups { get; set; }

        public static Context Create()
        {
            return new Context();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
            optionsBuilder.UseSqlite("Data Source:reAutomate.db");

            base.OnConfiguring(optionsBuilder);
        }
    }
}
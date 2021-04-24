using Microsoft.EntityFrameworkCore;
using mnd.Common;
using mnd.Logic.BC_SatinAlmaYeni.Domain;

namespace mnd.Logic.BC_SatinAlmaYeni.Data
{
    public class KulceSatinAlmaDbContext : DbContext
    {
        public DbSet<KulceKontrat> KulceKontrats { get; set; }
        public DbSet<KulceProforma> KulceProformas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var path = GlobalSettings.Default.SqlCnnString;
                optionsBuilder.UseSqlServer(path);
                optionsBuilder.EnableDetailedErrors(true);
                base.OnConfiguring(optionsBuilder);
              
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<KulceKontrat>().ToTable(nameof(KulceKontrat), "SatinAlma");
            modelBuilder.Entity<KulceKontratDonem>().ToTable(nameof(KulceKontratDonem), "SatinAlma");
            modelBuilder.Entity<KulceProforma>().ToTable(nameof(KulceProforma), "SatinAlma");

        }
    }
}

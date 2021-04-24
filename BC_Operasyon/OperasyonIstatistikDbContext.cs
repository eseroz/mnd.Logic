using Microsoft.EntityFrameworkCore;
using mnd.Common;
using mnd.Logic.Model.Operasyon;

namespace mnd.Logic.BC_Operasyon
{
    public class OperasyonIstatistikDbContext : DbContext
    {
        public DbSet<HaftalikYuklemePlan> YuklemePlanlari { get; set; }

        public DbSet<YariMamulHatData> YariMamulHatVeriler { get; set; }

        public DbSet<YariMamulBirimFiyat> YariMamulBirimFiyatlari { get; set; }

        public DbSet<vwPaletSevkPivot> vwPaletSevkPivots { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var yol = GlobalSettings.Default.SqlCnnString;

            optionsBuilder.UseSqlServer(yol);
            optionsBuilder.EnableDetailedErrors(true);

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("Operasyon");

            modelBuilder.Entity<HaftalikYuklemePlan>().ToTable(nameof(HaftalikYuklemePlan));
            modelBuilder.Entity<YariMamulHatData>().ToTable(nameof(YariMamulHatData));
            modelBuilder.Entity<YariMamulBirimFiyat>().ToTable(nameof(YariMamulBirimFiyat));

            modelBuilder.Entity<vwPaletSevkPivot>().ToTable(nameof(vwPaletSevkPivot),"Pandap");

            base.OnModelCreating(modelBuilder);
        }

    }
}

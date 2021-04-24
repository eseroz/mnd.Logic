using Microsoft.EntityFrameworkCore;
using mnd.Common;
using mnd.Logic.BC_MusteriTakip.Domain;

namespace mnd.Logic.BC_MusteriTakip.Data
{
    public class MusteriTakipDbContext : DbContext
    {
        public DbSet<Gorusme> Gorusmeler { get; set; }
        public DbSet<GorusmeTip> GorusmeTipleri { get; set; }
        public DbSet<GorusmeKonuTip> GorusmeKonuTipleri { get; set; }
        public DbQuery<YaslandirilmisFatura> YazlandirilmisFaturalar { get; set; }
        public DbSet<Unvan> Unvanlar { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var yol = GlobalSettings.Default.SqlCnnString;

            optionsBuilder.UseSqlServer(yol);
            optionsBuilder.EnableDetailedErrors(true);

            //base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("MusteriTakip");

            modelBuilder.Entity<Gorusme>().ToTable(nameof(Gorusme));
            modelBuilder.Entity<GorusmeTip>().ToTable(nameof(GorusmeTip));
            modelBuilder.Entity<GorusmeKonuTip>().ToTable(nameof(GorusmeKonuTip));
            modelBuilder.Entity<Unvan>().ToTable(nameof(Unvan));

            modelBuilder.Query<YaslandirilmisFatura>().ToView(nameof(YaslandirilmisFatura));

            base.OnModelCreating(modelBuilder);
        }

    }
}

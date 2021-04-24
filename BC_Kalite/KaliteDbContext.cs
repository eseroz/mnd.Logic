using Microsoft.EntityFrameworkCore;
using mnd.Common;
using mnd.Logic.BC_Kalite.Domain;

namespace mnd.Logic.BC_Kalite
{
    public class KaliteDbContext : DbContext
    {
        public DbSet<KaliteRedMalzeme> KalteRedMalzemeler { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var yol = GlobalSettings.Default.SqlCnnString;

            optionsBuilder.UseSqlServer(yol);
            optionsBuilder.EnableDetailedErrors(true);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("Kalite");

            modelBuilder.Entity<KaliteRedMalzeme>().ToTable(nameof(KaliteRedMalzeme));
            base.OnModelCreating(modelBuilder);
        }
    }
}

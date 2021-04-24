using Microsoft.EntityFrameworkCore;
using mnd.Common;

namespace mnd.Logic.BC_Finans
{
    public class FinansDbContext : DbContext
    {
        public DbSet<vwBanka> BankaFinansRapor { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var yol = GlobalSettings.Default.SqlCnnString;

            optionsBuilder.UseSqlServer(yol);
            optionsBuilder.EnableDetailedErrors(true);

            //base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("Finans");

            modelBuilder.Entity<vwBanka>().ToTable(nameof(vwBanka));


            base.OnModelCreating(modelBuilder);
        }
    }
}

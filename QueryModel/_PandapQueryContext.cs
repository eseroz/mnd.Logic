using Microsoft.EntityFrameworkCore;
using mnd.Common;

namespace mnd.Logic.QueryModel
{
    public partial class PandapQueryContext : DbContext
    {
        public DbSet<vwSiparisDolulukSon> VwSiparisDoluluks { get; set; }
        public DbSet<SiparisDoluluk> SiparisDoluluklar { get; set; }

        public PandapQueryContext()
        {
            Database.SetCommandTimeout(1500000);
        }

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
            modelBuilder.Entity<vwSiparisDolulukSon>().ToTable("vwSiparisDolulukSon", "Satis");
            modelBuilder.Entity<SiparisDoluluk>().ToTable("SiparisDoluluk", "Satis");
        }
    }
}
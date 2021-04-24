using Microsoft.EntityFrameworkCore;
using mnd.Common;

namespace mnd.Logic.Model.Muhasebe
{
    public class MuhasebeDbContext : DbContext
    {
        public DbSet<DahildeIslemeIzinBelge> DahildeIslemeIzinBelgeleri { get; set; }
        public DbSet<FinansalGarantor> FinansalGarantorler { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(GlobalSettings.Default.SqlCnnString);
                optionsBuilder.EnableDetailedErrors(true);
                base.OnConfiguring(optionsBuilder);
            }

            base.OnConfiguring(optionsBuilder);
        }
    }
}

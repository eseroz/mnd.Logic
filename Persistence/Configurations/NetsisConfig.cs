using Microsoft.EntityFrameworkCore;
using mnd.Logic.Model.Netsis;

namespace mnd.Logic.Persistence.Configurations
{
    public class NetsisConfig
    {
        public static void Config(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FaturaMiktari>().ToTable(nameof(FaturaMiktari), "Netsis");
            modelBuilder.Entity<CariKart>().ToTable(nameof(CariKart), "Netsis");
            modelBuilder.Entity<CariEmail>().ToTable(nameof(CariEmail), "Netsis");
            modelBuilder.Entity<CariEmailYeni>().ToTable(nameof(CariEmailYeni), "Netsis");
            modelBuilder.Entity<DovizKur>().ToTable(nameof(DovizKur), "Netsis");
        }
    }
}
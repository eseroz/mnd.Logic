using Microsoft.EntityFrameworkCore;
using mnd.Logic.Model.Operasyon;

namespace mnd.Logic.Persistence.Configurations
{
    public class OperasyonConfig
    {
        public static void Config(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CariRiskKontrol>().ToTable(nameof(CariRiskKontrol), "Operasyon");
            modelBuilder.Entity<NetsisRiskSon1>().ToTable(nameof(NetsisRiskSon1), "Operasyon");
            modelBuilder.Entity<SevkiyatEmri>().ToTable(nameof(SevkiyatEmri), "Operasyon");
        }
    }
}
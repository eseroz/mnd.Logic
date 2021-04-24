using Microsoft.EntityFrameworkCore;
using mnd.Logic.Model._Ref;

namespace mnd.Logic.Persistence.Configurations
{
    public class RefConfig
    {
        public static void Config(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DovizTip>().ToTable(nameof(DovizTip), "_Ref");
            modelBuilder.Entity<OdemeTip>().ToTable(nameof(OdemeTip), "_Ref");
            modelBuilder.Entity<SatisTip>().ToTable(nameof(SatisTip), "_Ref");
            modelBuilder.Entity<TeslimTip>().ToTable(nameof(TeslimTip), "_Ref");
            modelBuilder.Entity<LmeTip>().ToTable(nameof(LmeTip), "_Ref");
            modelBuilder.Entity<KulcePrimTip>().ToTable(nameof(KulcePrimTip), "_Ref");
            modelBuilder.Entity<BirimTip>().ToTable(nameof(BirimTip), "_Ref");
            modelBuilder.Entity<AlasimTip>().ToTable(nameof(AlasimTip), "_Ref");
            modelBuilder.Entity<AmbalajTip>().ToTable(nameof(AmbalajTip), "_Ref");
            modelBuilder.Entity<MasuraTip>().ToTable(nameof(MasuraTip), "_Ref");
            modelBuilder.Entity<SertlikTip>().ToTable(nameof(SertlikTip), "_Ref");
            modelBuilder.Entity<YuzeyTip>().ToTable(nameof(YuzeyTip), "_Ref");
            modelBuilder.Entity<KullanimAlanTip>().ToTable(nameof(KullanimAlanTip), "_Ref");
        }
    }
}
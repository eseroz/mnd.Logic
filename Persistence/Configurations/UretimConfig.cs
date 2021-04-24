using Microsoft.EntityFrameworkCore;
using mnd.Logic.Model.Uretim;

namespace mnd.Logic.Persistence.Configurations
{
    public class UretimConfig
    {
        public static void Config(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Recete>().ToTable(nameof(Recete), "Uretim");
            modelBuilder.Entity<Urun>().ToTable(nameof(Urun), "Uretim");
            modelBuilder.Entity<KaliteStandart>().ToTable(nameof(KaliteStandart), "Uretim");
            modelBuilder.Entity<UretimEmriRulo>().ToTable(nameof(UretimEmriRulo), "Uretim");
            modelBuilder.Entity<UretimEmriMakineAsama1>().ToTable(nameof(UretimEmriMakineAsama1), "Uretim");
            modelBuilder.Entity<UretimEmriMakineAsama2>().ToTable(nameof(UretimEmriMakineAsama2), "Uretim");
        }
    }
}
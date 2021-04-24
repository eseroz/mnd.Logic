using Microsoft.EntityFrameworkCore;
using mnd.Logic.Model.App;

namespace mnd.Logic.Persistence.Configurations
{
    public class AppConfig
    {
        public static void Config(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FormMenuItem>().ToTable(nameof(FormMenuItem), "App");
            modelBuilder.Entity<FormKomutYetki>().ToTable(nameof(FormKomutYetki), "App");
            modelBuilder.Entity<Layout>().ToTable(nameof(Layout), "App");
            modelBuilder.Entity<Kullanici>().ToTable(nameof(Kullanici), "App");
            modelBuilder.Entity<Ayarlar>().ToTable(nameof(Ayarlar), "App");
            modelBuilder.Entity<EntityLog>().ToTable(nameof(EntityLog), "App");
            modelBuilder.Entity<Duyuru>().ToTable(nameof(Duyuru), "App");
            modelBuilder.Entity<ExcelImportTanim>().ToTable(nameof(ExcelImportTanim), "App");
            modelBuilder.Entity<OrtakDilTanim>().ToTable(nameof(OrtakDilTanim), "App");
            modelBuilder.Entity<KullaniciRol>().ToTable(nameof(KullaniciRol), "App");
        }
    }
}
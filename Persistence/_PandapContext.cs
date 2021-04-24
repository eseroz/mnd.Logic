using Microsoft.EntityFrameworkCore;
using mnd.Common;
using mnd.Logic.BC_Kalite.Domain;
using mnd.Logic.BC_MusteriTakip.Domain;
using mnd.Logic.Model._Ref;
using mnd.Logic.Model.App;
using mnd.Logic.Model.Muhasebe;
using mnd.Logic.Model.Netsis;
using mnd.Logic.Model.Operasyon;
using mnd.Logic.Model.Satis;
using mnd.Logic.Model.Stok;
using mnd.Logic.Model.Uretim;
using mnd.Logic.Persistence.Configurations;
using mnd.Logic.Services._DTOs;

namespace mnd.Logic.Persistence
{
    public partial class PandapContext : DbContext
    {
        public virtual DbSet<EntityLog> EntityLoglari { get; set; }
        public virtual DbSet<Ayarlar> Ayarlars { get; set; }
        public virtual DbSet<Kullanici> Kullanicilar { get; set; }
        public virtual DbSet<Duyuru> Duyurular { get; set; }
        public virtual DbSet<ExcelImportTanim> ExcelImportTanims { get; set; }

        public virtual DbSet<Siparis> Siparisler { get; set; }
        public virtual DbSet<SiparisKalem> SiparisKalemleri { get; set; }

        public virtual DbSet<CariKart> CariKartlar { get; set; }

        public virtual DbSet<CariKart320> CariKart320lar { get; set; }

        public virtual DbSet<OdemeTip> OdemeTipleri { get; set; }
        public virtual DbSet<TeslimTip> TeslimTipleri { get; set; }
        public virtual DbSet<DovizTip> DovizTipleri { get; set; }
        public virtual DbSet<SatisTip> SatisTipleri { get; set; }
        public virtual DbSet<LmeTip> LmeTipleri { get; set; }
        public virtual DbSet<KulcePrimTip> KulceTipleri { get; set; }
        public virtual DbSet<FaturaMiktari> FaturaMiktarlari { get; set; }

        public virtual DbSet<SurecDurum> SatisSurecDurumlari { get; set; }

        public virtual DbSet<TBLIHRSTK> Urunler { get; set; }
        public virtual DbSet<BirimTip> BirimTipleri { get; set; }
        public virtual DbSet<AlasimTip> AlasimTipleri { get; set; }
        public virtual DbSet<MasuraTip> MasuraTipleri { get; set; }
        public virtual DbSet<YuzeyTip> YuzeyTipleri { get; set; }
        public virtual DbSet<SertlikTip> SertlikTipleri { get; set; }
        public virtual DbSet<KullanimAlanTip> KullanimAlaniTipleri { get; set; }
        public virtual DbSet<AmbalajTip> AmbalajTipleri { get; set; }

        public virtual DbSet<Recete> Receteler { get; set; }
        public virtual DbSet<KaliteStandart> KaliteStandartlari { get; set; }

        public virtual DbSet<CariEmail> CariEmailleri { get; set; }
        public virtual DbSet<UretimEmri> UretimEmirleri { get; set; }

        public virtual DbSet<CariRiskKontrol> CariRiskKontrols { get; set; }
        public virtual DbSet<DovizKur> DovizKurlari { get; set; }

        public virtual DbSet<SqlGrupSayi> PlanlamaSayilar { get; set; }

        public virtual DbSet<Bobin> UretimBobinler { get; set; }
        public virtual DbSet<Palet> UretimPaletler { get; set; }

        public DbSet<MamulDepoStokDto> MamulDepoStoklar { get; set; }

        public DbSet<SatisRapor> SatisRapor { get; set; }
        public DbSet<NetsisRiskSon1> Netsis_CariRiskler { get; set; }

        public DbSet<Layout> Layouts { get; set; }

        public DbSet<OrtakDilTanim> OrtakDilTanims { get; set; }

        public DbSet<UretimEmriRulo> PlanlamaRulolari { get; set; }

        public DbSet<UretimEmriMakineAsama1> MakinaAsamalari1 { get; set; }

        public DbSet<UretimEmriMakineAsama2> MakinaAsamalari2 { get; set; }

        public DbSet<SevkiyatEmri> SevkiyatEmirleri { get; set; }

        public DbSet<FormMenuItem> NavMenuItems { get; set; }

        public DbSet<FormKomutYetki> ViewCommandYetkis { get; set; }
        public DbSet<KullaniciRol> KullaniciRols { get; set; }

        public DbSet<PandapCari> PandapCaris { get; set; }
        public DbSet<RaporTanim> RaporTanims { get; set; }

        public DbSet<Banka> Bankas { get; set; }

        public DbSet<LmeBaglama> LmeBaglamas { get; set; }


        public DbSet<LmeGunluk> LmeGunluks { get; set; }

        public DbSet<LmeOrtalamaVeri> LmeOrtalamaVeriler { get; set; }

      


        public DbSet<Model.Operasyon.Irsaliye> CariIrsaliyeler { get; set; }
        public DbSet<IrsaliyePalet> CariIrsaliyePaletler { get; set; }

        public DbSet<NetsisCariHareket> NetsisCariHareketler { get; set; }

        public DbSet<Gorusme> Gorusmeler { get; set; }

        public DbSet<CariDokuman> CariDokuman { get; set; }

        public DbSet<KaliteRedMalzeme> KaliteRedMalzemeler { get; set; }



        public PandapContext()
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
            AppConfig.Config(modelBuilder);
            RefConfig.Config(modelBuilder);
            UretimConfig.Config(modelBuilder);
            NetsisConfig.Config(modelBuilder);
            OperasyonConfig.Config(modelBuilder);

            modelBuilder.ApplyConfiguration<Siparis>(new SiparisConfig());
            modelBuilder.ApplyConfiguration<SiparisKalem>(new SiparisKalemConfig());
            modelBuilder.ApplyConfiguration<UretimEmri>(new UretimEmriConfig());
            modelBuilder.ApplyConfiguration<Palet>(new PaletConfig());
            modelBuilder.ApplyConfiguration<Bobin>(new BobinConfig());

       

            modelBuilder.Entity<NetsisCariHareket>().ToTable("CariHareket", "Netsis");


            modelBuilder.Entity<PandapCari>().ToTable(nameof(PandapCari), "Satis");

            modelBuilder.Entity<CariKart320>().ToTable(nameof(CariKart320), "Netsis");


            modelBuilder.Entity<Gorusme>().ToTable(nameof(Gorusme), "MusteriTakip");

            modelBuilder.Entity<KaliteRedMalzeme>().ToTable(nameof(KaliteRedMalzeme), "Kalite");

            modelBuilder.Entity<PandapCari>().HasMany(c => c.Siparisler)
                                             .WithOne()
                                             .HasForeignKey(c => c.CariKod);


        

            modelBuilder.Entity<PandapCari>()
                                .HasMany(c => c.CariHareketler)
                                .WithOne()
                                .HasForeignKey(c => c.CARI_KOD_TR);


            modelBuilder.Entity<PandapCari>()
                              .HasMany(c => c.CariDokumanlar)
                              .WithOne()
                              .HasForeignKey(c => c.CariKod);



            modelBuilder.Entity<PandapCari>()
                              .HasMany(c => c.CariEmailler)
                              .WithOne()
                              .HasForeignKey(c => c.CariKod);

            modelBuilder.Entity<PandapCari>()
                            .HasMany(c => c.Gorusmeler)
                            .WithOne()
                            .HasForeignKey(c => c.MusteriCariKod);

            modelBuilder.Entity<PandapCari>()
                .HasOne(c => c.KullanimAlanNavigation)
                .WithMany()
                .HasForeignKey(c => c.MusteriKullanimAlanTipKod);



            modelBuilder.Entity<CariDokuman>().ToTable(nameof(CariDokuman), "Satis");

            modelBuilder.Entity<GorusmeTip>().ToTable(nameof(GorusmeTip), "MusteriTakip");
            modelBuilder.Entity<GorusmeKonuTip>().ToTable(nameof(GorusmeKonuTip), "MusteriTakip");


            modelBuilder.Entity<SurecDurum>().ToTable(nameof(SurecDurum), "Satis");


            modelBuilder.Entity<MamulDepoStokDto>().ToTable("MamulDepoStok");
            modelBuilder.Entity<SatisRapor>().ToTable(nameof(SatisRapor), "dbo");

            modelBuilder.Entity<RaporTanim>().ToTable(nameof(RaporTanim), "App");

            modelBuilder.Entity<Banka>().ToTable(nameof(Banka), "App");

            modelBuilder.Entity<LmeBaglama>().ToTable(nameof(LmeBaglama), "Satis");



            //modelBuilder.Entity<LmeBaglama>()
            //          .HasMany(c => c.SiparisKalemleri)
            //          .WithOne()
            //          .HasForeignKey(c => c.LmeBaglamaKod)
            //          .HasPrincipalKey(p => p.RefNo)
            //          .OnDelete(DeleteBehavior.Cascade);



            modelBuilder.Entity<LmeGunluk>().ToTable(nameof(LmeGunluk), "Satis");
        }
    }
}
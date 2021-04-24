using Microsoft.EntityFrameworkCore;
using mnd.Common;
using mnd.Logic.BC_App.Domain;
using mnd.Logic.BC_SatinAlmaYeni.Domain;

namespace mnd.Logic.BC_SatinAlmaYeni.Data
{
    using global::mnd.Logic.Model;
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class DEPO_FATUIRS_2019 : MyBindableBase
    {
        private string fATIRS_NO;
        private string aCIKLAMA;

        [Key]
        public string FATIRS_NO { get => fATIRS_NO; set => SetProperty(ref fATIRS_NO, value); }

        public string ACIKLAMA { get => aCIKLAMA?.ToUpper(); set => SetProperty(ref aCIKLAMA, value); }

        public DEPO_FATUIRS_2019()
        {
            FIS_KALEMLERI = new List<DEPO_STHAR_2019>();
        }

        [ForeignKey("FISNO")]
        public List<DEPO_STHAR_2019> FIS_KALEMLERI { get; set; }

        public short SUBE_KODU { get; set; }
        public string FTIRSIP { get; set; }

        public string CARI_KODU { get; set; }

        [ForeignKey("CARI_KODU")]
        public DEPO_MASRAFMERKEZ MASRAFMERKEZI_NAV { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime TARIH { get; set; }

        public byte? TIPI { get; set; }
        public decimal? BRUTTUTAR { get; set; }
        public decimal? SAT_ISKT { get; set; }
        public decimal? MFAZ_ISKT { get; set; }
        public decimal? GEN_ISK1T { get; set; }
        public decimal? GEN_ISK2T { get; set; }
        public decimal? GEN_ISK3T { get; set; }
        public decimal? GEN_ISK1O { get; set; }
        public decimal? GEN_ISK2O { get; set; }
        public decimal? GEN_ISK3O { get; set; }
        public decimal? KDV { get; set; }
        public decimal? FAT_ALTM1 { get; set; }
        public decimal? FAT_ALTM2 { get; set; }

        public string KOD1 { get; set; }
        public string KOD2 { get; set; }
        public short? ODEMEGUNU { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? ODEMETARIHI { get; set; }

        public string KDV_DAHILMI { get; set; }
        public short? FATKALEM_ADEDI { get; set; }
        public DateTime? SIPARIS_TEST { get; set; }
        public decimal? TOPLAM_MIK { get; set; }
        public short? TOPDEPO { get; set; }
        public string YEDEK22 { get; set; }
        public string CARI_KOD2 { get; set; }
        public string YEDEK { get; set; }
        public string UPDATE_KODU { get; set; }
        public int SIRANO { get; set; }
        public decimal? KDV_DAHIL_BRUT_TOP { get; set; }
        public decimal? KDV_TENZIL { get; set; }
        public decimal? MALFAZLASIKDVSI { get; set; }
        public decimal? GENELTOPLAM { get; set; }
        public decimal? YUVARLAMA { get; set; }
        public string SATIS_KOND { get; set; }
        public string PLA_KODU { get; set; }
        public byte? DOVIZTIP { get; set; }
        public decimal? DOVIZTUT { get; set; }
        public string KS_KODU { get; set; }
        public decimal? BAG_TUTAR { get; set; }
        public string YEDEK2 { get; set; }
        public string HIZMET_FAT { get; set; }
        public DateTime? VADEBAZT { get; set; }
        public string KAPATILMIS { get; set; }
        public string S_YEDEK1 { get; set; }
        public string S_YEDEK2 { get; set; }
        public decimal? F_YEDEK3 { get; set; }
        public decimal? F_YEDEK4 { get; set; }
        public decimal? F_YEDEK5 { get; set; }
        public string C_YEDEK6 { get; set; }
        public byte? B_YEDEK7 { get; set; }
        public short? I_YEDEK8 { get; set; }
        public int? L_YEDEK9 { get; set; }
        public string AMBAR_KBLNO { get; set; }
        public DateTime? D_YEDEK10 { get; set; }
        public string PROJE_KODU { get; set; }
        public string KOSULKODU { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? FIYATTARIHI { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? KOSULTARIHI { get; set; }

        public short? GENISK1TIP { get; set; }
        public short? GENISK2TIP { get; set; }
        public short? GENISK3TIP { get; set; }
        public byte? EXPORTTYPE { get; set; }
        public string EXGUMRUKNO { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? EXGUMTARIH { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? EXFIILITARIH { get; set; }

        public string EXPORTREFNO { get; set; }
        public string KAYITYAPANKUL { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? KAYITTARIHI { get; set; }

        public string DUZELTMEYAPANKUL { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? DUZELTMETARIHI { get; set; }

        public short? GELSUBE_KODU { get; set; }
        public short? GITSUBE_KODU { get; set; }
        public string ONAYTIPI { get; set; }
        public int ONAYNUM { get; set; }
        public short ISLETME_KODU { get; set; }
        public string ODEKOD { get; set; }
        public decimal? BRMALIYET { get; set; }
        public short? KOSVADEGUNU { get; set; }
        public string YAPKOD { get; set; }
        public string GIB_FATIRS_NO { get; set; }
        public string EXTERNALAPPID { get; set; }
    }

    public class DEPO_STHAR_2019 : MyBindableBase
    {
        private decimal? sTHAR_GCMIK;

        [Key]
        public int INCKEYNO { get; set; }

        public string FISNO { get; set; }
        public string STOK_KODU { get; set; }

        [NotMapped]
        public string StokAdi { get; set; }

        [NotMapped]
        public string OlcuBirimAd { get; set; }

        [ForeignKey("STOK_KODU")]
        public DEPO_STSABIT STSABIT_NAV { get; set; }

        public decimal? STHAR_GCMIK { get => sTHAR_GCMIK; set => SetProperty(ref sTHAR_GCMIK, value); }
        public decimal? STHAR_GCMIK2 { get; set; }
        public decimal? CEVRIM { get; set; }
        public string STHAR_GCKOD { get; set; }
        public DateTime STHAR_TARIH { get; set; }
        public decimal? STHAR_NF { get; set; }
        public decimal? STHAR_BF { get; set; }
        public decimal? STHAR_IAF { get; set; }
        public decimal? STHAR_KDV { get; set; }
        public short? DEPO_KODU { get; set; }
        public string STHAR_ACIKLAMA { get; set; }
        public decimal? STHAR_SATISK { get; set; }
        public decimal? STHAR_MALFISK { get; set; }
        public string STHAR_FTIRSIP { get; set; }
        public decimal? STHAR_SATISK2 { get; set; }
        public byte? LISTE_FIAT { get; set; }
        public string STHAR_HTUR { get; set; }
        public byte? STHAR_DOVTIP { get; set; }
        public byte? PROMASYON_KODU { get; set; }
        public decimal? STHAR_DOVFIAT { get; set; }
        public short? STHAR_ODEGUN { get; set; }
        public decimal? STRA_SATISK3 { get; set; }
        public decimal? STRA_SATISK4 { get; set; }
        public decimal? STRA_SATISK5 { get; set; }
        public decimal? STRA_SATISK6 { get; set; }
        public string STHAR_BGTIP { get; set; }
        public string STHAR_KOD1 { get; set; }
        public string STHAR_KOD2 { get; set; }
        public string STHAR_SIPNUM { get; set; }
        public string STHAR_CARIKOD { get; set; }
        public string STHAR_SIP_TURU { get; set; }
        public string PLASIYER_KODU { get; set; }
        public string EKALAN_NEDEN { get; set; }
        public string EKALAN { get; set; }
        public string EKALAN1 { get; set; }
        public decimal? REDMIK { get; set; }
        public byte? REDNEDEN { get; set; }
        public short? SIRA { get; set; }
        public short? STRA_SIPKONT { get; set; }
        public string AMBAR_KABULNO { get; set; }
        public byte? FIRMA_DOVTIP { get; set; }
        public decimal? FIRMA_DOVTUT { get; set; }
        public decimal? FIRMA_DOVMAL { get; set; }
        public string UPDATE_KODU { get; set; }
        public string IRSALIYE_NO { get; set; }
        public DateTime? IRSALIYE_TARIH { get; set; }
        public string KOSULKODU { get; set; }
        public byte? ECZA_FAT_TIP { get; set; }
        public DateTime? STHAR_TESTAR { get; set; }
        public byte? OLCUBR { get; set; }

        public DateTime? VADE_TARIHI { get; set; }
        public string LISTE_NO { get; set; }
        public int? BAGLANTI_NO { get; set; }
        public short SUBE_KODU { get; set; }
        public string MUH_KODU { get; set; }
        public string S_YEDEK1 { get; set; }
        public string S_YEDEK2 { get; set; }
        public decimal? F_YEDEK3 { get; set; }
        public decimal? F_YEDEK4 { get; set; }
        public decimal? F_YEDEK5 { get; set; }
        public string C_YEDEK6 { get; set; }
        public byte? B_YEDEK7 { get; set; }
        public short? I_YEDEK8 { get; set; }
        public int? L_YEDEK9 { get; set; }
        public DateTime? D_YEDEK10 { get; set; }
        public string PROJE_KODU { get; set; }
        public DateTime? FIYATTARIHI { get; set; }
        public DateTime? KOSULTARIHI { get; set; }
        public short? SATISK1TIP { get; set; }
        public short? SATISK2TIP { get; set; }
        public short? SATISK3TIP { get; set; }
        public short? SATISK4TIP { get; set; }
        public short? SATISK5TIP { get; set; }
        public short? SATISK6TIP { get; set; }
        public byte? EXPORTTYPE { get; set; }
        public decimal? EXPORTMIK { get; set; }
        public DateTime? DUZELTMETARIHI { get; set; }
        public string ONAYTIPI { get; set; }
        public int ONAYNUM { get; set; }
        public decimal? KKMALF { get; set; }
        public short? STRA_IRSKONT { get; set; }
        public string YAPKOD { get; set; }
    }



    public class DEPO_FATUIRS_2020 : MyBindableBase
    {
        private string fATIRS_NO;
        private string aCIKLAMA;

        [Key]
        public string FATIRS_NO { get => fATIRS_NO; set => SetProperty(ref fATIRS_NO, value); }

        public string ACIKLAMA { get => aCIKLAMA?.ToUpper(); set => SetProperty(ref aCIKLAMA, value); }

        public DEPO_FATUIRS_2020()
        {
            FIS_KALEMLERI = new List<DEPO_STHAR_2020>();
        }

        [ForeignKey("FISNO")]
        public List<DEPO_STHAR_2020> FIS_KALEMLERI { get; set; }

        public short SUBE_KODU { get; set; }
        public string FTIRSIP { get; set; }

        public string CARI_KODU { get; set; }

        [ForeignKey("CARI_KODU")]
        public DEPO_MASRAFMERKEZ MASRAFMERKEZI_NAV { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime TARIH { get; set; }

        public byte? TIPI { get; set; }
        public decimal? BRUTTUTAR { get; set; }
        public decimal? SAT_ISKT { get; set; }
        public decimal? MFAZ_ISKT { get; set; }
        public decimal? GEN_ISK1T { get; set; }
        public decimal? GEN_ISK2T { get; set; }
        public decimal? GEN_ISK3T { get; set; }
        public decimal? GEN_ISK1O { get; set; }
        public decimal? GEN_ISK2O { get; set; }
        public decimal? GEN_ISK3O { get; set; }
        public decimal? KDV { get; set; }
        public decimal? FAT_ALTM1 { get; set; }
        public decimal? FAT_ALTM2 { get; set; }

        public string KOD1 { get; set; }
        public string KOD2 { get; set; }
        public short? ODEMEGUNU { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? ODEMETARIHI { get; set; }

        public string KDV_DAHILMI { get; set; }
        public short? FATKALEM_ADEDI { get; set; }
        public DateTime? SIPARIS_TEST { get; set; }
        public decimal? TOPLAM_MIK { get; set; }
        public short? TOPDEPO { get; set; }
        public string YEDEK22 { get; set; }
        public string CARI_KOD2 { get; set; }
        public string YEDEK { get; set; }
        public string UPDATE_KODU { get; set; }
        public int SIRANO { get; set; }
        public decimal? KDV_DAHIL_BRUT_TOP { get; set; }
        public decimal? KDV_TENZIL { get; set; }
        public decimal? MALFAZLASIKDVSI { get; set; }
        public decimal? GENELTOPLAM { get; set; }
        public decimal? YUVARLAMA { get; set; }
        public string SATIS_KOND { get; set; }
        public string PLA_KODU { get; set; }
        public byte? DOVIZTIP { get; set; }
        public decimal? DOVIZTUT { get; set; }
        public string KS_KODU { get; set; }
        public decimal? BAG_TUTAR { get; set; }
        public string YEDEK2 { get; set; }
        public string HIZMET_FAT { get; set; }
        public DateTime? VADEBAZT { get; set; }
        public string KAPATILMIS { get; set; }
        public string S_YEDEK1 { get; set; }
        public string S_YEDEK2 { get; set; }
        public decimal? F_YEDEK3 { get; set; }
        public decimal? F_YEDEK4 { get; set; }
        public decimal? F_YEDEK5 { get; set; }
        public string C_YEDEK6 { get; set; }
        public byte? B_YEDEK7 { get; set; }
        public short? I_YEDEK8 { get; set; }
        public int? L_YEDEK9 { get; set; }
        public string AMBAR_KBLNO { get; set; }
        public DateTime? D_YEDEK10 { get; set; }
        public string PROJE_KODU { get; set; }
        public string KOSULKODU { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? FIYATTARIHI { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? KOSULTARIHI { get; set; }

        public short? GENISK1TIP { get; set; }
        public short? GENISK2TIP { get; set; }
        public short? GENISK3TIP { get; set; }
        public byte? EXPORTTYPE { get; set; }
        public string EXGUMRUKNO { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? EXGUMTARIH { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? EXFIILITARIH { get; set; }

        public string EXPORTREFNO { get; set; }
        public string KAYITYAPANKUL { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? KAYITTARIHI { get; set; }

        public string DUZELTMEYAPANKUL { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? DUZELTMETARIHI { get; set; }

        public short? GELSUBE_KODU { get; set; }
        public short? GITSUBE_KODU { get; set; }
        public string ONAYTIPI { get; set; }
        public int ONAYNUM { get; set; }
        public short ISLETME_KODU { get; set; }
        public string ODEKOD { get; set; }
        public decimal? BRMALIYET { get; set; }
        public short? KOSVADEGUNU { get; set; }
        public string YAPKOD { get; set; }
        public string GIB_FATIRS_NO { get; set; }
        public string EXTERNALAPPID { get; set; }
    }

    public class DEPO_STHAR_2020 : MyBindableBase
    {
        private decimal? sTHAR_GCMIK;

        [Key]
        public int INCKEYNO { get; set; }

        public string FISNO { get; set; }
        public string STOK_KODU { get; set; }

        [NotMapped]
        public string StokAdi { get; set; }

        [NotMapped]
        public string OlcuBirimAd { get; set; }

        [ForeignKey("STOK_KODU")]
        public DEPO_STSABIT STSABIT_NAV { get; set; }

        public decimal? STHAR_GCMIK { get => sTHAR_GCMIK; set => SetProperty(ref sTHAR_GCMIK, value); }
        public decimal? STHAR_GCMIK2 { get; set; }
        public decimal? CEVRIM { get; set; }
        public string STHAR_GCKOD { get; set; }
        public DateTime STHAR_TARIH { get; set; }
        public decimal? STHAR_NF { get; set; }
        public decimal? STHAR_BF { get; set; }
        public decimal? STHAR_IAF { get; set; }
        public decimal? STHAR_KDV { get; set; }
        public short? DEPO_KODU { get; set; }
        public string STHAR_ACIKLAMA { get; set; }
        public decimal? STHAR_SATISK { get; set; }
        public decimal? STHAR_MALFISK { get; set; }
        public string STHAR_FTIRSIP { get; set; }
        public decimal? STHAR_SATISK2 { get; set; }
        public byte? LISTE_FIAT { get; set; }
        public string STHAR_HTUR { get; set; }
        public byte? STHAR_DOVTIP { get; set; }
        public byte? PROMASYON_KODU { get; set; }
        public decimal? STHAR_DOVFIAT { get; set; }
        public short? STHAR_ODEGUN { get; set; }
        public decimal? STRA_SATISK3 { get; set; }
        public decimal? STRA_SATISK4 { get; set; }
        public decimal? STRA_SATISK5 { get; set; }
        public decimal? STRA_SATISK6 { get; set; }
        public string STHAR_BGTIP { get; set; }
        public string STHAR_KOD1 { get; set; }
        public string STHAR_KOD2 { get; set; }
        public string STHAR_SIPNUM { get; set; }
        public string STHAR_CARIKOD { get; set; }
        public string STHAR_SIP_TURU { get; set; }
        public string PLASIYER_KODU { get; set; }
        public string EKALAN_NEDEN { get; set; }
        public string EKALAN { get; set; }
        public string EKALAN1 { get; set; }
        public decimal? REDMIK { get; set; }
        public byte? REDNEDEN { get; set; }
        public short? SIRA { get; set; }
        public short? STRA_SIPKONT { get; set; }
        public string AMBAR_KABULNO { get; set; }
        public byte? FIRMA_DOVTIP { get; set; }
        public decimal? FIRMA_DOVTUT { get; set; }
        public decimal? FIRMA_DOVMAL { get; set; }
        public string UPDATE_KODU { get; set; }
        public string IRSALIYE_NO { get; set; }
        public DateTime? IRSALIYE_TARIH { get; set; }
        public string KOSULKODU { get; set; }
        public byte? ECZA_FAT_TIP { get; set; }
        public DateTime? STHAR_TESTAR { get; set; }
        public byte? OLCUBR { get; set; }

        public DateTime? VADE_TARIHI { get; set; }
        public string LISTE_NO { get; set; }
        public int? BAGLANTI_NO { get; set; }
        public short SUBE_KODU { get; set; }
        public string MUH_KODU { get; set; }
        public string S_YEDEK1 { get; set; }
        public string S_YEDEK2 { get; set; }
        public decimal? F_YEDEK3 { get; set; }
        public decimal? F_YEDEK4 { get; set; }
        public decimal? F_YEDEK5 { get; set; }
        public string C_YEDEK6 { get; set; }
        public byte? B_YEDEK7 { get; set; }
        public short? I_YEDEK8 { get; set; }
        public int? L_YEDEK9 { get; set; }
        public DateTime? D_YEDEK10 { get; set; }
        public string PROJE_KODU { get; set; }
        public DateTime? FIYATTARIHI { get; set; }
        public DateTime? KOSULTARIHI { get; set; }
        public short? SATISK1TIP { get; set; }
        public short? SATISK2TIP { get; set; }
        public short? SATISK3TIP { get; set; }
        public short? SATISK4TIP { get; set; }
        public short? SATISK5TIP { get; set; }
        public short? SATISK6TIP { get; set; }
        public byte? EXPORTTYPE { get; set; }
        public decimal? EXPORTMIK { get; set; }
        public DateTime? DUZELTMETARIHI { get; set; }
        public string ONAYTIPI { get; set; }
        public int ONAYNUM { get; set; }
        public decimal? KKMALF { get; set; }
        public short? STRA_IRSKONT { get; set; }
        public string YAPKOD { get; set; }
    }










    public class SatinAlmaDbContextYeni : DbContext
    {
        public virtual DbSet<Talep> Talepler { get; set; }
        public virtual DbSet<TalepKalem> TalepKalemler { get; set; }
        public virtual DbSet<TalepKalemTeklif> TalepKalemTeklifler { get; set; }

        public DbSet<CariGecici> CariGeciciListe { get; set; }

        public DbSet<vwStokTanim> StokTanimlar { get; set; }

        public DbSet<OlcuBirim> OlcuBirimleri { get; set; }

        public DbSet<KullanimYer> KullanimYerleri { get; set; }

        public DbSet<IsMerkezi> IsMerkezleri { get; set; }

        public DbSet<PersonelBilgi> Personeller { get; set; }

        public DbSet<SurecTanim> SurecTanimlar { get; set; }

        public DbSet<TeklifIlgiliFirma> TeklifIlgiliFirmalar { get; set; }

        public DbSet<StokGrupTanim> StokGrupTanimlar { get; set; }

        public DbSet<Vw_StokMiktarNetsis> StokMiktarlarNetsis { get; set; }

        public DbSet<Vw_StokAlimFiyatNetsis> StokAlimFiyatlarNetsis { get; set; }

        public DbSet<vwStokTanim> StokTanimlarNetsis { get; set; }

        public DbSet<DEPO_FATUIRS> DepoFatuIrsaliyeler { get; set; }
        public DbSet<DEPO_STHAR> DepoStokHareketler { get; set; }

        public DbSet<DEPO_FATUIRS_2019> DepoFatuIrsaliyeler2019 { get; set; }
        public DbSet<DEPO_STHAR_2019> DepoStokHareketler2019 { get; set; }


        public DbSet<DEPO_FATUIRS_2020> DepoFatuIrsaliyeler2020 { get; set; }
        public DbSet<DEPO_STHAR_2020> DepoStokHareketler2020 { get; set; }

        public DbSet<DEPO_DURUM> DepoDurumlari { get; set; }
        public DbSet<DEPO_MASRAFMERKEZ> MasrafMerkezleri { get; set; }
        public DbSet<DEPO_STSABIT> StokSabit { get; set; }

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
            modelBuilder.Entity<CariGecici>().ToTable(nameof(CariGecici), "App");

            modelBuilder.HasDefaultSchema("SatinAlma");

            modelBuilder.Entity<IsMerkezi>().ToTable(nameof(IsMerkezi));
            modelBuilder.Entity<Talep>().ToTable(nameof(Talep));
            modelBuilder.Entity<TalepKalem>().ToTable(nameof(TalepKalem));

            modelBuilder.Entity<OlcuBirim>().ToTable(nameof(OlcuBirim));
            modelBuilder.Entity<vwStokTanim>().ToTable(nameof(vwStokTanim));

            modelBuilder.Entity<StokGrupTanim>().ToTable(nameof(StokGrupTanim));

            modelBuilder.Entity<Vw_StokMiktarNetsis>().ToTable(nameof(Vw_StokMiktarNetsis));
            modelBuilder.Entity<Vw_StokAlimFiyatNetsis>().ToTable(nameof(Vw_StokAlimFiyatNetsis));

            modelBuilder.Entity<vwStokTanim>().ToTable(nameof(vwStokTanim));

            modelBuilder.Entity<DEPO_FATUIRS>().ToTable("FATUIRS", "NetsisDepo");
            modelBuilder.Entity<DEPO_STHAR>().ToTable("STHAR", "NetsisDepo");

            modelBuilder.Entity<DEPO_FATUIRS_2019>().ToTable("FATUIRS_2019", "NetsisDepo");
            modelBuilder.Entity<DEPO_STHAR_2019>().ToTable("STHAR_2019", "NetsisDepo");

            modelBuilder.Entity<DEPO_FATUIRS_2020>().ToTable("FATUIRS_2020", "NetsisDepo");
            modelBuilder.Entity<DEPO_STHAR_2020>().ToTable("STHAR_2020", "NetsisDepo");


            modelBuilder.Entity<DEPO_DURUM>().ToTable("DEPODURUM", "NetsisDepo");
            modelBuilder.Entity<DEPO_MASRAFMERKEZ>().ToTable("MASRAFMERKEZ", "NetsisDepo");
            modelBuilder.Entity<DEPO_STSABIT>().ToTable("STSABIT", "NetsisDepo");

            base.OnModelCreating(modelBuilder);
        }
    }
}
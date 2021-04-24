using mnd.Logic.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mnd.Logic.BC_SatinAlmaYeni.Domain
{
    public class DEPO_FATUIRS : MyBindableBase
    {
        private string fATIRS_NO;
        private string aCIKLAMA;

        [Key]
        public string FATIRS_NO { get => fATIRS_NO; set => SetProperty(ref fATIRS_NO, value); }

        public string ACIKLAMA { get => aCIKLAMA?.ToUpper(); set =>SetProperty(ref aCIKLAMA ,value); }
        public DEPO_FATUIRS()
        {
            FIS_KALEMLERI = new List<DEPO_STHAR>();
        }

        [ForeignKey("FISNO")]
        public List<DEPO_STHAR> FIS_KALEMLERI { get; set; }

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
}

using mnd.Logic.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mnd.Logic.BC_SatinAlmaYeni.Domain
{
    public class DEPO_STHAR: MyBindableBase
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

        public decimal? STHAR_GCMIK { get => sTHAR_GCMIK; set => SetProperty(ref sTHAR_GCMIK , value); }
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
}
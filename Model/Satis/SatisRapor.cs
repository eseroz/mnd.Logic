using System;
using System.ComponentModel.DataAnnotations;

namespace mnd.Logic.Model.Satis
{
    public class SatisRapor
    {
        [Key]
        public Guid GuidId { get; set; }

        public string SiparisKalemKod { get; set; }
        public int? KalemId { get; set; }
        public decimal? IscilikTutar { get; set; }
        public String IscilikDovizTipKod { get; set; }
        public int? Miktar_kg { get; set; }
        public decimal? BirimFiyat { get; set; }
        public decimal? Kalinlik_micron { get; set; }
        public decimal? En_mm { get; set; }
        public string AlasimTipKod { get; set; }
        public string SertlikTipKod { get; set; }
        public string FATUNO { get; set; }
        public int? FAT_AY { get; set; }
        public DateTime FATTARIH { get; set; }
        public decimal KALEMMIKTAR { get; set; }
        public byte F_DOVTIP { get; set; }
        public string F_DOVIZ { get; set; }
        public double? DOVIZUSDTUTAR { get; set; }
        public decimal? F_MIK { get; set; }
        public decimal? DOVIZTUTAR { get; set; }
        public decimal? GENELTOPLAM { get; set; }
        public decimal? NETTOPLAM { get; set; }

        public string CariIsim { get; set; }
        public string UlkeAd { get; set; }
        public string PlasiyerAd { get; set; }

        public string LmeDovizTipKod { get; set; }
        public decimal? LmeTutar { get; set; }
        public decimal? KulceTutar { get; set; }
        public DateTime? LmeTarih { get; set; }
    }
}
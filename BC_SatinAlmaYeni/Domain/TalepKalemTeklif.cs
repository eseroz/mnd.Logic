using mnd.Logic.Model;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mnd.Logic.BC_SatinAlmaYeni.Domain
{
    [Table(nameof(TalepKalemTeklif), Schema = "SatinAlma")]
    public class TalepKalemTeklif : MyBindableBase
    {
        private bool satinAlmaTercihiMi;
        private bool yoneticiTercihiMi;
        private string teklifVerenFirmaCariKod;
        private string teklifVerenFirmaAd;

        [Key]
        public int TalepKalemTeklifId { get; set; }
        public int TalepId { get; set; }
        public int TalepKalemSiraNo { get; set; }

        public string TeklifVerenFirmaCariKod { get => teklifVerenFirmaCariKod; set => SetProperty(ref teklifVerenFirmaCariKod, value); }
        public string TeklifVerenFirmaAd { get => teklifVerenFirmaAd; set => SetProperty(ref teklifVerenFirmaAd,value); }
        public decimal? TeklifFiyat { get; set; }
       
        public DateTime? TeslimTarihi { get; set; }

          public int TalepKalemId { get; set; }
        public string Marka { get; set; }
        public bool SatinAlmaTercihiMi { get => satinAlmaTercihiMi; set => SetProperty(ref satinAlmaTercihiMi, value); }
        public bool YoneticiTercihiMi { get => yoneticiTercihiMi; set => SetProperty(ref yoneticiTercihiMi, value); }
        public string DovizTip { get; set; }
        public decimal? Miktar { get; set; }
    }
}

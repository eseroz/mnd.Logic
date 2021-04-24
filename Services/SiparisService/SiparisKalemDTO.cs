using mnd.Logic.Model.Netsis;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace mnd.Logic.Services.SiparisService
{
    public class SiparisKalemDTO
    {
        public string SiparisKalemKod { get; set; }

        public Guid KalemRowGuid { get; set; }

        [ForeignKey(nameof(SiparisNavigation))]
        public string SiparisKod { get; set; }

        public SiparisDTO SiparisNavigation { get; set; }

        public SiparisKalemDTO()  {
        
        }

        public string UrunKod { get; set; }

        private int id;
        private string urunKod;
        private string urunAdiTR;
        private string urunAdiEN;
        private double? gR;
        private double? pCS;
        private double? bOX;
        private double? nETKG;
        private double? gROSS;
        private double? w;
        private double? l;
        private double? h;
        private double? m3;
        private double? cRTN;
        private string teklifKalemSiraKod;
        private string teklifSiraKod;
        private decimal satisFiyati;
        private decimal? tutar;
        private decimal butce;
        private int miktar;
        private DateTime teslimTarihi;


        public DateTime TeslimTarihi { get => teslimTarihi; set => teslimTarihi = value; }
        public decimal SatisFiyati { get => satisFiyati; set => satisFiyati = value; }
        public decimal? Tutar { get => tutar; set => tutar = value; }
        public int Miktar { get => miktar; set => miktar = value; }
        public string UrunAdiTR { get => urunAdiTR; set => urunAdiTR=value; }
        public string UrunAdiEN { get => urunAdiEN; set => urunAdiEN = value; }
        public double? GR { get => gR; set => gR = value; }
        public double? PCS { get => pCS; set => pCS = value; }
        public double? BOX { get => bOX; set => bOX = value; }
        public double? NETKG { get => nETKG; set => nETKG = value; }
        public double? GROSS { get => gROSS; set => gROSS = value; }
        public double? W { get => w; set => w = value; }
        public double? L { get => l; set => l = value; }
        public double? H { get => h; set => h = value; }
        public double? M3 { get => m3; set => m3 = value; }
        public double? CRTN { get => cRTN; set => cRTN = value; }
        public decimal? GenelToplamTutar { get; set; }


        //public string GrupDurum { get; set; }
        //public string UretimEmriKod { get; set; }
        //public decimal PlanlamaGuncelMiktar { get; set; }
        //public string AlasimTipAd { get; set; }
        //public string SertlikTipAd { get; set; }
        //public string MasuraTipAd { get; set; }
        //public string YuzeyTipAd { get; set; }
        //public string AmbalajTipAd { get; set; }
        //public string KullanimAlanTipAd { get; set; }
        //public decimal? KalemFaturaMiktarlariKg { get; set; }
        //public int MaxEk { get; set; }
        //public decimal Kalinlik { get; set; }
        //public string KalinlikDurum { get { if (Kalinlik > 60) return "K"; else return "İ"; } }
        //public int KalinlikArti { get; set; } //%
        //public int KalinlikEksi { get; set; } //%
        //public int Metraj { get; set; }
        //public int MetrajArti { get; set; } //%
        //public int MetrajEksi { get; set; } //%
        //public decimal En { get; set; }
        //public decimal EnArti { get; set; }
        //public decimal EnEksi { get; set; }
        //public int RuloAgirlikMax { get; set; }
        //public int RuloAgirlikMin { get; set; }
        //public int RuloDiscapMax { get; set; }
        //public int RuloDiscapMin { get; set; }
        //public int RuloIcCap { get; set; }
        //public int Miktar_kg { get; set; }
        //public int UretimdekiMiktar { get; set; }
        //public decimal UretimdekiMiktarYuzde { get; set; }
        //public int PlanlananMiktar { get; internal set; }
        //public int PlanlamaBakiye { get; set; }
        //public int PaketlenenMiktar { get; set; }
        //public int FireMiktar { get; set; }
        //public string SevkHaftasi { get; set; }
        //public string TeslimHaftasi { get; set; }
        //public string UlkeKodIso { get; set; }
        //public DateTime? Tarih { get; set; }
        //public decimal? IscilikTutar { get; set; }
        //public decimal KulcePrimi { get; set; }
        //public string KartNo { get; set; }
        //public int? PlanlamaDurum { get; set; }
        //public bool PlanlamaSevkOnayliMi { get; set; }
        //public int? UretimKalanMiktar { get; set; }
        //public bool? SiparisKalemKapatildiMi { get; set; }
        //public string SiparisKalemKapaliDurum => SiparisKalemKapatildiMi.GetValueOrDefault() == true ? "Kapalı" : "Açık";
        //public decimal? TFaturaKalemMiktarlariKg { get; set; }
        //public decimal? KalemIsyuku { get; set; }
        //public object CariIsim { get; set; }
        //public int KalemUretimBakiye { get; set; }
        //public int KalemPaketlenenMiktar { get; set; }
        //public IEnumerable<UretimEmriDTO> UretimEmirleriDTO_List { get; set; }
        //public int? PLAN_UretimdekiMiktarToplam { get;  set; }
        //public int? PLAN_PlanlanacakKalanMiktarToplam { get;  set; }
        //public decimal? LmeTutar { get;  set; }
        //public string LmeBaglamaKod { get;  set; }
        //public decimal? IscilikVadeFarkiTutar { get;  set; }
        //public decimal? IscilikVadeFarkiOran { get; internal set; }
        //public decimal? KdvOran { get; internal set; }
    }
}
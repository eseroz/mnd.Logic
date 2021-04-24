using Newtonsoft.Json;
using mnd.Common.Helpers;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mnd.Logic.Model.Satis
{
    public partial class SiparisKalem : MyBindableBase
    {
        [Key]
        public string SiparisKalemKod
        {
            get => siparisKalemKod;
            set => SetProperty(ref siparisKalemKod, value);
        }
        public string SiparisKod { get; set; }
        public DateTime TeslimTarihi { get => teslimTarihi; set => teslimTarihi = value; }
        public string MusteriUrunKodu { get; set; }
        public string UrunKod { get => urunKod; set => SetProperty(ref urunKod, value); }
        public string UrunAdiTR { get => urunAdiTR; set => SetProperty(ref urunAdiTR, value); }
        public string UrunAdiEN { get => urunAdiEN; set => SetProperty(ref urunAdiEN, value); }
        public decimal? GR { get => gR; set => SetProperty(ref gR, value); }
        public decimal? PCS { get => pCS; set => SetProperty(ref pCS, value); }
        public decimal? BOX { get => bOX; set => SetProperty(ref bOX, value); }
        public decimal? NETKG { get => nETKG; set => SetProperty(ref nETKG, value); }
        public decimal? GROSS { get => gROSS; set => SetProperty(ref gROSS, value); }
        public decimal? W { get => w; set => SetProperty(ref w, value); }
        public decimal? L { get => l; set => SetProperty(ref l, value); }
        public decimal? H { get => h; set => SetProperty(ref h, value); }
        public decimal? M3 { get => m3; set => SetProperty(ref m3, value); }
        public decimal? CRTN { get => cRTN; set => SetProperty(ref cRTN, value); }
        public decimal? BirimFiyat
        {
            get => birimFiyat.GetValueOrDefault();
            set => SetProperty(ref birimFiyat, value);
        }        
        public decimal? KdvOran
        {
            get => kdvOran;
            set => SetProperty(ref kdvOran, value);
        }
        public decimal? Miktar { get => miktar; set => SetProperty(ref miktar, value); }
        public decimal? KdvTutar
        {
            get => kdvTutar.GetValueOrDefault();
            set => SetProperty(ref kdvTutar, value);
        }
        public decimal? Tutar { get => tutar; set => SetProperty(ref tutar, value); }
        public decimal? GenelToplamTutar
        {
            get => genelToplamTutar;
            set => SetProperty(ref genelToplamTutar, value);
        }
        public decimal Butce { get => butce; set => SetProperty(ref butce, value); }

        public string CreatedUserId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string LastEditedBy { get; set; }
        public DateTime? LastEditedDate { get; set; }
        public Guid? RowGuid { get; set; }

        public void GenelToplamlariGuncelle()
        {              
            BirimFiyat = Math.Round(BirimFiyat.GetValueOrDefault(), 3);
            Tutar = BirimFiyat * Miktar;
            KdvTutar = Tutar * kdvOran / (decimal)100.0;
            GenelToplamTutar = (Tutar + KdvTutar);
        }

        [JsonIgnore]
        public Siparis SiparisNav { get; set; }

        [NotMapped]
        public KayitModu KayitModu { get; set; }
        [NotMapped]
        public bool SatirSecildiMi
        {
            get => satirSecildiMi;
            set => SetProperty(ref satirSecildiMi, value);
        }
        [NotMapped]
        public int MesajSayisi { get => _mesajSayisi; set => SetProperty(ref _mesajSayisi, value); }
        [NotMapped]
        public int OkunmamisMesajSayisi { get => _okunmamisMesajSayisi; set => SetProperty(ref _okunmamisMesajSayisi, value); }
        //public string RevizeSevkHaftasi { get => revizeSevkHaftasi; set => SetProperty(ref revizeSevkHaftasi , value); }        
        [NotMapped]
        public string SevkYilAy { get;  set; }

        private string urunKod;
        private string urunAdiTR;
        private string urunAdiEN;
        private decimal? gR;
        private decimal? pCS;
        private decimal? bOX;
        private decimal? nETKG;
        private decimal? gROSS;
        private decimal? w;
        private decimal? l;
        private decimal? h;
        private decimal? m3;
        private decimal? cRTN;
        private decimal? tutar;
        private decimal butce;
        private decimal? birimFiyat;
        private decimal? miktar;
        private DateTime teslimTarihi;
        private string siparisKalemKod;
        private bool satirSecildiMi;
        private int _mesajSayisi;
        private int _okunmamisMesajSayisi;
        private string revizeSevkHaftasi;
        private decimal? kdvTutar;
        private decimal? kdvOran;
        private decimal? genelToplamTutar;
    }
}
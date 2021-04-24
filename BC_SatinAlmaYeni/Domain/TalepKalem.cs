using Newtonsoft.Json;
using mnd.Logic.Model;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mnd.Logic.BC_SatinAlmaYeni.Domain
{
    [Table(nameof(TalepKalem), Schema = "SatinAlma")]
    public class TalepKalem : MyBindableBase
    {
        private int _siraNo;
        private int _mesajSayisi;
        private int _okunmamisMesajSayisi;
        private Guid _rowGuid;
        private string _tercihMarkaModel;
        private DateTime? _istenilenTarih;
        private decimal? verilenMiktar;
        private string stokKod;
        private string stokAd;
        private bool sec;
        private DateTime? teklifeAktarilmaTarihi;
        private int? aktarilanTeklifId;
        private decimal? talepZamaniDepoMiktar;
        private string aciklama;
        private decimal? siparisGelenMiktar;
        private string ırsaliyeNo;
        private DateTime? ırsaliyeTarihi;
        private bool? seciliMi;
        private bool secilebilirMi;
        private bool? yoneticiKalemIptalMi;

        [Key]
        public int TalepKalemId { get; set; }
        public int TalepId { get; set; }

        public int? IlkTalepId { get; set; }


        [NotMapped]
        public bool Sec { get => sec; set => SetProperty(ref sec, value); }
        public int SiraNo { get => _siraNo; set => SetProperty(ref _siraNo, value); }
        public DateTime? IstenilenTarih { get => _istenilenTarih; set => SetProperty(ref _istenilenTarih, value); }
        public string StokKod { get => stokKod; set => SetProperty(ref stokKod, value); }
        public string Birim { get; set; }
        public decimal Miktar { get; set; }

        public decimal? DepoStokMiktar { get; set; }

        public decimal? TalepZamaniDepoMiktar { get => talepZamaniDepoMiktar; set => SetProperty(ref talepZamaniDepoMiktar, value); }

        public decimal? VerilenMiktar { get => verilenMiktar.GetValueOrDefault(); set => SetProperty(ref verilenMiktar, value); }


        public string Aciklama { get => aciklama; set => SetProperty(ref aciklama, value); }

        public DateTime? TeklifeAktarilmaTarihi { get => teklifeAktarilmaTarihi; set => SetProperty(ref teklifeAktarilmaTarihi, value); }


        public string StokGrupAd { get; set; }

        public string StokGrupKod { get; set; }

        public string TalepEdenAdSoyad { get; set; }

        public string IsMerkeziAd { get; set; }



        public string SiparisEdilenMarka { get; set; }

        public string SiparisCariAd { get; set; }

        public string SiparisCariKod { get; set; }

        public DateTime? SiparisTeslimTarihi { get; set; }

        public int? AktarilanTeklifId { get => aktarilanTeklifId; set => SetProperty(ref aktarilanTeklifId, value); }


        [NotMapped]
        public bool GelenMiktarGirebilirMi => IrsaliyeNo == null;


        public decimal KdvOran { get; set; }

        public decimal? SiparisGelenMiktar { get => siparisGelenMiktar; set => SetProperty(ref siparisGelenMiktar, value); }

        public string IrsaliyeNo { get => ırsaliyeNo; set => SetProperty(ref ırsaliyeNo, value); }
        public DateTime? IrsaliyeTarihi { get => ırsaliyeTarihi; set => SetProperty(ref ırsaliyeTarihi, value); }


        public string StokAd { get => stokAd; set => SetProperty(ref stokAd, value); }
        public ObservableCollection<TalepKalemTeklif> TalepKalemTeklifler { get; set; }

        public string TercihMarkaModel { get => _tercihMarkaModel; set => SetProperty(ref _tercihMarkaModel, value); }


        [NotMapped]
        [JsonIgnore]
        public int MesajSayisi { get => _mesajSayisi; set => SetProperty(ref _mesajSayisi, value); }

        [NotMapped]
        [JsonIgnore]
        public int OkunmamisMesajSayisi { get => _okunmamisMesajSayisi; set => SetProperty(ref _okunmamisMesajSayisi, value); }

        public Guid RowGuid { get => _rowGuid; set => SetProperty(ref _rowGuid, value); }


        public bool? SeciliMi { get => seciliMi.GetValueOrDefault(); set => SetProperty(ref seciliMi, value); }

        public bool SecilebilirMi => TeklifeAktarilmaTarihi == null;

        public decimal? SiparisBirimFiyat { get; set; }
        public decimal? SiparisToplamFiyat { get; set; }
        public string SiparisDovizCinsi { get; set; }
        public string KalemTip { get; set; }


        public bool? YoneticiKalemIptalMi { get => yoneticiKalemIptalMi.GetValueOrDefault(); set => SetProperty(ref yoneticiKalemIptalMi, value); }

    }
}

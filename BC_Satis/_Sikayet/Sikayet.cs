using Newtonsoft.Json;
using mnd.Logic.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mnd.Logic.BC_Satis._Sikayet
{
    public class Sikayet : MyBindableBase
    {
        private int _okunmamisMesajSayisi1;
        private int mesajSayisi;
        private string sikayetEdenFirmaKod;
        private string sikayetFirmaAd;
        private string surecKonum;
        private string sikayetEdenFirmaKod1;
        private string pandaSiparisKod;
        private string paletListe;
        private string sikayetKonuBolum;
        private List<object> seciliSikayetBolumleri;
        private decimal? ıadeMiktari;
        private string duzeltmeOnlemeFaliyetNo;
        private string teslimNot;
        private string konuDetay;

        [Key]
        public int Id { get; set; }

        public int Yil => SikayetTarihi.Year;

        public string GelisYolu_Ref { get; set; }
        public DateTime SikayetTarihi { get; set; }

        public string PandaSiparisKod { get => pandaSiparisKod; set => SetProperty(ref pandaSiparisKod, value); }

        public string PaletListe { get => paletListe; set => SetProperty(ref paletListe, value); }

        public string SikayetEdenFirmaKod { get => sikayetEdenFirmaKod1; set => SetProperty(ref sikayetEdenFirmaKod1, value); }

        public string SikayetFirmaAd { get => sikayetFirmaAd; set => SetProperty(ref sikayetFirmaAd, value); }

        public string SikayetEdenKisi { get; set; }

        public string FirmaSikayetEdenBirlesik => SikayetFirmaAd + Environment.NewLine + SikayetEdenKisi ?? "";


        public string KonuKategoriAdi { get; set; }
        public string Konusu { get; set; }
        public string KonuDetay { get => konuDetay; set => SetProperty(ref konuDetay, value); }

        public string KonuDetayBirlesik => Konusu + Environment.NewLine + KonuDetay ?? "";

        public string SikayetKonuBolumleriMetin { get => sikayetKonuBolum; set => SetProperty(ref sikayetKonuBolum, value); }
        public string SikayetKonuUrun { get; set; }

        public decimal? SikayetMiktari { get; set; }

        public decimal? IadeMiktari { get => ıadeMiktari; set => SetProperty(ref ıadeMiktari, value); }

        public string DuzeltmeOnlemeFaliyetNo { get => duzeltmeOnlemeFaliyetNo; set => SetProperty(ref duzeltmeOnlemeFaliyetNo, value); }


        public string SikayetDurum { get; set; }

        public string SurecKonum { get => surecKonum; set => SetProperty(ref surecKonum, value); }

        public string TeslimNot { get => teslimNot; set => SetProperty(ref teslimNot, value); }

        public Guid RowGuid { get; set; }

        [NotMapped]
        public List<object> SeciliSikayetBolumleri { get => seciliSikayetBolumleri; set => SetProperty(ref seciliSikayetBolumleri, value); }

        [JsonIgnore]
        [NotMapped]
        public int MesajSayisi { get => mesajSayisi; set => SetProperty(ref mesajSayisi, value); }

        [JsonIgnore]
        [NotMapped]
        public int OkunmamisMesajSayisi { get => _okunmamisMesajSayisi1; set => SetProperty(ref _okunmamisMesajSayisi1, value); }

    }
}
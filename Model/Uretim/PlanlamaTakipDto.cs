using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace mnd.Logic.Model.Uretim
{
    public class PlanlamaTakipDto : MyBindableBase
    {
        public string UretimEmriKod { get; set; }
        public bool UretimKapatildiMi { get; set; }

        public string KalemSiparisDurum { get; set; }
        public string SiparisDurum { get; set; }

        private bool seciliMi;

        public bool SeciliMi
        {
            get => seciliMi;
            set => SetProperty(ref seciliMi, value);
        }

        public string SiparisKod { get; set; }
        public string SiparisKalemKod { get; set; }
        public string KartNo { get; set; }

        public string BagliBobinler { get; set; }
        public string MusteriAd { get; set; }
        public string Alasim { get; set; }
        public decimal? Kalinlik { get; set; }
        public decimal? En { get; set; }
        public int? IcCap { get; set; }
        public int? MinCap { get; set; }
        public int? MaxCap { get; set; }
        public string Kondusyon { get; set; }
        public int? Ek { get; set; }
        public string Yuzey { get; set; }
        public string MasuraCins { get; set; }
        public int? Metraj { get; set; }
        public string MetrajTolerans { get; set; }
        public string KalinlikToleransYuzde { get; set; }
        public string EnTolerans_mm { get; set; }
        public string Ambalaj { get; set; }
        public string SevkHafta { get; set; }

        public string KullanimAlani { get; set; }

        private int? pas1;

        public int? Pas1
        {
            get => pas1;
            set => SetProperty(ref pas1, value);
        }

        private int? pas2;

        public int? Pas2
        {
            get => pas2;
            set => SetProperty(ref pas2, value);
        }

        private int? pas3;

        public int? Pas3
        {
            get => pas3;
            set => SetProperty(ref pas3, value);
        }

        private int? pas4;

        public int? Pas4
        {
            get => pas4;
            set => SetProperty(ref pas4, value);
        }

        private int? pas5;

        public int? Pas5
        {
            get => pas5;
            set => SetProperty(ref pas5, value);
        }

        //Üretim Takip Manual Giriş-------------------------

        private int? seperator1;

        public int? Seperator1
        {
            get => seperator1;
            set => SetProperty(ref seperator1, value);
        }

        private int? seperator2;

        public int? Seperator2
        {
            get => seperator2;
            set => SetProperty(ref seperator2, value);
        }

        private int? dilme;

        public int? Dilme
        {
            get => dilme;
            set => SetProperty(ref dilme, value);
        }

        private int? tavaGirecek;

        public int? TavaGirecek
        {
            get => tavaGirecek;
            set => SetProperty(ref tavaGirecek, value);
        }

        private int? tavda;

        public int? Tavda
        {
            get => tavda;
            set => SetProperty(ref tavda, value);
        }

        private int? tavdanCikan;

        public int? TavdanCikan
        {
            get => tavdanCikan;
            set => SetProperty(ref tavdanCikan, value);
        }

        private int? paketlenecek;

        public int? Paketlenecek
        {
            get => paketlenecek;
            set => SetProperty(ref paketlenecek, value);
        }

        private int? sp_Dilme_Cikis;

        public int? Sp_Dilme_Cikis
        {
            get => sp_Dilme_Cikis;
            set => SetProperty(ref sp_Dilme_Cikis, value);
        } // manual

        private int paketlenenMiktar;

        // veritabanından den çekilecek
        public int PaketlenenMiktar
        {
            get => paketlenenMiktar;
            set => SetProperty(ref paketlenenMiktar, value);
        }

        private DateTime? uretimEmriSonPaketlenmeTarihi;

        public DateTime? UretimEmriSonPaketlenmeTarihi
        {
            get => uretimEmriSonPaketlenmeTarihi;
            set => SetProperty(ref uretimEmriSonPaketlenmeTarihi, value);
        } // tarih saat depo kabulden

        private int planlananMiktar;

        public int PlanlananMiktar
        {
            get => planlananMiktar;
            set => SetProperty(ref planlananMiktar, value);
        }

        private int? kalemMiktar;

        public int? KalemMiktar
        {
            get => kalemMiktar;
            set => SetProperty(ref kalemMiktar, value);
        }

        private int bakiye;

        public int Bakiye
        {
            get => bakiye;
            set => SetProperty(ref bakiye, value);
        }


        public int UretimdeYuruyenMiktar { get; set; }

        public int FolyoHaddeToplam { get; set; }


        public string Key { get; set; }
        public string ParentKey { get; set; }
        private bool kapatildiMi;

        public bool KapatildiMi
        {
            get => kapatildiMi;
            set => SetProperty(ref kapatildiMi, value);
        }

        public bool Yuzde12_Kisit { get; set; }
        private string ambalajKafesOlcu;

        public string AmbalajKafesOlcu
        {
            get => ambalajKafesOlcu;
            set => SetProperty(ref ambalajKafesOlcu, value);
        }

        private string planlamaRulolari;

        public string PlanlamaRulolari
        {
            get => planlamaRulolari;
            internal set => SetProperty(ref planlamaRulolari, value);
        }

        private string dokmeRuloNumaralari;

        public string DokmeRuloNumaralari
        {
            get => dokmeRuloNumaralari;
            internal set => dokmeRuloNumaralari = value;
        }

        private int? kartaBagliToplamPaketMiktar_Kg;

        public int? KartaBagliToplamPaketMiktar_kg
        {
            get => kartaBagliToplamPaketMiktar_Kg;
            internal set => SetProperty(ref kartaBagliToplamPaketMiktar_Kg, value);
        }

       

        private int? kombinMiktari_Kg;

        public int? KombinMiktari_kg
        {
            get => kombinMiktari_Kg;
            set => kombinMiktari_Kg = value;
        }

        private decimal? kombinEniAgirOrt_Mm;

        public decimal? KombinEniAgirOrt_mm
        {
            get => kombinEniAgirOrt_Mm;
            set => SetProperty(ref kombinEniAgirOrt_Mm, value);
        }

        private decimal? kombinVerimi_Yuzde;

        public decimal? KombinVerimi_yuzde
        {
            get => kombinVerimi_Yuzde;
            set => SetProperty(ref kombinVerimi_Yuzde, value);
        }

        private int? dokumMiktari_Kg;

        public int? DokumMiktari_kg
        {
            get => dokumMiktari_Kg;
            set => dokumMiktari_Kg = value;
        }

        private int? kombinFire_Yuzde;

        public int? KombinFire_yuzde
        {
            get => kombinFire_Yuzde;
            set => SetProperty(ref kombinFire_Yuzde, value);
        }

        private decimal? geometrikFire_Yuzde;

        public decimal? GeometrikFire_yuzde
        {
            get => geometrikFire_Yuzde;
            set => geometrikFire_Yuzde = value;
        }

        private decimal? ısletmeFire_Yuzde;

        public decimal? IsletmeFire_yuzde
        {
            get => ısletmeFire_Yuzde;
            set => SetProperty(ref ısletmeFire_Yuzde, value);
        }

        private decimal? genelVerimYuzde;

        public decimal? GenelVerimYuzde
        {
            get => genelVerimYuzde;
            set => genelVerimYuzde = value;
        }

        private DateTime? kartTamamlanmaTarihi;

        public DateTime? KapatilmaTarihi
        {
            get => kartTamamlanmaTarihi;
            set => kartTamamlanmaTarihi = value;
        }

        private DateTime? tumKartTamamTarihi;
        private int _mesajSayisi;
        private int _okunmamisMesajSayisi;
        //private string revizeSevkHaftasi;
        private string sevkHaftasiSon;
        private int uretimdekiMiktar;
        private int folyoHaddeToplam;
        private int kaliteRedMiktar;

        public DateTime? TumKartTamamTarihi
        {
            get => tumKartTamamTarihi;
            set => SetProperty(ref tumKartTamamTarihi, value);
        }
        public Guid? RowGuid { get; set; }

        [NotMapped]
        public int MesajSayisi { get => _mesajSayisi; set => SetProperty(ref _mesajSayisi, value); }

        [NotMapped]
        public int OkunmamisMesajSayisi { get => _okunmamisMesajSayisi; set => SetProperty(ref _okunmamisMesajSayisi, value); }
        //public string RevizeSevkHaftasi { get => revizeSevkHaftasi; set => SetProperty(ref revizeSevkHaftasi, value); }
        public string SevkHaftasiSon { get => sevkHaftasiSon; set => SetProperty(ref sevkHaftasiSon, value); }
        public string UretimUrunGrup { get; set; }
        public string KapasitifDurum { get; set; }
        public int MiktarKg { get; set; }
        public string SevkYilAy { get; set; }

      
        public int PlanlanacakBakiye { get; set; }
        public string TeslimHafta { get; set; }
        public string PlanlamaVarMi { get; set; }
   
        public string KaydiriciOraniMinMaxStr { get; set; }
        public int KaliteRedMiktar { get => kaliteRedMiktar; set => SetProperty(ref kaliteRedMiktar ,value); }
        public int ToplamPlanlanacakVeUretimdeki { get;  set; }
        public int HaftalikTonaj { get;  set; }
        public string AnaKartNo { get; set; }
        public int? MaxKombinEni { get;  set; }
        public double? KombinlerEnToplam { get;  set; }
      
        public int? DokumEni_mm { get;  set; }
        public DateTime EklenmeTarih { get; internal set; }
      
        public string Kombinler { get; internal set; }
        public string KullanimAlanUrunGrup { get;  set; }


        public ObservableCollection<UretimEmriRulo> KartPlanlamaRulolari { get; set; }
        public ObservableCollection<UretimEmri> UretimEmirleri { get; set; }
        public int PaketKarantinaMiktar { get;  set; }
    }
}
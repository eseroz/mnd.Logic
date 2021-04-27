using mnd.Common;
using mnd.Common.Helpers;
using mnd.Logic.BC_MusteriTakip.Domain;
using mnd.Logic.Model._Ref;
using mnd.Logic.Model.Muhasebe;
using mnd.Logic.Model.Netsis;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace mnd.Logic.Model.Satis
{
    public class PandapCari : MyBindableBase
    {
        private string _cariTip;
        private decimal? _pandapSiparisRiski;
        private int _toplamOnayliTonajMiktari;
        private decimal? _pandapUretimRiski;
        private int? _uretimdekiMiktar;
        private int _sonBirAyIcindeGorusmeSayisi;
        private string _toDo;
        private string _toDoGuncelleyen;
        private int? _butce;
        private int kalanIsYuku;
        private int toplamSiparisMiktari;
        private int? tonaj2017;
        private int? tonaj2018;
        private int? tonaj2019;
        private string kategoriHarf;
        private decimal? musteriSevkEmirleriRiski;
        private decimal? satisYeniKayitRiski;
        private int sevkEdilenPaletMiktarTon;
        private decimal aktifSevkEmriRiski;
        private decimal? netsisMusteriCekRiski;
        private decimal? netsisKendiCekRiski;
        private string decimalKoordinat;
        private int? tonaj2020;
        private string sonGuncelleyen;
        private DateTime? sonGuncellemeTar;
        private decimal? eximBankKod;
        private string pandaMusteriSorumlusu;
        private string pandaAgent;
        private string pandaSahaSorumlusu;
        private string musteriKullanimAlanTipKod;
        private decimal? dbsLimit;
        private int? tonaj2021;
        private bool plasiyereAitMusteriMi;

        [Key]
        public string CariKod { get; set; }

        public string CariIsim { get; set; }

        public string CariTip { get => _cariTip; set => SetProperty(ref _cariTip, value); }

        public string PandaMusteriSorumluKod { get; set; }

        public string PlasiyerKod { get; set; }

        public string PandaMusteriSorumlusu { get => pandaMusteriSorumlusu; set => SetProperty(ref pandaMusteriSorumlusu, value); }
        public string PandaAgent { get => pandaAgent; set => SetProperty(ref pandaAgent, value); }
        public string PandaSahaSorumlusu { get => pandaSahaSorumlusu; set => SetProperty(ref pandaSahaSorumlusu, value); }

        public bool PlasiyereAitMusteriMi { 
            get => plasiyereAitMusteriMi;
            set
            {
                SetProperty(ref plasiyereAitMusteriMi, value);
            }                    
        }

        public string CariTel { get; set; }
        public string CariIl { get; set; }
        public string UlkeKod { get; set; }
        public string UlkeAd { get; set; }

        public string MusteriKullanimAlanTipKod { get => musteriKullanimAlanTipKod; set => SetProperty(ref musteriKullanimAlanTipKod, value); }


        [NotMapped]
        public KullanimAlanTip KullanimAlanNavigation { get; set; }

        public bool? PasifMi { get; set; }

        public int? YillikKapasiteTonaj { get; set; }


        public int EximBitisTarihi_BitisKalanGun =>
            (EximBitisTarih.GetValueOrDefault() - DateTime.Now).Days < 0 ? 0
            : (EximBitisTarih.GetValueOrDefault() - DateTime.Now).Days;
        public string CariFinansalNot { get; set; }

        public string CariAdres { get; set; }

        public string CariSevkAdres { get; set; }

        public string CariIlce { get; set; }
        public string VergiDairesi { get; set; }
        public string VergiNumarasi { get; set; }
        public byte? DovizTipNetsisKod { get; set; }
        public string DovizAd { get; set; }

        public string Fax { get; set; }
        public string Email { get; set; }
        public string Web { get; set; }

        public string DecimalKoordinat { get => decimalKoordinat; set => SetProperty(ref decimalKoordinat, value); }
        public string MapsAramaUrl { get; set; }

        public string OdemeBankaKod { get; set; }



        public decimal? DbsLimit { get => dbsLimit; set => SetProperty(ref dbsLimit, value); }

        public decimal? EximBankKod { get => eximBankKod; set => SetProperty(ref eximBankKod, value); }

        public decimal? EximBankLimit { get; set; }

        public DateTime? EximBaslangicTarih { get; set; }
        public DateTime? EximBitisTarih { get; set; }

        public decimal? GarantiFactoringLimit { get; set; }
        public decimal? IngFactoringLimit { get; set; }
        public decimal? BankaTeminati { get; set; }

        public decimal? YoneticiSevkLimit { get; set; }

        public decimal? YoneticiSiparisLimit { get; set; }


        public decimal? NetsisBorcBakiye { get; set; }
        public decimal? NetsisBorcDovizBakiye { get; set; }


        public List<Siparis> Siparisler { get; set; }


        public List<NetsisCariHareket> CariHareketler { get; set; }


        public decimal? AcikHesap
        {
            get
            {
                if (DovizAd == "TL") return NetsisBorcBakiye;
                return NetsisBorcDovizBakiye;
            }
        }

        [NotMapped]
        public decimal? MusteriDepoRiski
        {
            get => _pandapSiparisRiski.GetValueOrDefault();
            set
            {
                SetProperty(ref _pandapSiparisRiski, value);

            }
        }

        [NotMapped]
        public decimal? UretimRiski
        {
            get => _pandapUretimRiski.GetValueOrDefault();
            set
            {
                SetProperty(ref _pandapUretimRiski, value);

            }
        }

        [NotMapped]
        public decimal? MusteriSevkEmirleriRiski
        {
            get
            {
                return musteriSevkEmirleriRiski.GetValueOrDefault();
            }
            set
            {
                SetProperty(ref musteriSevkEmirleriRiski, value);

            }
        }

        [NotMapped]
        public decimal AktifSevkEmriRiski { get => aktifSevkEmriRiski; set => aktifSevkEmriRiski = value; }


        [NotMapped]
        public decimal? UretilecekOnayliSiparislerTutar { get; set; }

        [NotMapped]
        public decimal? SatisYeniKayitRiski { get => satisYeniKayitRiski.GetValueOrDefault(); set => SetProperty(ref satisYeniKayitRiski, value); }


        public decimal? NetsisMusteriCekRiski { get => netsisMusteriCekRiski.GetValueOrDefault(); set => netsisMusteriCekRiski = value; }
        public decimal? NetsisKendiCekRiski { get => netsisKendiCekRiski.GetValueOrDefault(); set => netsisKendiCekRiski = value; }

        public decimal? ToplamLimit
        {
            get
            {
                var limit = EximBankLimit.GetValueOrDefault()
                + DbsLimit.GetValueOrDefault()
                + GarantiFactoringLimit.GetValueOrDefault()
                + IngFactoringLimit.GetValueOrDefault()
                + BankaTeminati.GetValueOrDefault()
                + YoneticiSevkLimit.GetValueOrDefault()
                + YoneticiSiparisLimit.GetValueOrDefault();


                if (RiskTalepYer == RISKHESAPSEKLI.Operasyon) limit = limit - YoneticiSiparisLimit.GetValueOrDefault();

                return limit;
            }
        }



        //açık hesap 0 dan küçükse alacaklı anlamına geliyor
        public decimal? ToplamRisk
        {
            get
            {
                if (RiskTalepYer == RISKHESAPSEKLI.GenelTakip)
                {
                    return AcikHesap.GetValueOrDefault()
                         + NetsisMusteriCekRiski.GetValueOrDefault()
                         + NetsisKendiCekRiski.GetValueOrDefault();
                }

                else if (RiskTalepYer == RISKHESAPSEKLI.Operasyon)
                {
                    return AcikHesap.GetValueOrDefault()
                          + NetsisMusteriCekRiski.GetValueOrDefault()
                          + NetsisKendiCekRiski.GetValueOrDefault()
                          + AktifSevkEmriRiski;

                }

                else if (RiskTalepYer == RISKHESAPSEKLI.Satış)
                {
                    return AcikHesap.GetValueOrDefault()
                         + NetsisMusteriCekRiski.GetValueOrDefault()
                         + NetsisKendiCekRiski.GetValueOrDefault()
                         + MusteriDepoRiski.GetValueOrDefault()
                         + MusteriSevkEmirleriRiski.GetValueOrDefault();
                }
                else
                    return 0;

            }
        }

        public decimal KullanilabilirLimit
        {
            get
            {
                var limit = ToplamLimit.GetValueOrDefault() - ToplamRisk.GetValueOrDefault();
                return limit;
            }
        }

        [NotMapped]
        public int? DepodakiUrunMiktarKg { get; set; }



        [NotMapped]
        public List<MetinVeTamsayi> OnayliSiparisKodVeMiktarlari { get; set; }


        public string HataMetni
        {
            get
            {
                if (EximBankLimit.GetValueOrDefault() > 0 && GarantiFactoringLimit > 0 && IngFactoringLimit > 0)
                    return "E/G/İ";

                if (EximBankLimit.GetValueOrDefault() > 0 && GarantiFactoringLimit > 0)
                    return "E/G";

                if (GarantiFactoringLimit > 0 && IngFactoringLimit > 0)
                    return "F/İ";

                if (EximBankLimit.GetValueOrDefault() > 0 && IngFactoringLimit > 0)
                    return "E/İ";


                return "";
            }
        }

        public int HataMetinUzunluk => HataMetni.Length;

        [NotMapped]
        public int? UretimdekiMiktar { get => _uretimdekiMiktar; set => SetProperty(ref _uretimdekiMiktar, value); }


        public List<CariEmailYeni> CariEmailler { get; set; }

        public List<Gorusme> Gorusmeler { get; set; }



        public int GorusmeSayisi => Gorusmeler.Count;

        public int SonBirAyIcindeGorusmeSayisi
        {
            get
            {
                var sayi = Gorusmeler.Where(c => c.GorusmeTarih > DateTime.Now.AddMonths(-1)).Count();
                return sayi;
            }
        }


        public int? Butce { get => _butce; set => SetProperty(ref _butce, value); }
        public string ToDo { get => _toDo; set => SetProperty(ref _toDo, value); }

        public string ToDoGuncelleyen { get => _toDoGuncelleyen; set => SetProperty(ref _toDoGuncelleyen, value); }

        [NotMapped]
        public int KalanIsYuku { get => kalanIsYuku; set => SetProperty(ref kalanIsYuku, value); }

        [NotMapped]
        public int ToplamSiparisMiktari { get => toplamSiparisMiktari; set => SetProperty(ref toplamSiparisMiktari, value); }

        public int? Tonaj2017 { get => tonaj2017; set => SetProperty(ref tonaj2017, value); }
        public int? Tonaj2018 { get => tonaj2018; set => SetProperty(ref tonaj2018, value); }

        public int? Tonaj2019 { get => tonaj2019; set => SetProperty(ref tonaj2019, value); }

        public int? Tonaj2020 { get => tonaj2020; set => SetProperty(ref tonaj2020, value); }

        public int? Tonaj2021 { get => tonaj2021; set => SetProperty(ref tonaj2021, value); }

        public string KategoriHarf { get => kategoriHarf; set => SetProperty(ref kategoriHarf, value); }


        public string KontratDonemTip { get; set; }
        public string KontratDonemDeger { get; set; }

        [NotMapped]
        public string RiskTalepYer { get; set; }

        public string KontratDonemBirlesik => KontratDonemTip + "-" + KontratDonemDeger;

        public string FirmaGrupTip { get; set; }

        public ObservableCollection<CariDokuman> CariDokumanlar { get; set; }
        public string MusteriPotansiyelDurum { get; set; }

        [NotMapped]
        public int SevkEdilenPaletMiktarTon { get => sevkEdilenPaletMiktarTon; set => SetProperty(ref sevkEdilenPaletMiktarTon, value); }

        [NotMapped]
        public decimal SevkEmrindekiMiktar { get; internal set; }

        public void HesapAlanRiskleriYukle(string riskTalepYer, decimal? yeniSiparislerToplamTutar,
            decimal? uretimRiski, decimal? depoRiski, decimal? bekleyenSevkiyatEmirleriRiski, decimal aktifSevkEmriTutar, decimal? uretilecekOnayliSiparisTutar)
        {
            RiskTalepYer = riskTalepYer;

            SatisYeniKayitRiski = yeniSiparislerToplamTutar;
            UretimRiski = uretimRiski;
            MusteriDepoRiski = depoRiski;
            MusteriSevkEmirleriRiski = bekleyenSevkiyatEmirleriRiski;
            AktifSevkEmriRiski = aktifSevkEmriTutar;
            UretilecekOnayliSiparislerTutar = uretilecekOnayliSiparisTutar;
        }

        public string SonGuncelleyen { get => sonGuncelleyen; set => SetProperty(ref sonGuncelleyen, value); }
        public DateTime? SonGuncellemeTar { get => sonGuncellemeTar; set => SetProperty(ref sonGuncellemeTar, value); }

    }
}
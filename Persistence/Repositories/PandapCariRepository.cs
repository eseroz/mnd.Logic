using Microsoft.EntityFrameworkCore;
using mnd.Common.Helpers;
using mnd.Logic.BC_MusteriTakip.Domain;
using mnd.Logic.Helper;
using mnd.Logic.Model;
using mnd.Logic.Model.Muhasebe;
using mnd.Logic.Model.Netsis;
using mnd.Logic.Model.Satis;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace mnd.Logic.Persistence.Repositories
{
    public class PandapCariRepository
    {
        private PandapContext _dc;

        public PandapCariRepository(PandapContext context = null)
        {
            if (context == null)
                _dc = new PandapContext();
            else
                _dc = context;
        }

        public async Task<ObservableCollection<PandapCari>> PandapCarileriGetirAsync()
        {
            var cev = await _dc.PandapCaris
                     .Where(c => c.PasifMi.GetValueOrDefault() == false)
                     .ToListAsync();
            
             return cev.ToObservableCollection();
        }

        public async Task<ObservableCollection<PandapCari>> PandapCarileriBagliPlasiyerlereGoreGetir(string[] bagliPlasiyerKodlari, string kullaniciRol)
        {
            // yazılabilir olmalı tracking kullan

            var sonuc = _dc.PandapCaris
                    .Include(c => c.Gorusmeler)
                    .Include(c => c.KullanimAlanNavigation)
                    .Include(c => c.Gorusmeler).ThenInclude(p => p.GorusmeTip)
                    .Include(c => c.Gorusmeler).ThenInclude(p => p.GorusmeKonuTip)
                    .Where(c => c.PasifMi.GetValueOrDefault() == false)
                    .Where(c => bagliPlasiyerKodlari.Any(x => x.ToString() == c.PandaMusteriSorumluKod));



            if (kullaniciRol != KULLANICIROLLERI.YONETICI)
            {
                sonuc = sonuc.Where(c => c.CariIsim.Contains("SEHERLİ DIŞ") == false && c.CariIsim.Contains("SEHERLI DIS") == false);
            }


            UnitOfWork uow = new UnitOfWork();


            foreach (var item in sonuc)
            {
                item.PandaMusteriSorumlusu = uow.PlasiyerRepo.getPlasiyer(string.Empty, item.PlasiyerKod)?.AdSoyad;
            }

            uow.Dispose();

            var liste =await sonuc.ToListAsync();


            return liste.ToObservableCollection();

        }


        public ObservableCollection<PandapCariDto> PandapCarileriDetayliGetir_light(string[] bagliPlasiyerKodlari = null, string cariKod = null)
        {


            var cariListeQuery = _dc.PandapCaris
                .Where(c => c.CariKod.Contains("120"))
                .Select(c => new PandapCariDto
                {
                    CariKod = c.CariKod,
                    CariTip = c.CariTip,
                    UlkeKod = c.UlkeKod,
                    UlkeAd = c.UlkeAd,
                    CariIsim = c.CariIsim,
                    PlasiyerKod = c.PandaMusteriSorumluKod,
                    PlasiyerAd = c.PandaMusteriSorumlusu,
                    MusteriTemsilcisi = c.PandaSahaSorumlusu,
                    KullanimAlanTipKod = c.MusteriKullanimAlanTipKod,
                    PandaTemsilcisi = c.PandaAgent,
                    PandaSahaSorumlusuId = c.PandaSahaSorumlusu,
                    PasifMi = c.PasifMi
                });

            cariListeQuery = cariListeQuery.Where(c => c.PasifMi.GetValueOrDefault() == false);


            if (cariKod != null) cariListeQuery = cariListeQuery.Where(c => c.CariKod == cariKod);

            if (bagliPlasiyerKodlari.Length > 0)
                cariListeQuery = cariListeQuery.Where(c => bagliPlasiyerKodlari.Any(x => x.ToString() == c.PlasiyerKod));


            var cariListe = cariListeQuery
                        .AsNoTracking()
                            .ToList();
          

            return cariListe.ToObservableCollection();



        }



        public PandapCariDto PandapCariDetayGetir(string cariKod)
        {
            var cariListeQuery = _dc.PandapCaris
                .Include(c => c.KullanimAlanNavigation)
                .Include(c => c.CariEmailler)
                .Include(c => c.CariHareketler)
                .Include(c => c.CariDokumanlar)
                .Where(c => c.CariKod == cariKod)
                .Select(c => new PandapCariDto
                {
                    CariKod = c.CariKod,
                    CariTip = c.CariTip,
                    DovizTipAd = c.DovizAd,

                    UlkeKod = c.UlkeKod,
                    UlkeAd = c.UlkeAd,
                    CariIsim = c.CariIsim,


                    AgentId = c.PandaAgent,
                    Agent = c.PandaAgent,

                    Adres = c.CariAdres,
                    SevkAdres=c.CariSevkAdres,

                    Tel = c.CariTel,
                    Email=c.Email,
                    Web =c.Web,

                    YillikTonaj = c.YillikKapasiteTonaj.GetValueOrDefault(),
                    KullanimAlanTipKod = c.MusteriKullanimAlanTipKod,
                    KullanimAlanAd = c.KullanimAlanNavigation.Aciklama_EN,

                    MusteriSorumlusu = c.PandaMusteriSorumlusu,
                    PandaSahaSorumlusuId = c.PandaSahaSorumlusu,

                    PlasiyerKod = c.PlasiyerKod,

                    KontratDonemTip = c.KontratDonemTip,
                    KontratDonemDeger = c.KontratDonemDeger,


                    CariEmailListe = c.CariEmailler.ToObservableCollection(),
                    CariDokumanlar = c.CariDokumanlar,

                    CariHareketler = c.CariHareketler,
                    Gorusmeler = c.Gorusmeler,
                    FirmaGrupTip = c.FirmaGrupTip,
                    Durumu = c.MusteriPotansiyelDurum,

                    RiskBilgiDto = new RiskBilgiDto
                    {
                        EximBankLimit = c.EximBankLimit,
                        GarantiFactoringLimit = c.GarantiFactoringLimit,
                        IngFactoringLimit = c.IngFactoringLimit,
                        BankaTeminati = c.BankaTeminati,
                        YoneticiLimit = c.YoneticiSevkLimit,
                        KullanilabilirLimit = c.KullanilabilirLimit,
                        AcikHesap = c.AcikHesap,

                        NetsisBorcBakiye = c.NetsisBorcBakiye,
                        NetsisBorcDovizBakiye = c.NetsisBorcDovizBakiye,
                        NetsisKendiCekRiski = c.NetsisKendiCekRiski,
                        NetsisMusteriCekRiski = c.NetsisMusteriCekRiski,

                        MusteriDepoRiski = c.MusteriDepoRiski,
                        ToplamRisk = c.ToplamRisk,
                        UretimRiski = c.UretimRiski,
                        ToplamLimit = c.ToplamLimit,

                    }


                });

            return cariListeQuery.First();

        }


        public PandapCari PandapCariGetir(string cariKod)
        {
            var sonuc= _dc.PandapCaris.Where(c => c.CariKod == cariKod).FirstOrDefault();

            return sonuc;
        }

        public List<PandapCari> VergiNodanPandapCariGetir(string vergiNo)
        {
            var context = new PandapContext();
            return context.PandapCaris
                .Where(c => c.VergiNumarasi == vergiNo)
                .Where(c=>c.CariKod.StartsWith("120-01"))
                .AsNoTracking()
                .ToList();
        }


        internal List<PandapCari> EximKodundanGetir(decimal eximKod)
        {
            var context = new PandapContext();
            return context.PandapCaris
                .Where(c => c.EximBankKod==eximKod)
                .AsNoTracking()
                .ToList();
        }



        //TODO _Hata verdiği için geçici olarak kapatıldı

    }

    public class PandapCariDto : MyBindableBase
    {
        private int? _yillikTonaj;
        private string _kullanimAlanTipKod;
        private string _adres;
        private string _tel;
        private string _kullanimAlanAd;
        private string musteriSorumlusu;
        private string plasiyerKod;
        private string agentId;
        private string pandaSahaSorumlusu;
        private string agentAd;
        private string pandaSahaSorumlusu1;
        private string kontratDonemTip;
        private string kontratDonemDeger;
        private string firmaGrupTip;
        private string durumu;
        private string sevkAdres;
        private string mail;
        private string web;

        public string CariKod { get; set; }
        public string CariTip { get; set; }
        public string UlkeKod { get; set; }
        public string UlkeAd { get; set; }
        public string CariIsim { get; set; }

        public string Adres { get => _adres; set => SetProperty(ref _adres, value); }
        public string Tel { get => _tel; set => SetProperty(ref _tel, value); }


        public string PlasiyerAd { get; set; }
        public string MusteriTemsilcisi { get; set; }
        public string AliciFirma_YetkiliAdSoyad { get; set; }
        public string AliciFirma_YetkiliEmail { get; set; }
        public string AliciFirma_YetkiliTel { get; set; }
        public ObservableCollection<CariEmailYeni> CariEmailListe { get; set; }
        public string PandaTemsilcisi { get; set; }
        public int SeciliCariEmailId { get; set; }
        public int? AliciFirma_YetkiliNetsisId { get; set; }
        public RiskBilgiDto RiskBilgiDto { get; internal set; }
        public List<NetsisCariHareket> CariHareketler { get; set; }

        public int? YillikTonaj { get => _yillikTonaj; set => SetProperty(ref _yillikTonaj, value); }
        public string KullanimAlanTipKod { get => _kullanimAlanTipKod; set => SetProperty(ref _kullanimAlanTipKod, value); }
        public string KullanimAlanAd { get => _kullanimAlanAd; set => SetProperty(ref _kullanimAlanAd, value); }

        public string DovizTipAd { get; set; }
        public object DovizTipSimge { get; set; }
        public string MusteriSorumlusu { get => musteriSorumlusu; set => SetProperty(ref musteriSorumlusu, value); }
        public string AgentId { get => agentId; set => SetProperty(ref agentId, value); }

        public string Agent { get => agentAd; set => SetProperty(ref agentAd, value); }
        public string PandaSahaSorumlusuId { get => pandaSahaSorumlusu; set => SetProperty(ref pandaSahaSorumlusu, value); }

        public string PandaSahaSorumlusu { get => pandaSahaSorumlusu1; set => SetProperty(ref pandaSahaSorumlusu1, value); }
        public List<Gorusme> Gorusmeler { get; set; }

        public string PlasiyerKod { get => plasiyerKod; set => SetProperty(ref plasiyerKod, value); }
        public bool? PasifMi { get; set; }


        public string KontratDonemTip { get => kontratDonemTip; set => SetProperty(ref kontratDonemTip, value); }
        public string KontratDonemDeger { get => kontratDonemDeger; set => SetProperty(ref kontratDonemDeger, value); }


        public string FirmaGrupTip { get => firmaGrupTip; set => SetProperty(ref firmaGrupTip, value); }
        public ObservableCollection<CariDokuman> CariDokumanlar { get; set; }
        public string Durumu { get => durumu; set => SetProperty(ref durumu, value); }
        public string SevkAdres { get => sevkAdres; set => SetProperty(ref sevkAdres, value); }
        public string Email { get => mail; set => SetProperty(ref mail, value); }
        public string Web { get => web; set => SetProperty(ref web,value); }
    }


    public class RiskBilgiDto
    {
        public decimal? EximBankLimit { get; set; }
        public decimal? GarantiFactoringLimit { get; set; }
        public decimal? IngFactoringLimit { get; set; }
        public decimal? BankaTeminati { get; set; }
        public decimal? YoneticiLimit { get; set; }

        public decimal? NetsisBorcBakiye { get; set; }
        public decimal? NetsisBorcDovizBakiye { get; set; }


        public decimal? AcikHesap { get; set; }
        public decimal? MusteriDepoRiski { get; set; }

        public decimal? UretimRiski { get; set; }


        public decimal? NetsisMusteriCekRiski { get; set; }
        public decimal? NetsisKendiCekRiski { get; set; }

        public decimal? ToplamLimit { get; set; }

        public decimal? ToplamRisk { get; set; }

        public decimal? KullanilabilirLimit { get; set; }

        public int DepodakiUrunMiktarKg { get; set; }




    }

}
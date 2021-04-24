using Microsoft.EntityFrameworkCore;
using mnd.Common;
using mnd.Common.Helpers;
using mnd.Logic.Helper;
using mnd.Logic.Model.Operasyon;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace mnd.Logic.Persistence.Repositories
{
    public class IrsaliyePaletOzetDTO
    {
        public int IrsaliyeId { get;  set; }
        public string CariAd { get;  set; }
        public decimal LmeBF { get;  set; }
        public decimal IscilikBF { get;  set; }
        public decimal BirimFiyat { get;  set; }
        public decimal ToplamFiyat { get;  set; }
        public decimal LmeTutar { get;  set; }
        public decimal IscilikTutar { get;  set; }
        public int PaletNet_Kg { get;  set; }
        public string Alasim { get;  set; }
        public decimal? Kalinlik { get;  set; }
        public decimal? En { get;  set; }
        public string KalinlikGrup { get;  set; }
        public string KullanimAlani { get;  set; }
        public DateTime? IrsaliyeTarihi { get;  set; }
        public string PlasiyerAd { get;  set; }
        public string UlkeAd { get;  set; }
        public string Doviz { get;  set; }
        public decimal ToplamFiyatSeciliDoviz { get;  set; }
        public decimal Parite { get;  set; }
        public string UlkeKod { get;  set; }

        public string SahipSirket => "MND";

        public string YilAy => IrsaliyeTarihi.GetValueOrDefault().Year.ToString() + "-" + IrsaliyeTarihi.GetValueOrDefault().Month.ToString();

        public string YilHafta => IrsaliyeTarihi.GetValueOrDefault().Year.ToString() + "-" +
           CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(IrsaliyeTarihi.GetValueOrDefault(), CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday)
            .ToString().PadLeft(2,'0');

        public decimal PaletNet_Ton { get;  set; }

        public decimal IscilikBF_Doviz { get; set; }

        public decimal Iscilik_Doviz_Toplam { get; set; }
        public string IrsaliyeNo { get;  set; }
        public double UlkeEnlem { get;  set; }
        public double UlkeBoylam { get;  set; }
        public decimal? KulceBF { get; internal set; }
        public decimal? KulceTutar { get; internal set; }
        public decimal? KulceBF_Doviz { get; set; }
        public decimal? Kulce_Doviz_Toplam { get; set; }
    }

    public class MuhasebeRepository
    {
        private PandapContext _dc;

        public MuhasebeRepository(PandapContext context)
        {
            _dc = context;
        }



        public ObservableCollection<Irsaliye> IrsaliyeleriGetir(string irsaliyeDurum)
        {
            var s = _dc.CariIrsaliyeler
         
                .Include(c => c.SevkiyatEmriNav)
              
                .Include(c=>c.CariKodNav)
                .Include(c => c.IrsaliyePaletler)
                .Where(c => c.SevkiyatEmriNav.SevkSurecDurum == SEVKSURECKONUM.MUHASEBE)
                .Where(c => c.NetsiseAktarimDurum == irsaliyeDurum)
                .ToObservableCollection();

            return s;
        }

        public Task<List<IrsaliyePaletOzetDTO>> IrsaliyeOzetGetir(string irsaliyeDurum)
        {
            var baslamaTarih = new DateTime(2019,1,1);

            var s = _dc.CariIrsaliyeler

                .Include(c => c.SevkiyatEmriNav)

                .Include(c => c.CariKodNav)
                .Include(c => c.IrsaliyePaletler)
                .Include(c => c.IrsaliyePaletler).ThenInclude(c => c.SiparisKalemNav)
                .Include(c => c.IrsaliyePaletler).ThenInclude(c => c.SiparisKalemNav)       
                .Where(c => c.SevkiyatEmriNav.SevkSurecDurum == SEVKSURECKONUM.MUHASEBE)
                .Where(c => c.NetsiseAktarimDurum == irsaliyeDurum)
                .Where(c => c.IrsaliyeTarihi >= baslamaTarih)
                .SelectMany(fisDTO => fisDTO.IrsaliyePaletler,
                      (fis, palet) => new IrsaliyePaletOzetDTO
                      {
                          IrsaliyeId = fis.IrsaliyeId,
                          IrsaliyeNo=fis.NetsisIrsaliyeNo,
                          CariAd = fis.CariAd,
                          LmeBF = Math.Round(palet.LmeBF_Ton, 2),
                          IscilikBF = palet.IscilikBF_Ton,
                          KulceBF=palet.KulceBF_Ton.GetValueOrDefault(),
                          BirimFiyat = palet.LmeBF_Ton + palet.IscilikBF_Ton+ palet.KulceBF_Ton.GetValueOrDefault(),
                          ToplamFiyat = Math.Round((Math.Round(palet.LmeBF_Ton, 0) + palet.IscilikBF_Ton + palet.KulceBF_Ton.GetValueOrDefault()) * palet.PaletNet_Kg / 1000, 0),
                          LmeTutar = Math.Round(palet.LmeBF_Ton * palet.PaletNet_Kg / 1000, 2),
                          IscilikTutar = palet.IscilikBF_Ton * palet.PaletNet_Kg / 1000,
                          KulceTutar = palet.KulceBF_Ton * palet.PaletNet_Kg / 1000,
                          PaletNet_Kg = palet.PaletNet_Kg,
                          PaletNet_Ton=  (decimal)(palet.PaletNet_Kg)/1000,
                          Alasim = palet.Alasim,
                          Kalinlik = palet.Kalinlik,
                          En = palet.En,
                          KalinlikGrup = palet.Kalinlik <= 60 ? "İnce" : "Kalın",
                          IrsaliyeTarihi = fis.IrsaliyeTarihi,
                          PlasiyerAd = fis.CariKodNav == null ? "" : fis.CariKodNav.PlasiyerAd,
                          UlkeAd = fis.CariKodNav == null ? "" : fis.CariKodNav.UlkeAd,
                          UlkeKod = fis.CariKodNav == null ? "" : fis.CariKodNav.UlkeKod,
                          UlkeEnlem=500,
                          UlkeBoylam=600,
                          Doviz = palet.DovizTipKod,
                          ToplamFiyatSeciliDoviz = 0m,
                          Parite = 0m
                      })

                .AsNoTracking()
                .ToListAsync();


            return s;
        }



        public ObservableCollection<IrsaliyePalet> CariSevkPaletleriGetir(string cariKod, int sevkiyatEmriId)
        {
            //bobin ağırlığı tolist ten sonra çalışıyor dikkat

            //var s = _dc.UretimPaletler
            //    .Include(c => c.Bobinler)
            //    .Include(c => c.FiyatKalemKodNav)
            //    .Include(c => c.FiyatKalemKodNav)
            //    .Include(c => c.FiyatKalemKodNav).ThenInclude(c => c.SiparisNav).ThenInclude(c => c.FaturaDovizTipKodNavigation)
            //    .Include(c => c.FiyatKalemKodNav).ThenInclude(c => c.SiparisNav).ThenInclude(c => c.TeslimTipKodNavigation)
            //    .Include(c => c.FiyatKalemKodNav).ThenInclude(c => c.SiparisNav).ThenInclude(c => c.SatisTipKodNavigation)

                //.Where(c => c.FiyatKalemKodNav.SiparisNav.CariKod == cariKod && c.SevkiyatEmriId == sevkiyatEmriId)
                //.ToList()
                //.Select(c => new IrsaliyePalet
                //{
                //    PaletId = c.Id,


                //    NetsisStokKod = c.FiyatKalemKodNav.AlasimTipKod + "-" + c.FiyatKalemKodNav.SertlikTipKod,
                //    NetsisBirimTipKod = "1",

                //    //PaletGrupKey = c.PaletGrupKey,
                //    UrunKod = c.FiyatKalemKodNav.UrunKod,
                //    UrunFaturaAd = "Aluminyum Folyo " + c.PaletGrupKey,
                //    SiparisKod = c.FiyatKalemKodNav.SiparisKod,
                //    FiyatKalemKod = c.FiyatKalemKod,

                //    PaletSayisi = 1,
                //    MasuraSayisi = BobinSayiHelper.BobinAdetBul(c.BobinlerBirlesik),
                //    BobinlerBirlesik = c.BobinlerBirlesik,

                //    LfxKod = c.FiyatKalemKodNav.LmeBaglamaKod,

                //    LmeBF_Ton = c.FiyatKalemKodNav.LmeTutar.GetValueOrDefault(),
                //    IscilikBF_Ton = c.FiyatKalemKodNav.IscilikTutar.GetValueOrDefault(),

                //    BirimFiyat_Kg = c.FiyatKalemKodNav.BirimFiyat.GetValueOrDefault(),

                //    PaletNet_Kg = c.PaletNet_Kg,


                //    KdvOran = c.FiyatKalemKodNav.KdvOran.GetValueOrDefault(),

                //    GTip = "",
                //    GTipSatirKod = "",

                //    Kalinlik = c.FiyatKalemKodNav.Kalinlik_micron,
                //    En = c.FiyatKalemKodNav.En_mm,

                //    PaletEbat = c.PaletEbat,
                //    Alasim = c.FiyatKalemKodNav.AlasimTipKod,
                //    Sertlik = c.FiyatKalemKodNav.SertlikTipKod,
                //    KartNo = c.KartNo,
                //    FirmaSiparisNo = c.FiyatKalemKodNav.SiparisNav.FirmaSiparisNo,
                //    FirmaUrunNo = c.FiyatKalemKodNav.MusteriUrunKodu,
                //    PaletDara_Kg = c.PaletDara_Kg,
                //    PaletBrut_Kg = c.PaletNet_Kg + c.PaletDara_Kg,



                //    DovizTipKod = c.FiyatKalemKodNav.SiparisNav.FaturaDovizTipKod,
                //    NetsisDovizTipId = c.FiyatKalemKodNav.SiparisNav.FaturaDovizTipKodNavigation.NetsisId,
                //    NetsisSatisFaturaTipId = c.FiyatKalemKodNav.SiparisNav.SatisTipKodNavigation.NetsisId,
                //    NetsisTeslimTipId = c.FiyatKalemKodNav.SiparisNav.TeslimTipKodNavigation.NetsisId

                //})
                //.Select(c =>
                //{
                //    c.PaletToplamTutar = c.BirimFiyat_Kg * c.PaletNet_Kg;
                //    c.PaletKdvTutar = c.BirimFiyat_Kg * c.PaletNet_Kg * c.KdvOran / 100;
                //    c.PaletGenelToplamTutar = c.BirimFiyat_Kg * c.PaletNet_Kg * (1 + c.KdvOran / 100);

                //    return c;

                //})


                //.ToObservableCollection();
            return null;
        }

        public Dictionary<string, int> IrsaliyeSiparisOzetGetir()
        {
            var sonuc = _dc.CariIrsaliyeler
               .Include(c => c.IrsaliyePaletler)
               .SelectMany(i_p => i_p.IrsaliyePaletler, (i, i_p) => new { i, i_p })
               .Where(c => c.i.NetsiseAktarimDurum == "AKTARILDI")
               .Select(u => new { SiparisKod = u.i_p.SiparisKod, MiktarKg = u.i_p.PaletNet_Kg })
               .GroupBy(c => new { c.SiparisKod })
               .Select(g => new { SiparisKod = g.Key.SiparisKod, MiktarKg = g.Sum(t => t.MiktarKg) })
               .ToDictionary(t => t.SiparisKod, t => t.MiktarKg);

            return sonuc;
        }

        public Dictionary<string, int> IrsaliyeSiparisOzetGetirKalemBazli()
        {
            var sonuc = _dc.CariIrsaliyeler
               .Include(c => c.IrsaliyePaletler)
               .SelectMany(i_p => i_p.IrsaliyePaletler, (i, i_p) => new { i, i_p })
               .Where(c => c.i.NetsiseAktarimDurum == "AKTARILDI")
               .Select(u => new { SiparisKalemKod = u.i_p.FiyatKalemKod, MiktarKg = u.i_p.PaletNet_Kg })
               .GroupBy(c => new { c.SiparisKalemKod })
               .Select(g => new { SiparisKalemKod = g.Key.SiparisKalemKod, MiktarKg = g.Sum(t => t.MiktarKg) })
               .ToDictionary(t => t.SiparisKalemKod, t => t.MiktarKg);

            return sonuc;
        }

        public Dictionary<string, int> FaturaEdilenLfxKgGetir()
        {
            var sonuc = _dc.CariIrsaliyeler
                .Include(c => c.IrsaliyePaletler)
                .SelectMany(i_p => i_p.IrsaliyePaletler, (i, i_p) => new { i, i_p })
                .Where(c => c.i.NetsiseAktarimDurum == "AKTARILDI" && c.i_p.LfxKod != null)
                .Select(u => new { Lfx = u.i_p.LfxKod, Miktar = u.i_p.PaletNet_Kg })
                .GroupBy(c => new { c.Lfx })
                .Select(g => new { Lfx = g.Key.Lfx, ToplamKg = g.Sum(t => t.Miktar) })
                .ToDictionary(t => t.Lfx, t => t.ToplamKg);

            return sonuc;

        }

        public Dictionary<string, string> SiparisFaturaHaftaGetir()
        {
            var sorgu = _dc.CariIrsaliyeler
              .Include(c => c.IrsaliyePaletler)
              .SelectMany(i_p => i_p.IrsaliyePaletler, (i, i_p) => new { i, i_p })
              .Where(c => c.i.NetsiseAktarimDurum == "AKTARILDI")
              .Select(u => new
              {
                  SiparisKod = u.i_p.SiparisKod,
                  FaturaYilHafta = u.i.IrsaliyeTarihi.GetValueOrDefault().Year.ToString() + "/" +
                  CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(u.i.IrsaliyeTarihi.GetValueOrDefault(), CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday).ToString()
              })
              .ToList();

            var sonuc = sorgu.GroupBy(c => new { c.SiparisKod })
              .Select(g => new { SiparisKod = g.Key.SiparisKod, Haftalar = string.Join(";", g.Select(x => x.FaturaYilHafta).Distinct()) })
              .ToDictionary(t => t.SiparisKod, t => t.Haftalar);

            return sonuc;
        }
    }
}
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using mnd.Common.Helpers;
using mnd.Logic.Persistence;
using mnd.Logic.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mnd.Logic.Services
{
    public class CariRiskService
    {




        public static List<CariSiparisMiktarlari> SatisYeniKayitFiyatlariGetir(string cariKod = "Tümü")
        {
            PandapContext _dc = new PandapContext();

            //var lmeTarih = DateTime.Now.AddDays(-1).Date;

            //var lmeGunlukFiyat = LmeService.LmeFiyatGetirTarihten(lmeTarih);

            //var x1 = _dc.Siparisler
            //        .Include(c => c.SiparisKalemleri)
            //        .Where(c => c.SiparisSurecDurum == SIPARISSURECDURUM.SATISTA)
            //        .Where(c => c.CariKod == cariKod || cariKod == "Tümü")
            //        .ToList();


            //var a = x1.SelectMany(i_p => i_p.SiparisKalemleri, (i, i_p) => new { i, i_p })
            //       .Select(c => new
            //       {
            //           CariKod = c.i.CariKod,

            //           ilgiliId = c.i.SiparisKod,
            //           kdvOran = c.i_p.KdvOran,
            //           dovizTipKod = c.i.FaturaDovizTipKod

            //       })

            //   .Select(c => SiparisFiyatHesapService.FiyatSonucDTO_Getir(c.CariKod,
            //                           c.lmeBF == 0 ? lmeGunlukFiyat.LmeDegerGetir(c.dovizTipKod) : c.lmeBF,
            //                           c.kulceBF, c.iscilikBF, c.iscilikVadeFarkiOran, c.kdvOran,
            //                           c.miktarKg.GetValueOrDefault(), c.ilgiliId, c.dovizTipKod))
            //   .GroupBy(g => new { g.CariKod, g.DovizTipKod })
            //   .Select(c => new CariSiparisMiktarlari
            //   {
            //       CariKod = c.Key.CariKod,
            //       DovizTipKod = c.Key.DovizTipKod,
            //       Miktar_Kg = c.Sum(t => t.MiktarKg),
            //       GenelToplamTutar = c.Sum(t => t.GenelToplamTutar)
            //   })
            //  .ToList();

            return new List<CariSiparisMiktarlari>();
        }

        public static List<CariSiparisMiktarlari> MusteriOnayliSiparisFiyatlariGetir(string cariKod = "Tümü")
        {
            PandapContext _dc = new PandapContext();

            var lmeTarih = DateTime.Now.AddDays(-1).Date;

            var lmeGunlukFiyat = LmeService.LmeFiyatGetirTarihten(lmeTarih);

            var x1 = _dc.Siparisler
                    .Include(c => c.SiparisKalemleri)
                    .Where(c => c.SiparisSurecDurum == SIPARISSURECDURUM.MUSTERIONAYLI)
                    .Where(c => c.CariKod == cariKod || cariKod == "Tümü")
                    .Where(c=>c.SiparisAcikMi==true)
                    .ToList();


            return new List<CariSiparisMiktarlari>();
        }

        public static List<CariSiparisMiktarlari> UretimEmriIsYuku_FiyatGetir(string cariKod = "Tümü")
        {
            PandapContext _dc = new PandapContext();
            var lmeTarih = DateTime.Now.AddDays(-1).Date;

            var lmeGunlukFiyat = LmeService.LmeFiyatGetirTarihten(lmeTarih);

            var x = _dc.UretimEmirleri
                 .Include(c => c.UretimBobinler)
                 .Include(c => c.SiparisKalemKodNav).ThenInclude(k => k.SiparisNav)
                 .Include(c => c.SiparisKalemKodNav).ThenInclude(c => c.SiparisNav).ThenInclude(c => c.CariKartNavigation)
                 // .Where(c=>c.KapatildiMi.GetValueOrDefault()==false)
                 .Where(c => c.SiparisKalemKodNav.SiparisNav.SiparisSurecDurum == SIPARISSURECDURUM.MUSTERIONAYLI)
                 .Where(c => c.SiparisKalemKodNav.SiparisNav.SiparisAcikMi == true);



            if (cariKod != "Tümü") x = x.AsQueryable().Where(c => c.SiparisKalemKodNav.SiparisNav.CariKod == cariKod);

            var x1 = x
               .Select(c => new
               {
                   cariKod = c.SiparisKalemKodNav.SiparisNav.CariKod,
                   IlgiliId = c.UretimEmriKod,
                   kdvOran = c.SiparisKalemKodNav.KdvOran,
                   miktarKg = c.Uretim_PlanlananMiktar.GetValueOrDefault() - c.UretimBobinler.Sum(b => b.Agirlik_kg).GetValueOrDefault(),
                   dovizTipKod = c.SiparisKalemKodNav.SiparisNav.TakipDovizTipKod,

               }).ToList();

            //var x2 = x1.Select(c => SiparisFiyatHesapService.FiyatSonucDTO_Getir(c.cariKod,
            //                          c.lmeBF == 0 ? lmeGunlukFiyat.LmeDegerGetir(c.dovizTipKod) : c.lmeBF,
            //                          c.kulceBF, c.iscilikBF, c.iscilikVadeFarkiOran, c.kdvOran, c.miktarKg, c.IlgiliId, c.dovizTipKod))
           // .GroupBy(g => new { g.CariKod, g.DovizTipKod })
           // .Select(c => new CariSiparisMiktarlari
           // {
           //     CariKod = c.Key.CariKod,
           //     DovizTipKod = c.Key.DovizTipKod,
           //     Miktar_Kg = c.Sum(t => t.MiktarKg),
           //     GenelToplamTutar = c.Sum(t => t.GenelToplamTutar)
           // })
           //.ToList();

            return new List<CariSiparisMiktarlari>();

        }

        public static List<CariSiparisMiktarlari> DepoPaletFiyatGetir(string cariKod = "Tümü")
        {
            PandapContext _dc = new PandapContext();

            //var lmeTarih = DateTime.Now.AddDays(-1).Date;

            //var lmeGunlukFiyat = LmeService.LmeFiyatGetirTarihten(lmeTarih);

            //var x = _dc.UretimPaletler
            //   .Include(c => c.Bobinler)
            //   .Include(c => c.FiyatKalemKodNav)
            //   .Include(c => c.FiyatKalemKodNav).ThenInclude(k => k.SiparisNav)
            //   .Include(c => c.FiyatKalemKodNav).ThenInclude(c => c.SiparisNav).ThenInclude(c => c.CariKartNavigation)
            //   .Where(c => c.PaletKonum == PALETKONUM.DEPO && c.FiyatKalemKod != null);


            //if (cariKod != "Tümü") x = x.AsQueryable().Where(c => c.FiyatKalemKodNav.SiparisNav.CariKod == cariKod);

            //var x1 =
            //   x.ToList()
            //   .Select(c => new
            //   {
            //       cariKod = c.FiyatKalemKodNav.SiparisNav.CariKod,
            //       ilgiliId = c.Id.ToString(),
            //       kdvOran = c.FiyatKalemKodNav.KdvOran,
            //       miktarKg = c.Bobinler.Sum(t => t.Agirlik_kg),
            //       dovizTipKod = c.FiyatKalemKodNav.SiparisNav.TakipDovizTipKod,

            //   });

            //var u = JsonConvert.SerializeObject(x.ToList());

            //var x2=x1.Select(c => SiparisFiyatHesapService.FiyatSonucDTO_Getir(c.cariKod,
            //                           c.lmeBF == 0 ? lmeGunlukFiyat.LmeDegerGetir(c.dovizTipKod) : c.lmeBF,
            //                           c.kulceBF, c.iscilikBF, c.iscilikVadeFarkiOran, c.kdvOran, c.miktarKg.GetValueOrDefault(), c.ilgiliId, c.dovizTipKod))
            //   .GroupBy(g => new { g.CariKod, g.DovizTipKod })
            //   .Select(c => new CariSiparisMiktarlari
            //   {
            //       CariKod = c.Key.CariKod,
            //       DovizTipKod = c.Key.DovizTipKod,
            //       Miktar_Kg = c.Sum(t => t.MiktarKg),
            //       GenelToplamTutar = c.Sum(t => t.GenelToplamTutar)
            //   })
            //  .ToList();

            return new List<CariSiparisMiktarlari>();

        }

        public static List<CariSiparisMiktarlari> SevkiyatEmirleriFiyatGetir(string cariKod = "Tümü")
        {
            //PandapContext _dc = new PandapContext();

            //var lmeTarih = DateTime.Now.AddDays(-1).Date;

            //var lmeGunlukFiyat = LmeService.LmeFiyatGetirTarihten(lmeTarih);

            //var x = _dc.UretimPaletler
            //   .Include(c => c.Bobinler)
            //   .Include(c => c.FiyatKalemKodNav)
            //   .Include(c => c.FiyatKalemKodNav).ThenInclude(k => k.SiparisNav)
            //   .Include(c => c.FiyatKalemKodNav).ThenInclude(c => c.SiparisNav).ThenInclude(c => c.CariKartNavigation)
            //   .Where(c => c.PaletKonum == PALETKONUM.SEVKEMRI && c.FiyatKalemKod != null);


            //if (cariKod != "Tümü") x = x.AsQueryable().Where(c => c.FiyatKalemKodNav.SiparisNav.CariKod == cariKod);


            //var cev = x.ToList();


            //var x1 =
            //   x.ToList()
            //   .Select(c => new
            //   {
            //       cariKod = c.FiyatKalemKodNav.SiparisNav.CariKod,
            //       ilgiliId = c.Id.ToString(),
            //       kdvOran = c.FiyatKalemKodNav.KdvOran,
            //       miktarKg = c.Bobinler.Sum(t => t.Agirlik_kg),
            //       dovizTipKod = c.FiyatKalemKodNav.SiparisNav.TakipDovizTipKod,

            //   })
            //   .ToList();

            //var x2=x1
            //   .Select(c => SiparisFiyatHesapService.FiyatSonucDTO_Getir(c.cariKod,
            //                           c.lmeBF == 0 ? lmeGunlukFiyat.LmeDegerGetir(c.dovizTipKod) : c.lmeBF,
            //                           c.kulceBF, c.iscilikBF, c.iscilikVadeFarkiOran, c.kdvOran,
            //                           c.miktarKg.GetValueOrDefault(), c.ilgiliId, c.dovizTipKod))
            //   .GroupBy(g => new { g.CariKod, g.DovizTipKod })
            //   .Select(c => new CariSiparisMiktarlari
            //   {
            //       CariKod = c.Key.CariKod,
            //       DovizTipKod = c.Key.DovizTipKod,
            //       Miktar_Kg = c.Sum(t => t.MiktarKg),
            //       GenelToplamTutar = c.Sum(t => t.GenelToplamTutar)
            //   })
            //  .ToList();

            return new List<CariSiparisMiktarlari>();

        }

        public static List<CariSiparisMiktarlari> AktifSevkiyatEmriFiyatGetir(int sevkiyatEmriId, string cariKod = "Tümü")
        {
            PandapContext _dc = new PandapContext();

            var lmeTarih = DateTime.Now.AddDays(-1).Date;

            var lmeGunlukFiyat = LmeService.LmeFiyatGetirTarihten(lmeTarih);

            var x = _dc.UretimPaletler
               .Include(c => c.Bobinler)
               .Include(c => c.FiyatKalemKodNav)
               .Include(c => c.FiyatKalemKodNav).ThenInclude(k => k.SiparisNav)
               .Include(c => c.FiyatKalemKodNav).ThenInclude(c => c.SiparisNav).ThenInclude(c => c.CariKartNavigation)
               .Where(c => c.PaletKonum == PALETKONUM.AKTIFSEVKEMRI && c.FiyatKalemKod != null && c.SevkiyatEmriId==sevkiyatEmriId);


            if (cariKod != "Tümü") x = x.AsQueryable().Where(c => c.FiyatKalemKodNav.SiparisNav.CariKod == cariKod);


            var cev = x.ToList();



            var x1 =
               x.ToList()
               .Select(c => new
               {
                   cariKod = c.FiyatKalemKodNav.SiparisNav.CariKod,
                   ilgiliId = c.Id.ToString(),
                   kdvOran = c.FiyatKalemKodNav.KdvOran,
                   miktarKg = c.Bobinler.Sum(t => t.Agirlik_kg),
                   dovizTipKod = c.FiyatKalemKodNav.SiparisNav.TakipDovizTipKod,

               }).ToList();

            //var x2=x1
            //   .Select(c => SiparisFiyatHesapService.FiyatSonucDTO_Getir(c.cariKod,
            //                           c.lmeBF == 0 ? lmeGunlukFiyat.LmeDegerGetir(c.dovizTipKod) : c.lmeBF,
            //                           c.kulceBF, c.iscilikBF, c.iscilikVadeFarkiOran, c.kdvOran,
            //                           c.miktarKg.GetValueOrDefault(), c.ilgiliId, c.dovizTipKod))
            //   .GroupBy(g => new { g.CariKod, g.DovizTipKod })
            //   .Select(c => new CariSiparisMiktarlari
            //   {
            //       CariKod = c.Key.CariKod,
            //       DovizTipKod = c.Key.DovizTipKod,
            //       Miktar_Kg = c.Sum(t => t.MiktarKg),
            //       GenelToplamTutar = c.Sum(t => t.GenelToplamTutar)
            //   })
            //  .ToList();

            return new List<CariSiparisMiktarlari>();

        }

        public static List<CariSiparisMiktarlari> SatisKapasitifFiyatGetir(string cariKod = "Tümü")
        {
            PandapContext _dc = new PandapContext();

            var lmeTarih = DateTime.Now.AddDays(-1).Date;

            var lmeGunlukFiyat = LmeService.LmeFiyatGetirTarihten(lmeTarih);

            var x1 = _dc.Siparisler
                    .Include(c => c.SiparisKalemleri)
                    .Where(c => c.SiparisSurecDurum == SIPARISSURECDURUM.MUSTERIONAYLI)
                    .Where(c => c.CariKod == cariKod || cariKod == "Tümü")
 
                    .Where(c => c.SiparisAcikMi == true)
                    .ToList();


            //var a = x1.SelectMany(i_p => i_p.SiparisKalemleri, (i, i_p) => new { i, i_p })
            //       .Select(c => new
            //       {
            //           CariKod = c.i.CariKod,

            //           ilgiliId = c.i.SiparisKod,
            //           lmeBF = c.i_p.LmeTutar,
            //           kulceBF = c.i_p.KulceTutar,
            //           iscilikBF = c.i_p.IscilikTutar.GetValueOrDefault(),
            //           kdvOran = c.i_p.KdvOran,
            //           iscilikVadeFarkiOran = c.i_p.IscilikVadeFarkiOran.GetValueOrDefault(),
            //           miktarKg = c.i_p.Miktar_kg,
            //           dovizTipKod = c.i.FaturaDovizTipKod

            //       })

            //   .Select(c => SiparisFiyatHesapService.FiyatSonucDTO_Getir(c.CariKod,
            //                           c.lmeBF == 0 ? lmeGunlukFiyat.LmeDegerGetir(c.dovizTipKod) : c.lmeBF,
            //                           c.kulceBF, c.iscilikBF, c.iscilikVadeFarkiOran, c.kdvOran,
            //                           c.miktarKg.GetValueOrDefault(), c.ilgiliId, c.dovizTipKod))
            //   .GroupBy(g => new { g.CariKod, g.DovizTipKod })
            //   .Select(c => new CariSiparisMiktarlari
            //   {
            //       CariKod = c.Key.CariKod,
            //       DovizTipKod = c.Key.DovizTipKod,
            //       Miktar_Kg = c.Sum(t => t.MiktarKg),
            //       GenelToplamTutar = c.Sum(t => t.GenelToplamTutar)
            //   })
            //  .ToList();

            return new List<CariSiparisMiktarlari>();
        }





    }
}

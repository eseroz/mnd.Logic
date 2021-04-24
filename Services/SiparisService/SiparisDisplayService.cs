using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using mnd.Common;
using mnd.Common.Helpers;
using mnd.Logic.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using mnd.Logic.Persistence;
using mnd.Logic.Model.Satis;

namespace mnd.Logic.Services.SiparisService
{
    public class SiparisDisplayService
    {
        private PandapContext _dc = new PandapContext();

        public SiparisDisplayService()
        {
        }


        private IQueryable<SiparisDTO> SelectQuery(string aktifKullaniciKod, string siparisKod, string siparisSurecDurum)
        {

            var _dc1 = new PandapContext();
            var kul = _dc1.Kullanicilar.Find(aktifKullaniciKod);

            var query = _dc1.Siparisler
                .Include(c => c.SiparisKalemleri)
                .Include(c => c.CariKartNavigation)
                .Include(c => c.FaturaDovizTipKodNavigation)
                .Where
                 (
                     c =>
                     (kul.BagliNetsisPlasiyerKodlari.Contains(c.CariKartNavigation.PlasiyerKod)) &&
                     (c.SiparisKod == siparisKod || siparisKod == null) &&
                     (c.SiparisSurecDurum == siparisSurecDurum || siparisSurecDurum == "Tümü")
                 )

                .Select(c => new SiparisDTO
                {
                    SiparisKod = c.SiparisKod,
                    SiparisAcikMi = c.SiparisAcikMi,
                    SevkYil = c.SevkYil,
                    SevkHafta = c.SevkHafta,

                    TeslimYil = c.TeslimYil,
                    TeslimHafta = c.TeslimHafta,

                    RowGuid = c.RowGuid,
                    CariIsim = c.CariKartNavigation.CariIsim,
                    CariKod = c.CariKartNavigation.CariKod,
                    SiparisTarih = c.SiparisTarih,
                    FaturaDovizCinsi = c.FaturaDovizTipKod,
                    LmeDovizTipKod = c.TakipDovizTipKod,

                    FirmaSiparisNo = c.FirmaSiparisNo,
                    OdemeAciklama = c.OdemeAciklama,
                    FaturaDovizTipSimge = c.FaturaDovizTipKodNavigation.Simge,
                    KaydiOlusturan = c.CreatedUserId,
                    TemsilciAdSoyad = c.CariKartNavigation.PlasiyerAd,

                    SiparisSurecDurum = c.SiparisSurecDurum,
                    SiparisSurecDurumIslemTarih = c.SiparisSurecDurumIslemTarih,
                    SiparisSurecDurumOnceki = c.SiparisSurecDurumOnceki,

                    UlkeKodIso = c.CariKartNavigation.UlkeKod,

                    SiparisKalemDTO_List = c.SiparisKalemleri.Select(k => new SiparisKalemDTO
                    {
                        SiparisKalemKod = k.SiparisKalemKod,
                        GenelToplamTutar = k.GenelToplamTutar.GetValueOrDefault(),
                        KalemRowGuid = k.RowGuid.Value,
                        UrunKod = k.UrunKod,
                        UrunAdiEN = k.UrunAdiEN,
                        UrunAdiTR = k.UrunAdiTR,
                        Miktar = (int)k.Miktar,
                        Tutar = k.Tutar,
                        L = (double)k.L,
                        W = (double)k.W,
                        H = (double)k.H,
                        CRTN = (double)k.CRTN,
                        BOX = (double)k.BOX,
                        NETKG = (double)k.NETKG,
                        GROSS = (double)k.GROSS,
                        GR = (double)k.GR
                    }).ToList()

                });

         
            return query;
        }

        public async Task<List<SiparisDTO>> SiparisDTO_ListeGetirAsync(string siparisSurecDurum,
                                               bool kapasitifMi, bool normalMi, bool kapaliSiparislerGorunsunMu = true,
                                               string siparisKod = null, string aktifKullaniciKod = "")
        {

            //var lmeTarih = DateTime.Now.AddDays(-1).Date;
            //var lmeGunlukFiyat = LmeService.LmeFiyatGetirTarihten(lmeTarih);

            var aktifHafta = CalenderUtil.GetWeekNumberFromDate(DateTime.Now);
            var aktifYilHafta = DateTime.Now.Year.ToString() + "/" + aktifHafta.ToString().PadLeft(2, '0');

            _dc.Database.ExecuteSqlCommand("exec Satis.spSiparisAcikDurumGuncelle");

            List<SiparisDTO> sonuc = null;

            var q = SelectQuery(aktifKullaniciKod, siparisKod, siparisSurecDurum);

            if (siparisSurecDurum != "Tümü")
                q = q.Where(c => c.SiparisAcikMi != kapaliSiparislerGorunsunMu);

            //if (kapasitifMi == false && normalMi == false)
            //{
            //    q = q.Take(0);
            //}
            //else if (kapasitifMi == true && normalMi == false)
            //{
            //    q = q.Where(c => c.KapasitifMi == true);
            //}
            //else if (kapasitifMi == false && normalMi == true)
            //{
            //    q = q.Where(c => c.KapasitifMi == false);
            //}

            await Task.Run(() =>
            {
                sonuc = q
               .AsNoTracking()
               .ToList()
               .Select(c =>
               {
                   c.SevkHaftasi = c.SevkYil.ToString() + "/" + c.SevkHafta.Value.ToString().PadLeft(2, '0');
                   c.SevkAyAdi = c.SevkYil.GetValueOrDefault() + "-" + Utils.AyAdiBul_Haftadan(c.SevkYil.GetValueOrDefault(), c.SevkHafta.GetValueOrDefault());
                   c.TeslimHaftasi = c.TeslimYil.ToString() + "/" + c.TeslimHafta.Value.ToString().PadLeft(2, '0');
                   c.Tarih = c.SiparisTarih;

                   c.SevkHaftaGectiMi = c.SevkHaftasi.CompareTo(aktifYilHafta) < 0;
                  
                   //c.DepodaUrunSayisi = DepodakiUrunSayisi(c);
                   c.Miktar = c.SiparisKalemDTO_List.Sum(t => t.Miktar);

                   //c.KalanIsyukuKg = KalanIsYuku(c);                   

                   //c.BobinPaketToplamKg = BobinPaketToplam(c);

                   //c.PaketlenenTumMiktarKg = PaketlenenTumMiktarGetir(c);

                   //c.PaketlenenMiktarKg = c.PaketlenenMiktarKg.GetValueOrDefault();

                   //c.PlanSiparisKapatildiMi = c.SiparisAcikMi.GetValueOrDefault();
                   //c.AktifUretimEmriSayisi = c.SiparisKalemDTO_List.Sum(t => t.UretimEmirleriDTO_List.Where(u => u.KapatildiMi == false).Count());
                   //c.KapatilmisUretimEmriSayisi = c.SiparisKalemDTO_List.Sum(t => t.UretimEmirleriDTO_List.Where(u => u.KapatildiMi == true).Count());

                   //c.SiparisUretimdekiMiktar = c.SiparisKalemDTO_List.Sum(t => t.PLAN_UretimdekiMiktarToplam.GetValueOrDefault());
                   //c.SiparisKalanMiktar = c.SiparisKalemDTO_List.Sum(t => t.PLAN_PlanlanacakKalanMiktarToplam.GetValueOrDefault());

                   //c.SiparisUretimPlanlanan = c.SiparisKalemDTO_List.Sum(t => t.UretimEmirleriDTO_List.Sum(u => u.Uretim_PlanlananMiktar.GetValueOrDefault()));


                   //c.SiparisUretimBakiye = c.SiparisKalemDTO_List
                   //                       .Sum
                   //                       (
                   //                           t => t.UretimEmirleriDTO_List
                   //                           .Where(u => u.KapatildiMi == false)
                   //                           .Sum(u => u.Uretim_UretimdekiMiktar.GetValueOrDefault())
                   //                       );

                  
                   //c.GenelIscilikTutarOrt = c.SiparisKalemDTO_List.Select(t => (decimal?)t.IscilikTutar.Value).Average();

                   //c.LmeMaxBagliDeger = c.SiparisKalemDTO_List.Max(u => u.LmeTutar);

                   //c.BagliLfxKodlari = String.Join(";", c.SiparisKalemDTO_List.Select(lfxmetin => lfxmetin.LmeBaglamaKod).Distinct().ToArray());

                   //c.GenelIscilikVadeFarkiTutar = c.SiparisKalemDTO_List.Sum(t => t.IscilikVadeFarkiTutar.Value);
                   c.GenelToplamTutar = c.SiparisKalemDTO_List.Sum(t => t.GenelToplamTutar);

                   c.GenelToplamTutarKurlu = c.SiparisKalemDTO_List.Sum(t => t.GenelToplamTutar.Value).ToString("n0") +
                              " " + c.FaturaDovizTipSimge;


                   //c.GenelToplamTutar_OtoLME = c.SiparisKalemDTO_List.Select(f =>
                   //{
                   //    var lmeFiyat = f.LmeTutar == 0 ? lmeGunlukFiyat.LmeDegerGetir(c.FaturaDovizCinsi,c.CariKod) : f.LmeTutar;

                   //    var auto_lme_gtoplam = SiparisFiyatHesapService.FiyatSonucDTO_Getir(c.CariKod, lmeFiyat, f.KulcePrimi,
                   //                      f.IscilikTutar, f.IscilikVadeFarkiOran,
                   //                      f.KdvOran, f.Miktar_kg, f.SiparisKalemKod, c.LmeDovizTipKod)
                   //                      .GenelToplamTutar;

                   //    return auto_lme_gtoplam;

                   //}).Sum();

                   //c.KapatisitiflikDurum = c.KapasitifMi.HasValue && c.KapasitifMi == true ? "Kapasitif" : "Sipariş";
                   c.SiparisKalemDTO_List = c.SiparisKalemDTO_List.Select(k => SetDataKalemDto(k)).ToList();
                   c.GenelToplamTutar = c.SiparisKalemDTO_List.Sum(p => p.Tutar);
                   return c;
               })
               .OrderByDescending(c => c.SiparisKod).ToList();

            });




            return sonuc;
        }

        public SiparisKalemDTO SetDataKalemDto(SiparisKalemDTO k)
        {
          
            //k.SiparisKalemKapatildiMi = k.SiparisKalemKapatildiMi;

            //k.KalemUretimBakiye = k.UretimEmirleriDTO_List
            //                  .Where(u => u.KapatildiMi == false)
            //                   .Sum(u => u.Uretim_UretimdekiMiktar.GetValueOrDefault());


            // miktar-(uretimbakiye+paketmiktarı)
            //k.UretimKalanMiktar = k.Miktar_kg -
            //                   (
            //                       k.UretimEmirleriDTO_List
            //                          .Where(u => u.KapatildiMi == false)
            //                          .Sum(u => u.Uretim_UretimdekiMiktar.GetValueOrDefault())
            //                       +
            //                       k.UretimEmirleriDTO_List.Sum(p => p.BobinlerDTO_List.Sum(b => b.Agirlik_kg).GetValueOrDefault())
            //                   );


      
            //k.KalemIsyuku = k.Miktar_kg - k.UretimEmirleriDTO_List.Sum(p => p.BobinlerDTO_List.Sum(b => b.Agirlik_kg)).GetValueOrDefault();

            //k.KalemPaketlenenMiktar = k.UretimEmirleriDTO_List.Sum(p => p.BobinlerDTO_List.Sum(b => b.Agirlik_kg).GetValueOrDefault());

       
            return k;
        }

        public int PaketlenenTumMiktarGetir(SiparisDTO c)
        {
            //return c.PaketlenenMiktarKg.GetValueOrDefault() +
            //                 c.SiparisKalemDTO_List.Sum(u => u.UretimEmirleriDTO_List.Sum(p => p.BobinlerDTO_List.Sum(b => b.Agirlik_kg))).GetValueOrDefault();

            return 0;
        }

        public int BobinPaketToplam(SiparisDTO c)
        {
            //return c.SiparisKalemDTO_List.Sum(u => u.UretimEmirleriDTO_List.Sum(p => p.BobinlerDTO_List.Sum(b => b.Agirlik_kg))).GetValueOrDefault();
            return 0;
        }

        public int KalanIsYuku(SiparisDTO c)
        {
            //var sonuc = c.SiparisKalemDTO_List.Sum(t => t.Miktar_kg) -
            //                 (c.PaketlenenMiktarKg.GetValueOrDefault() +
            //                 c.SiparisKalemDTO_List.Sum(u => u.UretimEmirleriDTO_List.Sum(p => p.BobinlerDTO_List.Sum(b => b.Agirlik_kg))).GetValueOrDefault());

            //return sonuc;
            return 0;
        }

        public int DepodakiUrunSayisi(SiparisDTO c)
        {
            //return c.SiparisKalemDTO_List
            //                 .Sum(u => u.UretimEmirleriDTO_List
            //                 .Sum(p => p.BobinlerDTO_List.Where(b => b.PaletNav?.DepoOnayaGonderimTarihi != null
            //                             && b.PaletNav?.SevkiyatTarihi == null)
            //                 .Sum(bt => bt.Agirlik_kg.GetValueOrDefault())));
            return 0;

        }


        public Siparis SonSiparisNoGetir()
        {
            var sonuc = _dc.Siparisler.LastOrDefault();
            return sonuc;
        }
       
    }
}
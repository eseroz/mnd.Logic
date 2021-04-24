using Microsoft.EntityFrameworkCore;
using mnd.Common;
using mnd.Common.Helpers;
using mnd.Logic.Helper;
using mnd.Logic.Model.Satis;
using mnd.Logic.Model.Uretim;
using mnd.Logic.Services;
using mnd.Logic.Services._DTOs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Linq.Expressions;

namespace mnd.Logic.Persistence.Repositories
{
    public class PlanlamaRepository : RepositoryAsync<Siparis>
    {
        public PlanlamaRepository(PandapContext dc) : base(dc)
        {
        }

        public ObservableCollection<Bobin> CariyeAitKullanilabilirBobinleriGetir(string cariKod)
        {
            if (cariKod == "")
                return _dc.UretimBobinler
                    .Include(p => p.UretimEmriKodNav)
                    .Where(c => c.CariKod == "x").ToObservableCollection();

            return _dc.UretimBobinler
                .Include(p => p.UretimEmriKodNav)
                .Where(c => c.CariKod == cariKod && c.PaletId == null).ToObservableCollection();
        }

        public List<UretimEmri> KalemUretimEmirleriGetir(string kalemKod)
        {
            return Queryable.Where<UretimEmri>(_dc.UretimEmirleri, c => c.SiparisKalemKod == kalemKod).ToList();
        }

        public void KalemiAc(string kalemKod)
        {
            var dcx = new PandapContext();
            var kalem = dcx.SiparisKalemleri.Where(c => c.SiparisKalemKod == kalemKod).FirstOrDefault();
            //kalem.PLAN_KalemKapatildiMi = false;
            //kalem.PLAN_KalemKapatilmaTarihi = null;
          
            dcx.SaveChanges();

            dcx.Dispose();
        }

        public void PaketlemeToleransGuncelle(int kaliteToleransYuzde)
        {
            _dc.Ayarlars.First().PaketMax_UEmri_yuzde = kaliteToleransYuzde;
            _dc.SaveChanges();
        }

        public void UretimEmriSil(string uretimEmriKod)
        {
            var dcx = new PandapContext();
            var kalem = dcx.UretimEmirleri.First(c => c.UretimEmriKod == uretimEmriKod);
            dcx.UretimEmirleri.Remove(kalem);
            dcx.SaveChanges();

            dcx.Dispose();
        }

        public void RevizeSevkiyatHaftaGuncelle(string revizeSevkHafta, string kalemKod)
        {
            //var dcx = new PandapContext();
            //var kalem = dcx.SiparisKalemleri.Where(c => c.SiparisKalemKod == kalemKod).FirstOrDefault();
            ////kalem.RevizeSevkHaftasi = revizeSevkHafta;
       
            //dcx.SaveChanges();

            //dcx.Dispose();
        }

        public string YeniUretimEmriKodGetir_SiparisKalemden(string kalemKod)
        {
            string yeniNo = "";

            var son_emir = Queryable.FirstOrDefault<UretimEmri>(Queryable.Where<UretimEmri>(_dc.UretimEmirleri, c => c.SiparisKalemKod == kalemKod)
                    .OrderByDescending(c => c.EklenmeTarih).AsNoTracking());

            if (son_emir == null)
                yeniNo = kalemKod + "-U1";
            else
            {
                var son_emirKod = son_emir.UretimEmriKod;
                var sonNum = int.Parse(son_emirKod.Substring(son_emirKod.Length - 1));
                yeniNo = son_emirKod.Remove(son_emirKod.Length - 1, 1) + (sonNum + 1).ToString();
            }

            return yeniNo;
        }

      

        public void PaletIrsaliyeNoKaydet(int? paletNo, string irsaliyeNo)
        {
            var dcx = new PandapContext();
            var palet = dcx.UretimPaletler.Where(c => c.Id == paletNo).FirstOrDefault();
            palet.NetsisIrsaliyeNo = irsaliyeNo;
            dcx.SaveChanges();

            dcx.Dispose();
        }

        public void PaletAciklamaKaydet(int? paletNo, string aciklama)
        {
            var dcx = new PandapContext();
            var palet = dcx.UretimPaletler.Where(c => c.Id == paletNo).FirstOrDefault();
            palet.Aciklama = aciklama;
            dcx.SaveChanges();

            dcx.Dispose();
        }

        public int PandaStokMiktariGetir()
        {
            return _dc.UretimPaletler.Where(c => c.DepoOnayaGonderimTarihi != null &&
               c.CariKod == GlobalConstLogic.PANDACARI &&
               c.SevkiyatTarihi != null)
               .Sum(c => c.PaletNet_Kg);
        }

        public int DepoToplamGetir()
        {
            return _dc.UretimPaletler
                    .Include(c => c.Bobinler)
                    .Sum(c => c.PaletNet_Kg);
        }

        public int PaketlemeToleransGetir()
        {
            return _dc.Ayarlars.First().PaketMax_UEmri_yuzde;
        }

        public UretimEmri UretimEmriGetirFromUretimKod(string uretimEmriKod)
        {
            return _dc.UretimEmirleri
                .Include(c => c.PlanlamaRulolari)
                .Include(c=>c.MakineAsamalari1)
                .Include(c => c.MakineAsamalari2)
                .Where(c => c.UretimEmriKod == uretimEmriKod)
                .FirstOrDefault();
        }

        public void UretimEmriPlanlamaMiktarGuncelle(string uretimEmriKod,int miktar)
        {
            var dcx = new PandapContext();
            var emir= dcx.UretimEmirleri
                .Where(c => c.UretimEmriKod == uretimEmriKod)
                .FirstOrDefault();

            emir.Uretim_PlanlananMiktar = miktar;

            dcx.SaveChanges();


        }



        public void Add(UretimEmri uremtimEmri)
        {
            _dc.UretimEmirleri.Add(uremtimEmri);
        }

        public ObservableCollection<UretimEmri> UretimEmirleriGetir()
        {
            //var x = _dc.UretimEmirleri
            //        .Include(c => c.UretimBobinler)
            //        .Include(c => c.SiparisKalemKodNav)
            //        .Include(c => c.SiparisKalemKodNav).ThenInclude(c => c.SiparisNav)
            //        .Include(c => c.SiparisKalemKodNav).ThenInclude(c => c.SiparisNav).ThenInclude(p => p.CariKartNavigation);

            //return x.ToObservableCollection();
            return new ObservableCollection<UretimEmri>();
        }

        public ObservableCollection<UretimEmri> KaliteUretimEmirleriGetir(bool kapaliEmirlerGorunsunMu)
        {
            //var x = _dc.UretimEmirleri
            //        .Include(c => c.UretimBobinler)
            //        .Include(c => c.SiparisKalemKodNav)
            //        .Include(c => c.SiparisKalemKodNav).ThenInclude(c => c.SiparisNav)
            //        .Include(c => c.SiparisKalemKodNav).ThenInclude(c => c.SiparisNav).ThenInclude(p => p.CariKartNavigation)
            //        .Where(c => c.KapatildiMi == kapaliEmirlerGorunsunMu || c.KapatildiMi == null)
            //        .OrderByDescending(c => c.UretimEmriKod);

            //return x.ToObservableCollection();
            return new ObservableCollection<UretimEmri>();
        }

        public void PaletiKalemSarjEt(int paletId, string kalemKod)
        {

            var palet = _dc.UretimPaletler.Where(c => c.Id == paletId).First();

            palet.FiyatKalemKod = kalemKod.ToUpper();

        }

        public void PaletSevkTarihGuncelle(int paletId, DateTime tarih, int sevkEmriId, string irsaliyeNo)
        {
            PandapContext dcSevk = new PandapContext();

            var palet = dcSevk.UretimPaletler.Where(c => c.Id == paletId).First();
            palet.SevkiyatTarihi = tarih;
            palet.SevkiyatEmriId = sevkEmriId;
            palet.NetsisIrsaliyeNo = irsaliyeNo;
            palet.PaletKonum = PALETKONUM.SEVKEDILDI;

            dcSevk.SaveChanges();

        }

        public Palet PaletGetir(int paletNo)
        {
            //var x = _dc.UretimPaletler
            //        .Include(c => c.Bobinler)
            //        .Include(c => c.FiyatKalemKodNav)
            //        .Include(c => c.FiyatKalemKodNav).ThenInclude(k => k.SiparisNav)
            //        .Include(c => c.FiyatKalemKodNav).ThenInclude(c => c.SiparisNav).ThenInclude(c => c.CariKartNavigation)
            //        .Include(c => c.UretimEmriKodNav)
            //        .Include(c => c.UretimEmriKodNav).ThenInclude(k => k.SiparisKalemKodNav)
            //        .Include(c => c.UretimEmriKodNav).ThenInclude(k => k.SiparisKalemKodNav).ThenInclude(k => k.SiparisNav)
            //        .Where(c => c.Id == paletNo)

            //   .SingleOrDefault();
            //return x;
            return new Palet();
        }

        public void PaletSil(Palet palet)
        {
            _dc.Remove(palet);
        }

        public void KalemKafesOlcuKaydet(string siparisKalemKod, string ambalajKafesOlcu)
        {
            //var dcx = new PandapContext();
            //var kalem = dcx.SiparisKalemleri.First(c => c.SiparisKalemKod == siparisKalemKod);
            //kalem.AmbalajKafesOlcu = ambalajKafesOlcu;
            //dcx.SaveChanges();
            //dcx.Dispose();
        }

        public ObservableCollection<Palet> PaletleriGetir()
        {
            var x = _dc.UretimPaletler
                    .Include(c => c.CariKartNav)
                    .Include(c => c.Bobinler)
                    .Include(c => c.CariKartNav)
                    .Include(c => c.UretimEmriKodNav)
                .Where(p => p.PaletKonum == PALETKONUM.PAKETLEME)
                .OrderByDescending(s => s.Id)

                .ToObservableCollection();
            return x;
        }

        public ObservableCollection<Palet> FaturaPaletleriGetir()
        {
            //var x = _dc.UretimPaletler
            //       .Include(c => c.Bobinler)
            //       .Include(c => c.UretimEmriKodNav)
            //       .Include(c => c.FiyatKalemKodNav)
            //       .Include(c => c.FiyatKalemKodNav).ThenInclude(k => k.SiparisNav)
            //       .Include(c => c.FiyatKalemKodNav).ThenInclude(c => c.SiparisNav).ThenInclude(c => c.CariKartNavigation)
            //       .Where(c => !c.SevkiyatTarihi.HasValue)
            //       .OrderByDescending(s => s.Id)

            //   .ToObservableCollection();
            //return x;
            return new ObservableCollection<Palet>();
        }


        public int AktifAyToplamAgirlikGetir()
        {
            var x = _dc.UretimPaletler
                    .Include(c => c.Bobinler)
                    .Where(c => c.SevkiyatTarihi.GetValueOrDefault() >= new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1))
                    .Sum(c => c.Bobinler.Sum(b => b.Agirlik_kg)).GetValueOrDefault();

            return x;
        }

        public Palet PaletEkleKaydet(Palet p)
        {
            _dc.UretimPaletler.Add(p);
            _dc.SaveChanges();

            return p;
        }

        public void PaletKaydet(Palet p)
        {
            _dc.UretimPaletler.Attach(p);

            _dc.Entry(p).State = EntityState.Modified;

            _dc.SaveChanges();
        }

        public ObservableCollection<CariLookUp> PaleteHazirCarileriGetir(string kullaniciId)
        {
            //var lookUp = _dc.UretimBobinler.Where(c => c.PaletId == null)
            //  .Where(c=>c.Ekleyen== kullaniciId)
            // .Select(c => new CariLookUp { CariKod = c.CariKod, CariIsim = c.UretimEmriKodNav.SiparisKalemKodNav.SiparisNav.CariKartNavigation.CariIsim })
            // .Distinct()
            // .ToObservableCollection();

            //return lookUp;
            return new ObservableCollection<CariLookUp>();
        }




        public int GunlukTonajGetir()
        {
            var s = _dc.UretimBobinler
                    .Where(c => c.BobinEklenmeTarihi == DateTime.Now.Date && c.PaletId.HasValue == true)
                    .Sum(c => c.Agirlik_kg.Value);

            return s;
        }

        public UretimEmri UretimEmriNavGetir(string uretimEmriKod)
        {
            return _dc.UretimEmirleri.Where(c => c.UretimEmriKod == uretimEmriKod).FirstOrDefault();
        }


        public ObservableCollection<PlanlamaTakipDto> GetirUretimEmirleriPlanlamaTakipDtoVerim()
        {
            // test

            //var verimUygulamaIlkBaslamaTarih = new DateTime(2020, 10, 1);

            //var query =
            // _dc.UretimEmirleri
            //    .Include(c => c.SiparisKalemKodNav)
            //    .Include(c => c.SiparisKalemKodNav).ThenInclude(c => c.SiparisNav)
            //    .Include(c => c.SiparisKalemKodNav).ThenInclude(c => c.SiparisNav).ThenInclude(c => c.CariKartNavigation)
            //    .Include(c => c.SiparisKalemKodNav).ThenInclude(c => c.KullanimAlanTipKodNavigation)

            //   .Include(b => b.UretimPaletler).ThenInclude(b => b.Bobinler)
            //   .Include(c => c.UretimBobinler)
            //   .Include(c => c.UretimBobinler).ThenInclude(c => c.PaletIdNav)
            //   .Include(c => c.PlanlamaRulolari)
            //   .Include(c => c.KaliteRedMalzemeListe)
            //   .Where(c=>c.EklenmeTarih> verimUygulamaIlkBaslamaTarih)
            //   .ToList()
            //   .Select(c => new PlanlamaTakipDto
            //   {

            //       Key = c.SiparisKalemKod + Guid.NewGuid(),
            //       ParentKey = c.SiparisKalemKod,
            //       AnaKartNo = c.AnaKartNo,

            //       EklenmeTarih =c.EklenmeTarih,
            //       UretimEmriSonPaketlenmeTarihi = c.SonPaketlenmeTarihi,

            //       KapatilmaTarihi= c.KapatildiMi.GetValueOrDefault()==true?c.SonPaketlenmeTarihi:null,


            //       PlanlamaRulolari = string.Join(", ", c.PlanlamaRulolari.Select(s => s.PlanlamaRuloNo).ToArray()),
            //       DokmeRuloNumaralari = string.Join(", ", c.PlanlamaRulolari.Select(s => s.DokmeRuloNo).ToArray()),

            //       UretimEmriKod = c.UretimEmriKod,
            //       KartNo = c.KartNo,

            //       KartPlanlamaRulolari=c.PlanlamaRulolari,


            //       KullanimAlani = c.SiparisKalemKodNav.KullanimAlanTipKod,
            //       KullanimAlanUrunGrup=c.SiparisKalemKodNav.KullanimAlanTipKodNavigation.UretimUrunGrup,


            //       PlanlananMiktar = c.Uretim_PlanlananMiktar.GetValueOrDefault(),
            //       PaketlenenMiktar = c.Uretim_PaketlenenMiktar.GetValueOrDefault(),
            //       KaliteRedMiktar = c.KaliteRedMiktar.GetValueOrDefault(),
            //       PaketKarantinaMiktar = c.PaketKarantinaMiktar.GetValueOrDefault(),

            //       KalemMiktar = c.SiparisKalemKodNav.Miktar_kg,
            //       KapatildiMi = c.KapatildiMi.GetValueOrDefault(),

            //       MaxKombinEni = c.MaxKombinEni,
            //       KombinlerEnToplam=c.KombinlerEnToplam,
            //       KombinMiktari_kg = c.KombinMiktari_kg,
            //       Kombinler=c.Kombinler,

            //       MusteriAd=c.SiparisKalemKodNav.SiparisNav.CariKartNavigation.CariIsim,
            //       Kalinlik=c.SiparisKalemKodNav.Kalinlik_micron,
            //       En=c.SiparisKalemKodNav.En_mm,


            //       // dokum eni
            //       DokumEni_mm = c.PlanlamaRulolari.Count > 0 ? (int)c.PlanlamaRulolari.Max(r => r.DokumEni_mm.GetValueOrDefault()) : 0,
            //       DokumMiktari_kg = c.PlanlamaRulolari.Sum(r => r.DokmeRuloAgirligi_kg),

            //   });

            //var sonuc = query.ToObservableCollection();

            //return sonuc;
            return new ObservableCollection<PlanlamaTakipDto>();
        }


        public ObservableCollection<PlanlamaTakipDto> GetirUretimEmirleriPlanlamaTakipDto(bool sadeceAcikOlanlar=true)
        {
            // test

            //var sadeceAciklar = !sadeceAcikOlanlar;

            //var query0 = _dc.UretimEmirleri.AsQueryable();

            //if (sadeceAciklar)
            //    query0 = query0.Where(c => c.KapatildiMi == false).AsQueryable();

            //var query= query0
            //   .Include(c => c.SiparisKalemKodNav)
            //   .Include(c => c.SiparisKalemKodNav).ThenInclude(c => c.SiparisNav)
            //   .Include(c => c.SiparisKalemKodNav).ThenInclude(c => c.SiparisNav).ThenInclude(c => c.CariKartNavigation)
            //   .Include(b => b.UretimPaletler).ThenInclude(b => b.Bobinler)
            //   .Include(c => c.PlanlamaRulolari)
            //   .Include(c=>c.KaliteRedMalzemeListe)
            //   .ToList()
            //   .Select(c => new PlanlamaTakipDto
            //   {
            //       Key = c.SiparisKalemKod + Guid.NewGuid(),
            //       ParentKey = c.SiparisKalemKod,

            //       RowGuid = c.RowGuid,
            //       MesajSayisi = c.MesajSayisi,
            //       OkunmamisMesajSayisi = c.OkunmamisMesajSayisi,

            //       PlanlamaRulolari = string.Join(", ", c.PlanlamaRulolari.Select(s => s.PlanlamaRuloNo).ToArray()),
            //       DokmeRuloNumaralari = string.Join(", ", c.PlanlamaRulolari.Select(s => s.DokmeRuloNo).ToArray()),

            //       SiparisKod = c.SiparisKalemKodNav.SiparisKod,
            //       SiparisKalemKod = c.SiparisKalemKod,
            //       UretimEmriKod = c.UretimEmriKod,
            //       KartNo = c.KartNo,
            //       BagliBobinler = "",
            //       MusteriAd = c.SiparisKalemKodNav.SiparisNav.CariKartNavigation?.CariIsim,
            //       Alasim = c.SiparisKalemKodNav.AlasimTipKod,
            //       Kalinlik = c.SiparisKalemKodNav.Kalinlik_micron,
            //       En = c.SiparisKalemKodNav.En_mm,
            //       IcCap = c.SiparisKalemKodNav.RuloIcCap_mm,
            //       MinCap = c.SiparisKalemKodNav.RuloDiscapMin_mm,
            //       MaxCap = c.SiparisKalemKodNav.RuloDiscapMax_mm,
            //       Kondusyon = c.SiparisKalemKodNav.SertlikTipKod,
            //       Ek = c.SiparisKalemKodNav.MaxEk,
            //       Yuzey = c.SiparisKalemKodNav.YuzeyTipKod,
            //       MasuraCins = c.SiparisKalemKodNav.MasuraTipKod,
            //       Metraj = c.SiparisKalemKodNav.Metraj_mt,


            //       MetrajTolerans = c.SiparisKalemKodNav.MetrajEksi_mt + "-" + c.SiparisKalemKodNav.MetrajArti_mt,

            //       KalinlikToleransYuzde = c.SiparisKalemKodNav.KalinlikEksi_yuzde + "-" + c.SiparisKalemKodNav.KalinlikArti_yuzde,
            //       Ambalaj = c.SiparisKalemKodNav.AmbalajTipKod,
            //       SevkHafta = c.SiparisKalemKodNav.SiparisNav.SevkYilHafta,
            //       SevkYilAy = c.SiparisKalemKodNav.SiparisNav.SevkYilHafta.Split('/')[0] + "/" +
            //            CalenderUtil.MounthFromWeekNumber(int.Parse(c.SiparisKalemKodNav.SiparisNav.SevkYilHafta.Split('/')[0])
            //            , int.Parse(c.SiparisKalemKodNav.SiparisNav.SevkYilHafta.Split('/')[1]))
            //            .ToString().PadLeft(2, '0'),

            //       KullanimAlani = c.SiparisKalemKodNav.KullanimAlanTipKod,
            //       KaydiriciOraniMinMaxStr=c.SiparisKalemKodNav.KaydiriciOraniMinMaxStr,



            //       UretimEmriSonPaketlenmeTarihi = c.SonPaketlenmeTarihi,

            //       PlanlananMiktar = c.Uretim_PlanlananMiktar.GetValueOrDefault(),
            //       UretimdeYuruyenMiktar = c.UretimPlanYuruyen,
            //       KaliteRedMiktar = c.KaliteRedMiktar.GetValueOrDefault(),
            //       PaketlenenMiktar = c.Uretim_PaketlenenMiktar.GetValueOrDefault()-c.PaketKarantinaMiktar.GetValueOrDefault(),
            //       PaketKarantinaMiktar = c.PaketKarantinaMiktar.GetValueOrDefault(),

            //       KalemMiktar = c.SiparisKalemKodNav.Miktar_kg,
            //       KapatildiMi = c.KapatildiMi.GetValueOrDefault(),
            //       AmbalajKafesOlcu = c.SiparisKalemKodNav.AmbalajKafesOlcu,


            //       MaxKombinEni=c.MaxKombinEni,
            //       KombinlerEnToplam = c.KombinlerEnToplam,
            //       AnaKartNo=c.AnaKartNo,


            //       // manuel giriş alanları
            //       Pas5 = c.Pas5,
            //       Pas4 = c.Pas4,
            //       Pas3 = c.Pas3,
            //       Pas2 = c.Pas2,
            //       Pas1 = c.Pas1,
            //       FolyoHaddeToplam = c.FolyoHaddeToplam.GetValueOrDefault(),
            //       Seperator1 = c.Seperator1,
            //       Seperator2 = c.Seperator2,
            //       Dilme = c.Dilme,
            //       TavaGirecek = c.TavaGirecek,
            //       Tavda = c.Tavda,
            //       TavdanCikan = c.TavdanCikan,
            //       Paketlenecek = c.Paketlenecek,
            //       KalemSiparisDurum = "",
            //       SiparisDurum = "",

            //       Sp_Dilme_Cikis = c.Sp_Dilme_Cikis,


            //   });

            //query = query.Select(c =>
            //{

            //    c.Bakiye = c.PlanlananMiktar
            //                - ( c.PaketlenenMiktar + c.UretimdeYuruyenMiktar)
            //                + c.KaliteRedMiktar
            //                + c.PaketKarantinaMiktar;


            //    c.Bakiye = c.Bakiye < 0 ? 0 : c.Bakiye;


            //    return c;
            //});

            //var sonuc = query
            //    .Where(o => !o.SiparisKod.Contains("P00-") && !o.SiparisKod.Contains("P01-"))
            //    .OrderBy(o => o.SiparisKalemKod).ToObservableCollection();

            //return sonuc;

            return new ObservableCollection<PlanlamaTakipDto>();
        }

        public ObservableCollection<PlanlamaTakipDto> GetirKalemPlanlamaTakip_KapasitifDto()
        {
            //var query = _dc.SiparisKalemleri
            //      .Include(c => c.KullanimAlanTipKodNavigation)
            //      .Include(c => c.SiparisNav)
            //      .Include(c => c.SiparisNav).ThenInclude(c => c.CariKartNavigation)
            //      .Include(c => c.UretimEmirleri)
            //      .Include(c => c.UretimEmirleri).ThenInclude(b => b.UretimBobinler)
            //      .Include(c => c.UretimEmirleri).ThenInclude(s => s.PlanlamaRulolari)
            //      .Include(c => c.UretimEmirleri).ThenInclude(s => s.KaliteRedMalzemeListe)
            //      .Where(c=>c.SiparisNav.KapasitifMi==true)
            //      .Where(c => c.SiparisNav.SiparisAcikMi == true)
            //      .ToList()
            //      .Select(c => new PlanlamaTakipDto
            //      {


            //          SiparisKod = c.SiparisKod,
            //          SiparisKalemKod = c.SiparisKalemKod,

            //          RowGuid = c.RowGuid,
            //          MesajSayisi = c.MesajSayisi,
            //          OkunmamisMesajSayisi = c.OkunmamisMesajSayisi,

            //          KartNo = "",
            //          UretimEmriKod = "",
            //          BagliBobinler = "",

            //          SiparisDurum = c.SiparisNav.SiparisSurecDurum,
            //          KapasitifDurum ="Kapasitif",
            //          KullanimAlani = c.KullanimAlanTipKod,

            //          MusteriAd = c.SiparisNav.CariKartNavigation?.CariIsim,
            //          Alasim = c.AlasimTipKod,
            //          Kalinlik = c.Kalinlik_micron,
            //          En = c.En_mm,
            //          IcCap = c.RuloIcCap_mm,
            //          MinCap = c.RuloDiscapMin_mm,
            //          MaxCap = c.RuloDiscapMax_mm,
            //          Kondusyon = c.SertlikTipKod,
            //          KaydiriciOraniMinMaxStr = c.KaydiriciOraniMinMaxStr,

            //          Ek = c.MaxEk,

            //          Yuzey = c.YuzeyTipKod,
            //          MasuraCins = c.MasuraTipKod,
            //          Metraj = c.Metraj_mt,
            //          MetrajTolerans = c.MetrajEksi_mt + "-" + c.MetrajArti_mt,

            //          KalinlikToleransYuzde = c.KalinlikEksi_yuzde + "-" + c.KalinlikArti_yuzde,
            //          Ambalaj = c.AmbalajTipKod,
            //          SevkHafta = c.SiparisNav.SevkYilHafta,
            //          SevkYilAy = c.SiparisNav.SevkYilHafta.Split('/')[0] + "/" +
            //            CalenderUtil.MounthFromWeekNumber(int.Parse(c.SiparisNav.SevkYilHafta.Split('/')[0])
            //            , int.Parse(c.SiparisNav.SevkYilHafta.Split('/')[1]))
            //            .ToString().PadLeft(2, '0'),



            //          KalemMiktar = c.Miktar_kg,



            //          UretimdeYuruyenMiktar = c.UretimEmirleri
            //                          .Sum(u => u.UretimPlanYuruyen),


            //          UretimUrunGrup = c.KullanimAlanTipKodNavigation.UretimUrunGrup,
            //          HaftalikTonaj = ((int)((decimal)c.KullanimAlanTipKodNavigation.AylikTonaj / 4)) * 1000

            //      })

            //      .GroupBy(c => c.SiparisKod)
            //        .Select(c => new PlanlamaTakipDto
            //        {
            //            RowGuid = c.First().RowGuid,
            //            MesajSayisi = c.First().MesajSayisi,
            //            OkunmamisMesajSayisi = c.First().OkunmamisMesajSayisi,

            //            KalemMiktar = c.Sum(u => u.KalemMiktar)<0?0: c.Sum(u => u.KalemMiktar),
            //            KapasitifDurum = "Kapasitif",
            //            HaftalikTonaj = c.Max(u => u.HaftalikTonaj),
            //            MusteriAd = c.First().MusteriAd,
            //            SiparisDurum = c.First().SiparisDurum,
            //            SevkHafta = c.First().SevkHafta,
            //            SevkYilAy = c.First().SevkYilAy,
            //            SiparisKod = c.First().SiparisKod,
            //            SiparisKalemKod = c.First().SiparisKalemKod,
            //            KullanimAlani = c.First().KullanimAlani,
            //            Alasim = c.First().Alasim,
            //            Kalinlik = c.First().Kalinlik,
            //            En =c.First().En,

            //            ToplamPlanlanacakVeUretimdeki = c.Sum(u => u.KalemMiktar).GetValueOrDefault() < 0 ? 0 : c.Sum(u => u.KalemMiktar).GetValueOrDefault(),
            //            Bakiye = c.Sum(u => u.KalemMiktar).GetValueOrDefault() < 0 ? 0 : c.Sum(u => u.KalemMiktar).GetValueOrDefault(),

            //        })
            //        .Where(c=>c.KalemMiktar>0)
            //        .ToObservableCollection();



            //return query.ToObservableCollection();

            return new ObservableCollection<PlanlamaTakipDto>();
        }


        public ObservableCollection<PlanlamaTakipDto> GetirKalemPlanlamaTakip_ReelDto(bool sadeceKapatilanlar=false)
        {
            //var query = _dc.SiparisKalemleri
            //      .Include(c => c.KullanimAlanTipKodNavigation)
            //      .Include(c => c.SiparisNav)
            //      .Include(c => c.SiparisNav).ThenInclude(c => c.CariKartNavigation)
            //      .Include(c => c.UretimEmirleri)
            //      .Include(c => c.UretimEmirleri).ThenInclude(b => b.UretimPaletler).ThenInclude(b=>b.Bobinler)
            //      .Include(c => c.UretimEmirleri).ThenInclude(s => s.PlanlamaRulolari)
            //      .Include(c=>c.UretimEmirleri).ThenInclude(s=>s.KaliteRedMalzemeListe)
            //      .Where(c=>c.KapasitifMi==false)
            //      .Where(c => c.PLAN_KalemKapatildiMi == sadeceKapatilanlar)
            //      .ToList()
            //      .Select(c => new PlanlamaTakipDto
            //      {
            //          PlanlamaRulolari = "",

            //          SiparisKod = c.SiparisKod,
            //          SiparisKalemKod = c.SiparisKalemKod,
            //          RowGuid = c.RowGuid,
            //          MesajSayisi = c.MesajSayisi,
            //          OkunmamisMesajSayisi = c.OkunmamisMesajSayisi,
            //          KartNo = "",
            //          UretimEmriKod = "",
            //          BagliBobinler = "",
            //          KalemSiparisDurum = c.PLAN_KalemKapatildiMi == true ? "Kapalı" : "Açık",
            //          SiparisDurum = c.SiparisNav.SiparisSurecDurum,
            //          KapasitifDurum = "Reel",
            //          KullanimAlani = c.KullanimAlanTipKod,

            //          MusteriAd = c.SiparisNav.CariKartNavigation?.CariIsim,
            //          Alasim = c.AlasimTipKod,
            //          Kalinlik = c.Kalinlik_micron,
            //          En = c.En_mm,
            //          IcCap = c.RuloIcCap_mm,
            //          MinCap = c.RuloDiscapMin_mm,
            //          MaxCap = c.RuloDiscapMax_mm,
            //          Kondusyon = c.SertlikTipKod,
            //          KaydiriciOraniMinMaxStr = c.KaydiriciOraniMinMaxStr,

            //          Ek = c.MaxEk,

            //          Yuzey = c.YuzeyTipKod,
            //          MasuraCins = c.MasuraTipKod,
            //          Metraj = c.Metraj_mt,
            //          MetrajTolerans = c.MetrajEksi_mt + "-" + c.MetrajArti_mt,

            //          KalinlikToleransYuzde = c.KalinlikEksi_yuzde + "-" + c.KalinlikArti_yuzde,
            //          Ambalaj = c.AmbalajTipKod,
            //          SevkHafta = c.SiparisNav.SevkYilHafta,
            //          SevkYilAy = c.SiparisNav.SevkYilHafta.Split('/')[0] + "/" +
            //            CalenderUtil.MounthFromWeekNumber(int.Parse(c.SiparisNav.SevkYilHafta.Split('/')[0])
            //            , int.Parse(c.SiparisNav.SevkYilHafta.Split('/')[1]))
            //            .ToString().PadLeft(2, '0'),


            //          // include ile gerekli alt tablolar çağırılmış olmalı
            //          KalemMiktar = c.Miktar_kg,
            //          PlanlananMiktar = c.UretimEmirleri.Sum(u => u.Uretim_PlanlananMiktar.GetValueOrDefault()),
            //          UretimdeYuruyenMiktar = c.UretimEmirleri.Sum(u => u.UretimPlanYuruyen),
            //          PaketlenenMiktar = c.UretimEmirleri.Sum(b => b.Uretim_PaketlenenMiktar.GetValueOrDefault()),
            //          KaliteRedMiktar = c.UretimEmirleri.Sum(u => u.KaliteRedMiktar.GetValueOrDefault()),
            //          PaketKarantinaMiktar= c.UretimEmirleri.Sum(b=>b.PaketKarantinaMiktar.GetValueOrDefault()),



            //          AmbalajKafesOlcu = c.AmbalajKafesOlcu,
            //          KapatildiMi = c.PLAN_KalemKapatildiMi.GetValueOrDefault(),

            //          UretimEmirleri = c.UretimEmirleri.ToObservableCollection(),
            //          PlanlamaVarMi = c.UretimEmirleri.Count > 0 ? "E" : "H",
            //          UretimUrunGrup = c.KullanimAlanTipKodNavigation.UretimUrunGrup,
            //          HaftalikTonaj = ((int)((decimal)c.KullanimAlanTipKodNavigation.AylikTonaj/4))*1000,



            //          // manuel giriş alanları
            //          Pas5 = c.UretimEmirleri.Sum(u => u.Pas5.GetValueOrDefault()),
            //          Pas4 = c.UretimEmirleri.Sum(u => u.Pas4.GetValueOrDefault()),
            //          Pas3 = c.UretimEmirleri.Sum(u => u.Pas3.GetValueOrDefault()),
            //          Pas2 = c.UretimEmirleri.Sum(u => u.Pas2.GetValueOrDefault()),
            //          Pas1 = c.UretimEmirleri.Sum(u => u.Pas1.GetValueOrDefault()),
            //          Seperator1 = c.UretimEmirleri.Sum(u => u.Seperator1.GetValueOrDefault()),
            //          Seperator2 = c.UretimEmirleri.Sum(u => u.Seperator2.GetValueOrDefault()),
            //          Dilme = c.UretimEmirleri.Sum(u => u.Dilme.GetValueOrDefault()),
            //          TavaGirecek = c.UretimEmirleri.Sum(u => u.TavaGirecek.GetValueOrDefault()),
            //          Tavda = c.UretimEmirleri.Sum(u => u.Tavda.GetValueOrDefault()),
            //          TavdanCikan = c.UretimEmirleri.Sum(u => u.TavdanCikan.GetValueOrDefault()),
            //          Paketlenecek = c.UretimEmirleri.Sum(u => u.Paketlenecek.GetValueOrDefault()),


            //      });

            //query = query.Select(c =>
            //{
            //    c.Yuzde12_Kisit = (c.Bakiye <= c.KalemMiktar * 0.12);
            //    c.Bakiye = c.KalemMiktar.GetValueOrDefault() -(c.PaketlenenMiktar + c.UretimdeYuruyenMiktar)+c.KaliteRedMiktar + c.PaketKarantinaMiktar;

            //    c.Bakiye = c.Bakiye < 0 ? 0 : c.Bakiye;
            //    c.ToplamPlanlanacakVeUretimdeki = c.Bakiye + c.UretimdeYuruyenMiktar;

            //    return c;
            //});



            //return query.ToObservableCollection();

            return new ObservableCollection<PlanlamaTakipDto>();
        }

        public void UretimEmriBilgileriKaydet(PlanlamaTakipDto dt)
        {
            var dcx = new PandapContext();
            var emir = dcx.UretimEmirleri.Where(c => c.UretimEmriKod == dt.UretimEmriKod).FirstOrDefault();

            if (emir == null) return;

          
            emir.Pas1 = dt.Pas1.GetValueOrDefault();
            emir.Pas2 = dt.Pas2.GetValueOrDefault();
            emir.Pas3 = dt.Pas3.GetValueOrDefault();
            emir.Pas4 = dt.Pas4.GetValueOrDefault();
            emir.Pas5 = dt.Pas5.GetValueOrDefault();

            emir.Seperator1 = dt.Seperator1.GetValueOrDefault();
            emir.Seperator2 = dt.Seperator2.GetValueOrDefault();

            emir.Dilme = dt.Dilme.GetValueOrDefault();
            emir.TavaGirecek = dt.TavaGirecek.GetValueOrDefault();
            emir.TavdanCikan = dt.TavdanCikan.GetValueOrDefault();
            emir.Tavda = dt.Tavda.GetValueOrDefault();

            emir.Paketlenecek = dt.Paketlenecek.GetValueOrDefault();
            emir.Sp_Dilme_Cikis = dt.Sp_Dilme_Cikis.GetValueOrDefault();

            dcx.SaveChanges();
        }

        public void PlanlamaRuloEkleVeyaGuncelle(ObservableCollection<UretimEmriRulo> rulolar)
        {
            var dcx = new PandapContext();
            foreach (var item in rulolar)
            {
                if (item.Id == 0)
                    dcx.PlanlamaRulolari.Add(item);
                else
                {
                    var rulo = dcx.PlanlamaRulolari.First(u => u.Id == item.Id);
                    rulo.DokumEni_mm = item.DokumEni_mm;
                    rulo.BaslangicEni_mm = item.BaslangicEni_mm;
                    rulo.DokmeRuloAgirligi_kg = item.DokmeRuloAgirligi_kg;
                    rulo.DokmeRuloNo = item.DokmeRuloNo;
                    rulo.BaslangicNo_kg = item.BaslangicNo_kg;
                    rulo.PlanlamaRuloNo = item.PlanlamaRuloNo;
                }
            }

            dcx.SaveChanges();
        }

        public void MakinaAsama1_EkleVeyaGuncelle(ObservableCollection<UretimEmriMakineAsama1> makinaAsamalar)
        {
            var dcx = new PandapContext();
            foreach (var asama in makinaAsamalar)
            {
                if (asama.Id == 0)
                    dcx.MakinaAsamalari1.Add(asama);
                else
                {
                    var rulo = dcx.MakinaAsamalari1.First(u => u.Id == asama.Id);
                    rulo.UretimEmriKod = asama.UretimEmriKod;
                    rulo.Makine = asama.Makine;
                    rulo.ProsesMin = asama.ProsesMin;
                    rulo.ProsesMax = asama.ProsesMax;
                    rulo.KenarKesme = asama.KenarKesme;

                    rulo.FiiliBaslamaZaman = asama.FiiliBaslamaZaman;
                    rulo.FiiliBitisZaman = asama.FiiliBitisZaman;

                  
                }
            }

            dcx.SaveChanges();
        }


        public void MakinaAsama2_EkleVeyaGuncelle(ObservableCollection<UretimEmriMakineAsama2> makineAsamalari2)
        {
            var dcx = new PandapContext();
            foreach (var asama in makineAsamalari2)
            {
                if (asama.Id == 0)
                    dcx.MakinaAsamalari2.Add(asama);
                else
                {
                    var rulo = dcx.MakinaAsamalari2.First(u => u.Id == asama.Id);
                    rulo.UretimEmriKod = asama.UretimEmriKod;
                    rulo.Makine = asama.Makine;
                    rulo.ProsesMin = asama.ProsesMin;
                    rulo.ProsesMax = asama.ProsesMax;
                    rulo.KenarKesme = asama.KenarKesme;

                    rulo.FiiliBaslamaZaman = asama.FiiliBaslamaZaman;
                    rulo.FiiliBitisZaman = asama.FiiliBitisZaman;


                }
            }

            dcx.SaveChanges();
        }
        public ObservableCollection<Palet> DepoOnayiBekleyenPaletleriGetirYeni()
        {
            var x = _dc.UretimPaletler
                    .Include(c => c.Bobinler)
                    .Include(p => p.CariKartNav)
                    .Include(c => c.UretimEmriKodNav)
                    .Include(c => c.UretimEmriKodNav).ThenInclude(k => k.SiparisKalemKodNav)
                    .Where(u => u.PaletKonum == PALETKONUM.DEPO_ONAY)
                .OrderByDescending(c => c.Id)
                .ToObservableCollection();
            return x;
        }

        public List<MamulDepoStokDto> MamulDepoTumunuGetir(bool lmeYoksaGunluktenAlinsinMi)
        {
            var sonuc = MamulDepoDtoStoklariGetirQuery(lmeYoksaGunluktenAlinsinMi,PALETKONUM.TUMU, null, null);
            return sonuc;
        }

        public List<MamulDepoStokDto> MamulDepoSevkEdilenleriGetir(bool lmeYoksaGunluktenAlinsinMi,string yil, string ay)
        {
            var ay_sayi = int.Parse(ay);
            var yil_sayi = int.Parse(yil);
            var sonuc = MamulDepoDtoStoklariGetirQuery(lmeYoksaGunluktenAlinsinMi,PALETKONUM.SEVKEDILDI, yil_sayi, ay_sayi);
            return sonuc;
        }

        public MamulDepoStokDto MamulDepoStokGetir(bool lmeYoksaGunluktenAlinsinMi,int paletId)
        {
            var sonuc = MamulDepoDtoStoklariGetirQuery(lmeYoksaGunluktenAlinsinMi,PALETKONUM.TUMU, null, null, paletId).FirstOrDefault();
            return sonuc;
        }

        public List<MamulDepoStokDto> MamulDepoStoklariGetir(bool lmeYoksaGunluktenAlinsinMi)
        {
            var sonuc = MamulDepoDtoStoklariGetirQuery(lmeYoksaGunluktenAlinsinMi,PALETKONUM.DEPO, null, null);
            return sonuc;
        }


        public List<MamulDepoStokDto> MamulDepoStoklariFiltrele(bool lmeYoksaGunluktenAlinsinMi,string paletKonum)
        {
            var sonuc = MamulDepoDtoStoklariGetirQuery(lmeYoksaGunluktenAlinsinMi,paletKonum, null, null);
            return sonuc;
        }


        private List<MamulDepoStokDto> MamulDepoDtoStoklariGetirQuery(bool lmeYoksaGunluktenAlinsinMi, string paletKonum, int? yil, int? ay,  int paletId = 0)
        {
            //var lmeTarih = DateTime.Now.AddDays(-1).Date;
            //var lmeGunlukFiyat = LmeService.LmeFiyatGetirTarihten(lmeTarih);

            //var ay_sayi = int.Parse(ay.GetValueOrDefault().ToString());
            //var yil_sayi = int.Parse(yil.GetValueOrDefault().ToString());

            //Expression<Func<Palet, bool>> predicate = p => (p.PaletKonum==paletKonum || paletKonum == PALETKONUM.TUMU);

            //if (paletKonum.Contains(",")) {
            //    var paletKonumListe = paletKonum.Split(',');
            //    predicate= p => (p.PaletKonum == paletKonumListe[0] || p.PaletKonum== paletKonumListe[1]);
            //}


            //var query = _dc.UretimPaletler
            //         .Include(c => c.Bobinler)
            //         .Include(c => c.UretimEmriKodNav)
            //         .Include(c => c.UretimEmriKodNav).ThenInclude(c => c.SiparisKalemKodNav)
            //         .Include(c => c.FiyatKalemKodNav)
            //         .Include(c => c.FiyatKalemKodNav).ThenInclude(c => c.SiparisNav)
            //         .Include(c => c.FiyatKalemKodNav).ThenInclude(c => c.SiparisNav).ThenInclude(c => c.TakipDovizTipKodNavigation)
            //         .Include(c => c.FiyatKalemKodNav).ThenInclude(c => c.SiparisNav).ThenInclude(c => c.SatisTipKodNavigation)
            //         .Include(c => c.FiyatKalemKodNav).ThenInclude(c => c.SiparisNav).ThenInclude(c => c.TeslimTipKodNavigation)
            //         .Include(c => c.FiyatKalemKodNav).ThenInclude(c => c.SiparisNav).ThenInclude(c => c.CariKartNavigation)
            //         .Where(predicate)
            //         .Select(c => new MamulDepoStokDto
            //         {
            //             PaletId = c.Id,
            //             SevkiyatEmriId = c.SevkiyatEmriId,
            //             NetsisIrsaliyeNo = c.NetsisIrsaliyeNo,


            //             BobinlerTumu = c.Bobinler.Select(b => new BobinInfo { Agirlik = b.Agirlik_kg, BobinNo = b.BobinNo }).ToList(),

            //             Metraj = c.UretimEmriKodNav.SiparisKalemKodNav.Metraj_mt,
            //             RuloIcCap = c.UretimEmriKodNav.SiparisKalemKodNav.RuloIcCap_mm,
            //             Kalinlik_micron = c.UretimEmriKodNav.SiparisKalemKodNav.Kalinlik_micron,
            //             En_mm = c.UretimEmriKodNav.SiparisKalemKodNav.En_mm,
            //             AlasimTipKod = c.UretimEmriKodNav.SiparisKalemKodNav.AlasimTipKod,
            //             SertlikTipKod = c.UretimEmriKodNav.SiparisKalemKodNav.SertlikTipKod,
            //             SiparisKalemKod = c.UretimEmriKodNav.SiparisKalemKodNav.SiparisKalemKod,
            //             KartNo = c.UretimEmriKodNav.KartNo,
            //             FirmaUrunNo = c.UretimEmriKodNav.SiparisKalemKodNav.MusteriUrunKodu,
            //             KullanimAlaniTipKod = c.UretimEmriKodNav.SiparisKalemKodNav.KullanimAlanTipKod,

            //             FiyatKalemKod = c.FiyatKalemKod,
            //             UrunKod = c.FiyatKalemKodNav.UrunKod,
            //             SiparisKod = c.FiyatKalemKodNav.SiparisNav.SiparisKod,
            //             DovizTipKod = c.FiyatKalemKodNav.SiparisNav.TakipDovizTipKod,


            //             //TODO BU KISIMDA SORUN VAR//

            //             CariKod = c.FiyatKalemKodNav.SiparisNav.CariKod,
            //             FirmaSiparisNo = c.FiyatKalemKodNav.SiparisNav.FirmaSiparisNo,

            //             CariIsim = c.FiyatKalemKodNav.SiparisNav.CariKartNavigation.CariIsim,
            //             UlkeAd = c.FiyatKalemKodNav.SiparisNav.CariKartNavigation.UlkeAd,

            //             MusteriTemsilcisi = c.FiyatKalemKodNav.SiparisNav.CariKartNavigation.PlasiyerAd,
            //             Agent = c.FiyatKalemKodNav.SiparisNav.CariKartNavigation.Agent,


            //             //-------------------------------------------
            //             SevkYilHafta = c.FiyatKalemKodNav.SiparisNav.SevkYilHafta,
            //             LfxKod = c.FiyatKalemKodNav.LmeBaglamaKod,

            //             LmeBF_Ton = c.FiyatKalemKodNav.LmeTutar.GetValueOrDefault(),
            //             IscilikBF_Ton = c.FiyatKalemKodNav.IscilikTutar.GetValueOrDefault(),
            //             KulceBF_Ton = c.FiyatKalemKodNav.KulceTutar,
            //             IscilikVF_Oran = c.FiyatKalemKodNav.IscilikVadeFarkiOran,

            //             BirimFiyat_Kg = c.FiyatKalemKodNav.BirimFiyat.GetValueOrDefault(),
            //             KdvOran = c.FiyatKalemKodNav.KdvOran.GetValueOrDefault(),

            //             NetsisDovizTipId = c.FiyatKalemKodNav.SiparisNav.TakipDovizTipKodNavigation.NetsisId,
            //             NetsisSatisFaturaTipId = c.FiyatKalemKodNav.SiparisNav.SatisTipKodNavigation.NetsisId,
            //             NetsisTeslimTipId = c.FiyatKalemKodNav.SiparisNav.TeslimTipKodNavigation.NetsisId,

            //             KullanimAlani = c.FiyatKalemKodNav.KullanimAlanTipKod,

            //             //// temel palet bilgileri
            //             SevkiyatTarihi = c.SevkiyatTarihi,
            //             DepoKabulTarihi = c.DepoOnayaGonderimTarihi,

            //             PaletEbat = c.PaletEbat,
            //             BobinlerBirlesik = c.BobinlerBirlesik,
            //             GrupKey = c.PaletGrupKey,

            //             Kalinlik_En = c.UretimEmriKodNav.SiparisKalemKodNav.Kalinlik_micron.ToString() + "μ-" +
            //             c.UretimEmriKodNav.SiparisKalemKodNav.En_mm.ToString() + "mm",
            //             PaletDara_Kg = c.PaletDara_Kg,

            //             FirinNo = c.FirinNo,
            //             TavNo = c.TavNo,
            //             SehpaNo = c.SehpaNo,
            //             StokGunSuresi = (DateTime.Now - c.DepoOnayaGonderimTarihi).Value.Days,
            //             Aciklama = c.Aciklama,
            //             GTip = "",
            //             GTipSatirKod = "",

            //         }) ;




            //if (yil_sayi != 0 && paletKonum == PALETKONUM.SEVKEDILDI)
            //{
            //    query = query.Where(c => c.SevkiyatTarihi.Value.Year == yil
            //    && (c.SevkiyatTarihi.Value.Month == ay_sayi || ay_sayi == 0));

            //}

            //query = paletKonum == PALETKONUM.DEPO ? query.OrderByDescending(c => c.DepoKabulTarihi) : query;

            //if (paletId != 0) query = query.Where(c => c.PaletId == paletId);



            //var liste = query.AsNoTracking().ToList();


            //foreach (var t in liste)
            //{
            //    t.PaletNet_Kg = t.BobinlerTumu.Sum(c => c.Agirlik);

            //    t.PaletBrut_Kg = t.PaletNet_Kg + t.PaletDara_Kg;

            //    t.BobinlerBirlesik = String.Join(";", t.BobinlerTumu.Select(c => c.BobinNo));

            //    t.MasuraSayisi = BobinSayiHelper.BobinAdetBul(t.BobinlerBirlesik);

            //    var lmeBf = lmeYoksaGunluktenAlinsinMi == true ? lmeGunlukFiyat.LmeDegerGetir(t.DovizTipKod,"",t.PaletId.ToString()) : t.LmeBF_Ton;

            //    var u = SiparisFiyatHesapService.FiyatSonucDTO_Getir(t.CariKod, lmeBf, t.KulceBF_Ton, t.IscilikBF_Ton, t.IscilikVF_Oran,
            //                      t.KdvOran, t.PaletNet_Kg.GetValueOrDefault(), t.PaletId.ToString(), t.DovizTipKod);

            //    t.LmeBF_Ton = lmeBf;
            //    t.BirimFiyat_Kg = u.BirimFiyat;

            //    t.PaletToplamTutar = Decimal.Round(u.ToplamTutar, 1);
            //    t.PaletKdvTutar = Decimal.Round(u.KdvTutar, 1); ;
            //    t.PaletGenelToplam = Decimal.Round(u.GenelToplamTutar, 1);

            //}


            //return liste;

            return new List<MamulDepoStokDto>();
        }

    }
}
using Microsoft.EntityFrameworkCore;
using mnd.Common.Helpers;
using mnd.Logic.Helper;
using mnd.Logic.Model.Netsis;
using mnd.Logic.Model.Satis;
using mnd.Logic.Services._DTOs;
using mnd.Logic.Services.SiparisService;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace mnd.Logic.Persistence.Repositories
{
    public class SatirFiyatSonucDto
    {
        public string CariKod { get; set; }
        public int MiktarKg { get; set; }
        public decimal IscilikVadeFarkiTutar { get; set; }
        public decimal BirimFiyat { get; set; }
        public decimal ToplamTutar { get; set; }
        public decimal KdvTutar { get; set; }
        public decimal GenelToplamTutar { get; set; }
        public string IlgiliId { get; set; }
        public string DovizTipKod { get; set; }
    }

    public class PaletFiyat
    {
        public int PaletId { get; set; }
        public decimal PaletGenelToplam { get; set; }
    }


    public class CariSiparisMiktarlari
    {
        public string CariKod { get; set; }
        public string IlgiliId { get; set; }
        public int Miktar_Kg { get; set; }
        public string SiparisKod { get; set; }
        public decimal GenelToplamTutar { get; set; }
        public string DovizTipKod { get; set; }
    }


    public class SiparisRepository :RepositoryAsync<Siparis>
    {
        public SiparisRepository(PandapContext dc) : base(dc)
        {
        }

        public int SiparisSil(string siparisKod)
        {
            var u = _dc.SiparisKalemleri.FirstOrDefault(c => c.SiparisKod == siparisKod);
            _dc.SiparisKalemleri.Remove(u);

            try
            {
                _dc.SaveChanges();
                return 1;
            }
            catch (Exception)
            {
                return 0;
            }
        }


        public void SiparisPaketlenenToplamGuncelle(string siparisKod, int toplamPaketMiktari)
        {
            var siparis = _dc.Siparisler.Find(siparisKod);

            //siparis.PaketlenenMiktarKg = toplamPaketMiktari;

            _dc.SaveChanges();
        }

        public void Remove(SiparisDTO seciliSiparisDto)
        {
            var s = _dc.Siparisler.Find(seciliSiparisDto.SiparisKod);
            _dc.Siparisler.Remove(s);
            var kalemler = _dc.SiparisKalemleri.Where(p => p.SiparisKod == seciliSiparisDto.SiparisKod).ToList() ;
            _dc.SiparisKalemleri.RemoveRange(kalemler);

            _dc.SaveChanges();
        }

        public void LmeBaglamaEkle(LmeBaglama obj)
        {
            _dc.LmeBaglamas.Add(obj);
        }

        public void LmeBaglamaSil(LmeBaglama obj)
        {
            _dc.LmeBaglamas.Remove(obj);
        }

        public List<SatisRapor> SiparisRaporGetir()
        {
            return Enumerable.ToList<SatisRapor>(_dc.SatisRapor.AsNoTracking());
        }

        public Siparis SiparisGetirFull(string siparisKod)
        {
            var v = _dc.Siparisler
                    .Include(c => c.CariKartNavigation)
                    .Include(c => c.OdemeTipKodNavigation)
                    .Include(c => c.TeslimTipKodNavigation)
                    .Include(c => c.TakipDovizTipKodNavigation)
                    .Include(c => c.SiparisKalemleri)
                    //.Include(c => c.SiparisKalemleri).ThenInclude(c => c.AlasimTipKodNavigation)
                    //.Include(c => c.SiparisKalemleri).ThenInclude(c => c.SertlikTipKodNavigation)
                    //.Include(c => c.SiparisKalemleri).ThenInclude(c => c.MasuraTipKodNavigation)
                    //.Include(c => c.SiparisKalemleri).ThenInclude(c => c.YuzeyTipKodNavigation)
                    //.Include(c => c.SiparisKalemleri).ThenInclude(c => c.KullanimAlanTipKodNavigation)
                    //.Include(c => c.SiparisKalemleri).ThenInclude(c => c.LmeTipKodNavigation)
                    //.Include(c => c.SiparisKalemleri).ThenInclude(c => c.AmbalajTipKodNavigation)
                    .Where(c => c.SiparisKod == siparisKod)
                    .FirstOrDefault();

            return v;
        }
        
        public void UpdateSiparisKalemKapasitifDurum()
        {
            var updateSql = "UPDATE Satis.SiparisKalem SET KapasitifMi = a.KapasitifMi FROM Satis.Siparis AS a INNER JOIN  " +
                "Satis.SiparisKalem ON a.SiparisKod = Satis.SiparisKalem.SiparisKod WHERE(a.KapasitifMi = 1)";

            _dc.Database.ExecuteSqlCommand(updateSql);
        }

        public void LmeSurecDurumDegistir(string yenisurecDurum, string refNo)
        {

            var x = _dc.LmeBaglamas.Where(c => c.RefNo == refNo).FirstOrDefault();

            x.LmeKayitSurecDurumOnceki = x.LmeKayitSurecDurum;
            x.LmeKayitSurecDurum = yenisurecDurum;

            x.LmeKayitSurecDurumIslemTarih = DateTime.Now;

            _dc.SaveChanges();


        }

        public Siparis SiparisGetir(string siparisKod)
        {
            var v = _dc.Siparisler
                    .Include(c => c.SiparisKalemleri)
                    .Include(c => c.CariKartNavigation)
                    .Where(c => c.SiparisKod == siparisKod)
                    .FirstOrDefault();
            return v;
        }

        public Siparis SiparisGetirUst(string siparisKod)
        {
            var v = _dc.Siparisler
                    .Where(c => c.SiparisKod == siparisKod)
                    .FirstOrDefault();
            return v;
        }

        public Siparis SiparisGetirIrsaliyeIcin(string siparisKod)
        {
            var v = _dc.Siparisler
                    .Include(c => c.SiparisKalemleri)
                    .Include(c => c.CariKartNavigation)
                    .Include(c => c.CariEmailNavigation)
                    .Include(c => c.SatisTipKodNavigation)
                    .Include(c => c.TeslimTipKodNavigation)
                    .Include(c => c.OdemeTipKodNavigation)
                    .Include(c => c.FaturaDovizTipKodNavigation)
                    .Include(c => c.TakipDovizTipKodNavigation)
                    .Include(c => c.OdemeBankaKodNavigation)

                    .Where(c => c.SiparisKod == siparisKod)
                    .FirstOrDefault();
            return v;
        }

        public Siparis SiparisGetirPure(string siparisKod)
        {
            var v = _dc.Siparisler
                    .Include(c => c.SiparisKalemleri)
                    .Where(c => c.SiparisKod == siparisKod)
                    .FirstOrDefault();
            return v;
        }
        
        public void SiparisSurecDurumDegistir(SiparisDTO dto, string surecDurum, string surecDurumOnceki = "")
        {
            var x = _dc.Siparisler.Where(c => c.SiparisKod == dto.SiparisKod).FirstOrDefault();

            x.SiparisSurecDurum = surecDurum;
            x.SiparisSurecDurumOnceki = surecDurumOnceki;
            x.SiparisSurecDurumIslemTarih = DateTime.Now;

            _dc.SaveChanges();
        }

        public ObservableCollection<CariKart> NetsistenCariKartlariGetir(string[] plasiyerKodlar)
        {
            return _dc.CariKartlar.Where(c => plasiyerKodlar.Contains(c.PlasiyerKod)).AsNoTracking().ToObservableCollection();
        }

        public ObservableCollection<CariKart> NetsistenCariKartlariGetir()
        {
            return _dc.CariKartlar.AsNoTracking().ToObservableCollection();
        }

        public string YeniBelgeNoGetirYildan()
        {
            var aktif_YilSon2 = DateTime.Today.Year.ToString().Substring(2);

            var yeniSayi = "";

            var sonkayit = _dc.Siparisler
                            .Where(c => c.SiparisKod.Contains("P" + aktif_YilSon2 + "-"))
                            .OrderByDescending(c => c.SiparisKod)
                            .AsNoTracking()
                            .FirstOrDefault();


            if (sonkayit == null) return "P" + aktif_YilSon2 + "-1000";

            var listKod = sonkayit.SiparisKod.Split('-');

            if (listKod.Length == 2 && listKod[0].Substring(1) == aktif_YilSon2)
            {
                yeniSayi = listKod[0] + "-" + (int.Parse(listKod[1]) + 1).ToString();
            }

            if (listKod.Length == 2 && listKod[0].Substring(1) != aktif_YilSon2)
            {
                yeniSayi = (listKod[0] + 1).ToString() + "-1";
            }

            if (listKod.Length == 1)
            {
                yeniSayi = "P" + aktif_YilSon2 + "-1";
            }

            return yeniSayi;
        }

        public Dictionary<string, int> SiparisIstatistikSayilariGetir(string[] kullanicilar = null)
        {
            if (kullanicilar[0] == "Tümü")
            {
                var sonuc = _dc.Siparisler
                   .Where(c => c.SiparisAcikMi == true)
                   .GroupBy(c => c.SiparisSurecDurum)
                   .Select(s => new SqlGrupSayi
                   {
                       GrupAd = s.Key,
                       GrupSayı = s.Count()
                   });
                return sonuc.ToDictionary(c => c.GrupAd, c => c.GrupSayı);
            }

            if (kullanicilar != null)
            {
                var sonuc = _dc.Siparisler
                    .Where(c => kullanicilar.Contains(c.CreatedUserId))
                    .Where(c => c.SiparisAcikMi == true)
                    .GroupBy(c => c.SiparisSurecDurum)
                    .Select(s => new SqlGrupSayi
                    {
                        GrupAd = s.Key,
                        GrupSayı = s.Count()
                    }).ToList();

                return sonuc.ToDictionary(c => c.GrupAd, c => c.GrupSayı); ;
            }

            return null;
        }

        public int TemsilciSiparisSayisiGetir(string[] kullanicilar)
        {
            // eski halinde takılma oldu sorunu bul

            PandapContext dcx = new PandapContext();
            var x = dcx.Siparisler
                .Where(c => c.SiparisAcikMi == true)
                .Include(c => c.CariKartNavigation)
                .Where(c => kullanicilar.Contains(c.CreatedUserId) || kullanicilar.Contains(c.CariKartNavigation.PlasiyerKod)).Count();

            dcx.Dispose();

            return x;
        }

        public ObservableCollection<LmeBaglama> LmeBaglamaListeGetir(string mesajKullaniciId)
        {
            var kul = _dc.Kullanicilar.Where(c => c.KullaniciId == mesajKullaniciId).FirstOrDefault();



            var lmeListeQuery = _dc.LmeBaglamas
                   .Include(c => c.PandapCari)
                   .Select(c=>c);


            if (kul.BagliKullanicilar != "Tümü")
            {
                lmeListeQuery = lmeListeQuery
                .Where(c => kul.BagliNetsisPlasiyerKodlari.Contains(c.PandapCari.PlasiyerKod));
            };
               
            var lmeListe=lmeListeQuery.ToList();


            //var siparisKalemLmeDtoListe = (from c in _dc.LmeBaglamas
            //                         join k in _dc.SiparisKalemleri
            //                         on c.RefNo equals k.LmeBaglamaKod
            //                         where k.KapasitifMi != true
            //                         select new SiparisKalemLmeDto
            //                         {
            //                             LmeBaglamaKod = k.LmeBaglamaKod,
            //                             SiparisKod = k.SiparisKod,
            //                             SiparisKalemKod = k.SiparisKalemKod,
            //                             Miktar_kg = k.Miktar_kg.GetValueOrDefault()
            //                         }).AsNoTracking().ToList();



            //foreach (var item in lmeListe)
            //{
            //    item.SiparisKalemLmeDtoListe = siparisKalemLmeDtoListe.Where(c => c.LmeBaglamaKod == item.RefNo).ToList();
            //}


            var sonuc = lmeListe.ToObservableCollection();
            return sonuc;

        }


        public Dictionary<string, int> LmeBaglamaFaturaAsimListeGetir()
        {
            //var sonuc = _dc.UretimPaletler
            //            .Include(c => c.Bobinler)
            //            .Include(c => c.UretimEmriKodNav)
            //             .Include(c => c.UretimEmriKodNav).ThenInclude(c => c.SiparisKalemKodNav)
            //            .Where(c => c.UretimEmriKodNav.SiparisKalemKodNav.LmeBaglamaKod != null)
            //            .Select(c => new SqlGrupSayi
            //            {
            //                GrupAd = c.UretimEmriKodNav.SiparisKalemKodNav.LmeBaglamaKod,
            //                GrupSayı = c.Bobinler.Sum(b => b.Agirlik_kg).GetValueOrDefault()
            //            })
            //            .ToList()
            //            .GroupBy(c => c.GrupAd)
            //            .Select(s => new SqlGrupSayi
            //            {
            //                GrupAd = s.Key,
            //                GrupSayı = s.Sum(c => c.GrupSayı)
            //            });



            //return sonuc.ToDictionary(c => c.GrupAd, c => c.GrupSayı);
            return new Dictionary<string, int>();

        }


        public Dictionary<string, int> LmeSurecSayilariGetir(string[] kullanicilar = null)
        {
            var dc1 = new PandapContext();
            var sonuc = dc1.LmeBaglamas
                .GroupBy(c => c.LmeKayitSurecDurum).Select(s => new SqlGrupSayi
                {
                    GrupAd = s.Key,
                    GrupSayı = s.Count()
                });
            return sonuc.ToDictionary(c => c.GrupAd, c => c.GrupSayı);

        }


        public LmeBaglama LmeBaglamaGetir(Guid rowGuid)
        {
            return _dc.LmeBaglamas.Where(c => c.RowGuid == rowGuid).FirstOrDefault();
        }

        public LmeBaglama LmeBaglamaGetir(string lmeKod)
        {
            return _dc.LmeBaglamas.Where(c => c.RefNo == lmeKod).FirstOrDefault();
        }

        //public ObservableCollection<LmeBaglama> CariLmeBaglamaListeGetir(string cariKod)
        //{
            //var sonuc = _dc.LmeBaglamas
            //       .Include(c => c.SiparisKalemleri)
            //       .Where(c => c.MusteriKod == cariKod && c.SiparisLfx_Bakiye_kg != 0)
            //       .OrderBy(c => c.RefNo)
            //       .ToObservableCollection();

            //return sonuc;
        //}

        public void SiparisEkle(Siparis seciliSiparis)
        {
            _dc.Siparisler.Add(seciliSiparis);
        }


        public ObservableCollection<LmeGunluk> LmeGunlukListeGetir()
        {
            return _dc.LmeGunluks.ToObservableCollection();
        }



        public void LmeGunlukEkle(LmeGunluk lmeGunluk)
        {
            _dc.LmeGunluks.Add(lmeGunluk);
        }



        public LmeBaglama SonLmeKaydiGetir()
        {
            return _dc.LmeBaglamas.OrderByDescending(c => c.RefNo).FirstOrDefault();
        }



        public ObservableCollection<LmeOrtalamaVeri> LmeOrtalamalariGetir()
        {
            var s = _dc.LmeOrtalamaVeriler.ToObservableCollection();
            return s;
        }

        public string[] AyniFirmaSiparisNolariGetir(string siparisKod, string firmaSiparisNo)
        {
            return _dc.Siparisler
                    .Where(c => c.FirmaSiparisNo == firmaSiparisNo && c.SiparisKod != siparisKod)
                    .Select(c => c.SiparisKod)
                    .ToArray();
        }

        public string SonKayitNoGetir()
        {
            var sonKayitNo = _dc.Siparisler.OrderByDescending(c => c.SiparisKod).FirstOrDefault()?.SiparisKod;

            return sonKayitNo;
        }

    }
}
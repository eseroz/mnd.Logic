using Microsoft.EntityFrameworkCore;
using mnd.Logic.Helper;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using mnd.Logic.BC_Satis.Data;
using mnd.Logic.Services._DTOs;

namespace mnd.Logic.BC_Satis._Teklif
{
    public class TeklifRepository
    {
        _SatisDbContext dc;
        public TeklifRepository()
        {
            dc = new _SatisDbContext();
        }

        public Teklif TeklifGetir(string teklifSiraKod)
        {
           var teklif= dc.Teklifler
                .Include(c=>c.TeklifKalemler)
                .FirstOrDefault(c => c.TeklifSiraKod==teklifSiraKod);

            return teklif;

        }


        public void TeklifDurumDegistir(string teklifSiraKod,string teklifDurum, string islemNot,string retNeden)
        {
            _SatisDbContext dc1=new _SatisDbContext();

            var teklif = dc1.Teklifler
                 .FirstOrDefault(c => c.TeklifSiraKod == teklifSiraKod);

            teklif.TeklifDurum = teklifDurum;
            teklif.IslemNot = islemNot;
            teklif.RetNeden = retNeden;

            dc1.SaveChanges();

        }
        public void TeklifDurumGuncelle(string _teklifSiraKod, string teklifDurum)
        {
            _SatisDbContext dc1 = new _SatisDbContext();

            var teklif = dc1.Teklifler
                 .FirstOrDefault(c => c.TeklifSiraKod == _teklifSiraKod);

            teklif.TeklifDurum = teklifDurum;


            dc1.SaveChanges();

        }
        public string Kaydet()
        {
            try
            {
                dc.SaveChanges();
                return "Kaydedildi.";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
           
        }

        public ObservableCollection<Teklif> TeklifleriGetir(string plasiyerKod)
        {
            var teklifler = dc.Teklifler
                .ToObservableCollection();

            return teklifler;

        }

       

        public IQueryable<Teklif> TeklifQuery()
        {
            var teklifler = dc.Teklifler
                .Include(c=>c.MusteriNav)
                .AsNoTracking().AsQueryable();
                

            return teklifler;

        }

        public IQueryable<Teklif> TeklifPotansiyelQuery()
        {
            var teklifler = dc.Teklifler
                .AsNoTracking()
                .AsQueryable();


            return teklifler;

        }

        public Dictionary<string, int> TeklifSurecSayilariGetir(string[] bagliPlasiyerKodListe)
        {
            var dc1 = new _SatisDbContext();
            var sonuc = dc1.Teklifler
                .Include(c=>c.MusteriNav)
                .Where(c=> bagliPlasiyerKodListe.Contains(c.MusteriNav.PlasiyerKod) 
                || bagliPlasiyerKodListe.Contains(c.PlasiyerKod))
                .GroupBy(c => c.TeklifDurum).Select(s => new SqlGrupSayi
                {
                    GrupAd = s.Key,
                    GrupSayı = s.Count()
                });
            return sonuc.ToDictionary(c => c.GrupAd, c => c.GrupSayı);
        }



        public void TeklifEkle(Teklif seciliTeklif)
        {
            dc.Teklifler.Add(seciliTeklif);
        }


        public string SonKayitNoGetir()
        {
            var dc1=  new _SatisDbContext();

            var sonKayitNo=dc1.Teklifler.OrderByDescending(c => c.TeklifSiraKod).FirstOrDefault()?.TeklifSiraKod;

            return sonKayitNo;
        }

        public string SiparisSonKayitNoGetir()
        {
            var dc1 = new _SatisDbContext();

            var sonKayitNo = dc1.Siparisler.OrderByDescending(c => c.SiparisKod).FirstOrDefault()?.SiparisKod;

            return sonKayitNo;
        }

        public int PlasiyerBazliAktifGunTeklifSayisi(string plasiyerKod)
        {
            var dc1 = new _SatisDbContext();

            var gunlukKayitSayisi = dc1.Teklifler
                .Include(c => c.MusteriNav)
                .Where(c => c.MusteriNav.PlasiyerKod == plasiyerKod)
                .Where(c => c.TeklifTarih.Date == DateTime.Now.Date)
                .Count();

            return gunlukKayitSayisi;
        }


    }
}

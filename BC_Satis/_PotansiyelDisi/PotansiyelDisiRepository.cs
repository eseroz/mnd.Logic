using Microsoft.EntityFrameworkCore;
using mnd.Logic.Helper;
using mnd.Logic.Persistence;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mnd.Logic.BC_Satis._PotansiyelDisi
{
    public class PotansiyelDisiRepository
    {
        PotansiyelDisiDbContext dc;
        public PotansiyelDisiRepository()
        {
            dc = new PotansiyelDisiDbContext();
        }

        public ObservableCollection<PotansiyelMusteriDTO> PTD_Aramalari_Getir(string[] plasiyerKodlari, string MusteriGrubuAdı)
        {
            dc = new PotansiyelDisiDbContext();
            var musteriler = dc.PostansiyelDisiMusteriAramas
                .Where(c => plasiyerKodlari.Any(x => x.ToString() == c.PlasiyerKod) && c.MusteriGrubuAdı == MusteriGrubuAdı).OrderBy(o=>o.MusteriUnvan)
                .Select(i => i.MusteriUnvan).Distinct().ToList();

            List<PotansiyelMusteriDTO> musterilerListesi = new List<PotansiyelMusteriDTO>();
            List<PotansiyelMusteriDTO> potansiyel = new List<PotansiyelMusteriDTO>();
            foreach (var musteriUnvan in musteriler)
            {
                var sonucMusteri = new PotansiyelMusteriDTO
                { 
                      MusteriUnvan = musteriUnvan,
                      MusteriGrubuAdı=MusteriGrubuAdı
                }; 

                sonucMusteri.MusteriAramalarDTO = dc.PostansiyelDisiMusteriAramas.Where(l => l.MusteriUnvan == sonucMusteri.MusteriUnvan).OrderByDescending(o=>o.Tarih).ToList();
               
                var sonKayit = sonucMusteri.MusteriAramalarDTO.FirstOrDefault();
 
                TimeSpan ?gun = (sonKayit.Tarih - DateTime.Now);
                int yeniGun = 0;

                if (gun.Value.TotalDays < 0) { yeniGun = (int)gun.Value.TotalDays * -1; }
                sonucMusteri.SonGorusmeSuresi = yeniGun.ToString();

                sonucMusteri.Id = sonucMusteri.MusteriAramalarDTO.FirstOrDefault().Id;
                sonucMusteri.UlkeAdi = sonucMusteri.MusteriAramalarDTO.FirstOrDefault()?.UlkeAdi;
                
                var ulke = dc.UlkeSabits.Where(p => p.UlkeAdi == sonucMusteri.UlkeAdi).FirstOrDefault();
                sonucMusteri.UlkeKodu = ulke.UlkeKodu;

                UnitOfWork uow = new UnitOfWork();

                var ekleyenPlasiyer = uow.PlasiyerRepo.getPlasiyer(sonucMusteri.MusteriAramalarDTO.FirstOrDefault()?.Ekleyen);
                uow.Dispose();
                sonucMusteri.Plasiyer = ekleyenPlasiyer.AdSoyad;
                potansiyel.Add(sonucMusteri);

            }               

            return potansiyel.ToObservableCollection();

        }

        public void Kaydet()
        {
            dc.SaveChanges();
        }

        public void Ekle(PotansiyelDisiMusteriArama ptd_Arama)
        {
            dc.PostansiyelDisiMusteriAramas.Add(ptd_Arama);
        }

        public PotansiyelDisiMusteriArama Ptd_AramaGetirNoTrack(int id)
        {
            var ptd_Aramalar = dc.PostansiyelDisiMusteriAramas
                .Where(c => c.Id == id)
                .AsNoTracking()
                .FirstOrDefault();

            return ptd_Aramalar;
        }

        public PotansiyelDisiMusteriArama Ptd_AramaGetir(int id)
        {
            var ptd_Aramalar = dc.PostansiyelDisiMusteriAramas
                .Where(c => c.Id == id).FirstOrDefault();

            return ptd_Aramalar;
        }

        public List<P_UlkeSabit> UlkeleriGetir()
        {
            return dc.UlkeSabits
                .OrderBy(c=>c.UlkeAdi)
                .AsNoTracking().ToList();
        }


    }
}
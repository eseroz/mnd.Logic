using Microsoft.EntityFrameworkCore;
using mnd.Logic.Helper;
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
                .Where(c => plasiyerKodlari.Any(x => x.ToString() == c.PlasiyerKod) && c.MusteriGrubuAdı == MusteriGrubuAdı)
                .Select(i => i.MusteriUnvan).Distinct().ToList();

            List<PotansiyelMusteriDTO> potansiyel = new List<PotansiyelMusteriDTO>();
            foreach (var musteri in musteriler)
            {
             
                var sonucMusteri = new PotansiyelMusteriDTO { MusteriUnvan = musteri.ToString() };

                sonucMusteri.MusteriAramalarDTO = dc.PostansiyelDisiMusteriAramas.Where(l => l.MusteriUnvan == sonucMusteri.MusteriUnvan).ToList();
                sonucMusteri.Id = sonucMusteri.MusteriAramalarDTO.FirstOrDefault().Id;
                sonucMusteri.UlkeAdi = sonucMusteri.MusteriAramalarDTO.FirstOrDefault()?.UlkeAdi;
                
                var ulke = dc.UlkeSabits.Where(p => p.UlkeAdi == sonucMusteri.UlkeAdi).FirstOrDefault();
                sonucMusteri.UlkeKodu = ulke.UlkeKodu;
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
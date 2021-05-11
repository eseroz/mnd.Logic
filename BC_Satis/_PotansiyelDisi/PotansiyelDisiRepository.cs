using Microsoft.EntityFrameworkCore;
using mnd.Logic.Helper;
using mnd.Logic.Persistence;
using Pandap.Logic.Persistence.Repositories;
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

        public ObservableCollection<PotansiyelDisiMusteri> PTD_Aramalari_Getir(string[] plasiyerKodlari, string MusteriGrubuAdı)
        {  
            var musteriler = dc.PostansiyelDisiMusteris
                .Include(x=>x.PotansiyelDisiMusteriArama)
                .Where(c => plasiyerKodlari.Any(x => x.ToString() == c.PlasiyerKod) && c.MusteriGrubuAdi == MusteriGrubuAdı)
                .OrderBy(o=>o.MusteriUnvan).ToObservableCollection();

            return musteriler;
        }

        public void Kaydet()
        {
            dc.SaveChanges();
        }

        public void Dispose()
        {
            dc.Dispose();
        }


        public void AramaEkle(PotansiyelDisiMusteriArama ptd_Arama)
        {
            dc.PostansiyelDisiMusteriAramas.Add(ptd_Arama);
           
        }
        public void MusteriEkle(PotansiyelDisiMusteri ptd_Musteri)
        {
            dc.PostansiyelDisiMusteris.Add(ptd_Musteri);
        }
        public PotansiyelDisiMusteriArama Ptd_AramaGetirNoTrack(int id)
        {
            var ptd_Aramalar = dc.PostansiyelDisiMusteriAramas
                .Where(c => c.Id == id)
                .AsNoTracking()
                .FirstOrDefault();

            return ptd_Aramalar;
        }
        public PotansiyelDisiMusteriArama Ptd_SonAramaGetir(int musteriId)
        {
            var _dc = new PotansiyelDisiDbContext();
            var ptd_Aramalar = _dc.PostansiyelDisiMusteriAramas
                .Where(c => c.PotansiyelDisiMusteriId == musteriId)
                .AsNoTracking()
                .LastOrDefault();
            _dc.Dispose();
            return ptd_Aramalar;
        }
        public PotansiyelDisiMusteriArama Ptd_AramaGetir(int id)
        {
            var _dc = new PotansiyelDisiDbContext();
            var ptd_Aramalar = _dc.PostansiyelDisiMusteriAramas
                .Where(c => c.Id == id).FirstOrDefault();
            _dc.Dispose();
            return ptd_Aramalar;
        }

        public List<P_UlkeSabit> UlkeleriGetir()
        {
            var _dc = new PotansiyelDisiDbContext();
            var ulkeler = _dc.UlkeSabits
                .OrderBy(c=>c.UlkeAdi)
                .AsNoTracking().ToList();
            _dc.Dispose();
            return ulkeler;
        }


        public PotansiyelDisiMusteri getMusteri(int musteriId)
        {
            var musteri = dc.PostansiyelDisiMusteris.Where(p => p.Id == musteriId).FirstOrDefault();
            return musteri;
        }
        public P_UlkeSabit getUlke(string ulkeKodu)
        {
            var ulke = dc.UlkeSabits.Where(p => p.UlkeKodu == ulkeKodu).FirstOrDefault();
            return ulke;
        }


        public bool DegisiklikVarMi() {
            return dc.ChangeTracker.HasChanges();
        }
    }
}
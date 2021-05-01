﻿using Microsoft.EntityFrameworkCore;
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

        public void AramaEkle(PotansiyelDisiMusteri musteri, PotansiyelDisiMusteriArama ptd_Arama)
        {

            var dbMusteri = dc.PostansiyelDisiMusteris.FirstOrDefault(p => p.Id == musteri.Id);
            dbMusteri.PotansiyelDisiMusteriArama.Add(ptd_Arama);
           
        }
        public void MusteriEkle(PotansiyelDisiMusteri ptd_Musteri)
        {
            dc = new PotansiyelDisiDbContext();
            dc.PostansiyelDisiMusteris.Add(ptd_Musteri);
            dc.SaveChanges();
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
            var _dc = new PotansiyelDisiDbContext();
            var musteri = _dc.PostansiyelDisiMusteris.Where(p => p.Id == musteriId).FirstOrDefault();
            _dc.Dispose();
            return musteri;
        }

    }
}
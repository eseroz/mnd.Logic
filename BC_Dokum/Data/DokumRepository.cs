using Microsoft.EntityFrameworkCore;
using mnd.Common.Helpers;
using mnd.Logic.BC_Dokum.Model;
using mnd.Logic.Helper;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mnd.Logic.BC_Dokum.Data
{
    public class DokumRepository
    {
        public ObservableCollection<DokumBobin> DokumKafileListeGetir(string dokumHatti,int yil)
        {
            var dc = new DokumDbContext();
            var liste = dc.DokumBobinleri
                .Include(c=>c.DokumBobinIslemAdimlari)
                .Where(c => c.DokumHattiKod == dokumHatti)
                .Where(c=>c.PlanTarihi.GetValueOrDefault().Year==yil)
                .AsNoTracking()
                .ToObservableCollection();
            return liste;
        }

      

        public ObservableCollection<DokumBobin> DokumKafileBekleyenListeGetir(string dokumHatti, int yil)
        {
            var dc = new DokumDbContext();
            var liste = dc.DokumBobinleri
                 .Include(c => c.DokumBobinIslemAdimlari)
                .Where(c=>c.ReelBitisTarihi==null)
                .Where(c => c.DokumHattiKod == dokumHatti)
                .Where(c => c.PlanTarihi.GetValueOrDefault().Year == yil)
                .AsNoTracking()
                .ToObservableCollection();
            return liste;
        }

        public ObservableCollection<DokumBobin> DokumBobinBitisDepoGetir()
        {
            var dc = new DokumDbContext();
            var liste = dc.DokumBobinleri
                .Include(c=>c.DokumBobinIslemAdimlari)
                .Where(c => c.BobinKonum==BOBIN_KONUM.DH_BITIS_DEPO && c.ReelBitisTarihi!=null)
                .AsNoTracking()
                .ToObservableCollection();
            return liste;
        }

        public ObservableCollection<DokumBobin> DokumBobinTumuGetir()
        {
            var dc = new DokumDbContext();
            var liste = dc.DokumBobinleri
                .Include(c => c.DokumBobinIslemAdimlari)
                .AsNoTracking()
                .ToObservableCollection();
            return liste;
        }

        public ObservableCollection<DokumBobin> LtfOnDepoGetir()
        {
            var dc = new DokumDbContext();
            var liste = dc.DokumBobinleri
                .Include(c => c.DokumBobinIslemAdimlari)
                .Where(c => c.Nereye == "LTF" && c.ReelBitisTarihi != null)
                .AsNoTracking()
                .ToObservableCollection();
            return liste;
        }


        public ObservableCollection<DokumBobin> LtfBitisDepoGetir()
        {
            var dc = new DokumDbContext();
            var liste = dc.DokumBobinleri
                .Include(c=>c.DokumBobinIslemAdimlari)
                .Where(c => c.BobinKonum == BOBIN_KONUM.LTF_SON_DEPO && c.ReelBitisTarihi!=null)
                .AsNoTracking()
                .ToObservableCollection();
            return liste;
        }

        public ObservableCollection<DokumBobin> ShOnDepoGetir()
        {
            var dc = new DokumDbContext();
            var liste = dc.DokumBobinleri
                .Include(c => c.DokumBobinIslemAdimlari)
                .Where(c => c.Nereye=="SH" && c.ReelBitisTarihi!=null)
                .AsNoTracking()
                .ToObservableCollection();

       
            return liste;
        }

        public ObservableCollection<DokumBobin> DhOnDepoGetir()
        {
            var dc = new DokumDbContext();
            var liste = dc.DokumBobinleri
                .Include(c => c.DokumBobinIslemAdimlari)
                .Where(c => c.DokumHattiKod.Contains("DH") && c.ReelBitisTarihi == null)
                .AsNoTracking()
                .ToObservableCollection();
            return liste;
        }



        public ObservableCollection<DokumBobin> ShSonDepoGetir()
        {
            var dc = new DokumDbContext();
            var liste = dc.DokumBobinleri
                .Include(c => c.DokumBobinIslemAdimlari)
                .Where(c => c.BobinKonum == BOBIN_KONUM.SH_SON_DEPO && c.ReelBitisTarihi!=null)
                .AsNoTracking()
                .ToObservableCollection();

         


            return liste;
        }

      

        public void DokumEkle(DokumBobin yeniDokum)
        {
            var dc = new DokumDbContext();
            dc.DokumBobinleri.Add(yeniDokum);
            dc.SaveChanges();
        }


        public void DokumGuncelle(DokumBobin dokum)
        {
            var dc = new DokumDbContext();
            var dkm = dc.DokumBobinleri.Find(dokum.Id);
            dc.Entry(dkm).CurrentValues.SetValues(dokum);
          
            dc.SaveChanges();
        }

        public DokumBobin DokumBobinGetir(string aramaMetin)
        {
            var dc = new DokumDbContext();
            var dkm = dc.DokumBobinleri
                .Include(c=>c.DokumBobinIslemAdimlari)
                .Where(c => c.PlanBobinNo.ToString() == aramaMetin).FirstOrDefault();

            return dkm;
           
        }

        public void DokumKafileShKartNoGuncelle(List<int> dokumBobinNumaralari, string kartNo)
        {
            var dc = new DokumDbContext();

            var liste = dc.DokumBobinleri.Where(c => dokumBobinNumaralari.Contains(c.PlanBobinNo.GetValueOrDefault()));

            foreach (var item in liste)
            {
                item.ShKafileNo = kartNo;
            }


            dc.SaveChanges();
        }

        public ObservableCollection<DokumBobin> DokumKafileListeGetirTarihdenKucukVeAktif(string dokumHatti, DateTime seciliTarih)
        {
            var dc = new DokumDbContext();
            var liste = dc.DokumBobinleri.Where(c => c.DokumHattiKod == dokumHatti)
                .Where(c=>c.ReelBitisTarihi==null)
                .Where(c => c.PlanTarihi.GetValueOrDefault().Date <= seciliTarih)
                .AsNoTracking()
                .ToObservableCollection();
            return liste;
        }
    }


    public class DokumTrackingRepository
    {

        DokumDbContext dc = new DokumDbContext();


        public void DokumEkle(DokumBobin yeniDokum)
        {
            
            dc.DokumBobinleri.Add(yeniDokum);
            dc.SaveChanges();
        }


        public DokumBobin DokumBobinGetir(string aramaMetin)
        {
            var dkm = dc.DokumBobinleri
                .Include(c => c.DokumBobinIslemAdimlari)
                .Where(c => c.PlanBobinNo.ToString() == aramaMetin).FirstOrDefault();

            return dkm;

        }

        public void BobinIzle(DokumBobin bobin)
        {
            dc.DokumBobinleri.Attach(bobin);
        }

        public void BobinIzlemeyiBirak(DokumBobin bobin)
        {
            dc.Entry(bobin).State = EntityState.Unchanged;
        }

        public void Kaydet()
        {
            dc.SaveChanges();
        }

        public ObservableCollection<DokumBobin> DokumBobinListeGetirFromKonum(string dokumBobinKonum)
        {

            var dkm = dc.DokumBobinleri
                .Include(c => c.DokumBobinIslemAdimlari)
                .Where(c => c.BobinKonum == dokumBobinKonum)
                .AsNoTracking()
                .ToObservableCollection();

            return dkm;
        }
    }
}

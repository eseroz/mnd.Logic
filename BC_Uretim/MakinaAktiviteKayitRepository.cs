using Microsoft.EntityFrameworkCore;
using mnd.Common.Helpers;
using mnd.Logic.Helper;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mnd.Logic.BC_Uretim
{
    public class MakinaAktiviteKayitRepository
    {
        private UretimDbContext dc = new UretimDbContext();


        public ObservableCollection<MakinaAktiviteKayit> MakinaDurusHareketleriGetir()
        {
            var sonuc = dc.MakinaAktiviteKayits.ToList();

            return sonuc.ToObservableCollection();
        }

        public void MakinaAktiviteEkle(MakinaAktiviteKayit makinaAktivite)
        {
            dc.MakinaAktiviteKayits.Add(makinaAktivite);
          
        }

        public ObservableCollection<MakinaAktiviteKayit> MakinaDurusHareketleriGetirRunSonrasi(string makinaKisaAd)
        {
            var sonRun = dc.MakinaAktiviteKayits.OrderByDescending(c => c.Id)
                .Where(c => c.DuruşKodu == "1000" && c.MakinaKisaAd==makinaKisaAd)
                .FirstOrDefault();


            if (sonRun == null) return new ObservableCollection<MakinaAktiviteKayit>();


            var sonuc = dc.MakinaAktiviteKayits
                      .Where(c => c.Id>=sonRun.Id)
                      .ToObservableCollection();

            return sonuc;
        }


        public Task<List<MakinaAktiviteKayit>> UretimTabloGetirTarihAraligiAsync(DateTime baslamaTarih, DateTime bitisTarih, string makinaKod)
        {
            var result = dc.MakinaAktiviteKayits
                  .Where(c => c.Tarih >= baslamaTarih && c.Tarih <= bitisTarih)
                  .Where(c => c.MakinaKisaAd == makinaKod)
                  .AsNoTracking()
                  .ToListAsync();

            return result;
        }

        public List<MakinaAktiviteKayit> UretimTabloGetirTumu()
        {
            var result = dc.MakinaAktiviteKayits
                  .AsNoTracking()
                  .ToList();

            return result;
        }


        public void Kaydet()
        {
            dc.SaveChanges();
        }

        public MakinaAktiviteKayit CalisilanBobinAktiviteGetir(string makinaKod)
        {
            var sonRun = dc.MakinaAktiviteKayits.OrderByDescending(c => c.Id)
                .Where(c=>c.AktiviteDurum== BOBIN_ISLEMADIM_DURUM.ÇALIŞIYOR)
                .Where(c => c.MakinaKisaAd == makinaKod)
                .FirstOrDefault();

            return sonRun;
        }

        public MakinaAktiviteKayit SonRunGetir(string makinaKod)
        {
            var sonRun = dc.MakinaAktiviteKayits.OrderByDescending(c => c.Id)
                .Where(c => c.DuruşKodu == "1000")
                .Where(c=>c.MakinaKisaAd==makinaKod)
                .FirstOrDefault();

            return sonRun;
        }
    }
}

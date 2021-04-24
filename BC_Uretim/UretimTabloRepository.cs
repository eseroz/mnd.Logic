using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mnd.Logic.BC_Uretim
{
    public class UretimTabloRepository
    {
        private UretimDbContext dc = new UretimDbContext();

        public List<Uretim_UretimTablo> UretimTabloGetir()
        {
            var result = dc.UretimTablo
                .ToList();

            return result;
        }

        public List<Uretim_UretimTablo> UretimTabloGetir(DateTime tarih, string vardiya, int makinaKod)
        {
            var result = dc.UretimTablo
                .Where(c => c.Tarih == tarih)
                .Where(c => c.Vardiya == vardiya)
                .Where(c => c.MakinaKod == makinaKod)
                .ToList();

            return result;
        }

        public Dictionary<string, MakinaDurusTanim> MakinaDuruslariGetir()
        {
            var result = dc.MakinaDurusTanimlar
                .AsNoTracking()
                .ToDictionary(c => c.DurusKod);
            return result;
        }

        public void Kaydet()
        {
            //track edilmeyen nav propertiler (disconnected) state added olarak işaretlenir.
            //Bunu engellemek için deattach ile track dan çıkarıyoruz

            var trackMakinaDuruslar = dc.ChangeTracker.Entries<MakinaDurusTanim>().ToList();
            var trackMakinaTablo = dc.ChangeTracker.Entries<Uretim_UretimTablo>().ToList();

            foreach (var item in trackMakinaTablo) { var x = item.State; };

            try
            {
                dc.SaveChanges();
            }
            catch (Exception ex)
            {
                var c = ex;
            }
        }

        public Task<List<Uretim_UretimTablo>> UretimTabloGetirTarihAraligiAsync(DateTime baslamaTarih, DateTime bitisTarih, int makinaKod)
        {
            var result = dc.UretimTablo
                  .Where(c => c.Tarih >= baslamaTarih && c.Tarih<=bitisTarih)
                  .Where(c => c.MakinaKod == makinaKod)
                  .AsNoTracking()
                  .ToListAsync();

            return result;
        }

        public void Upsert(Uretim_UretimTablo obj)
        {
            dc.Update(obj);
        }

        public void Ekle(Uretim_UretimTablo obj)
        {
            obj.KayitEklenmeTarihi = DateTime.Now;
            dc.UretimTablo.Add(obj);


            var u = dc.ChangeTracker.Entries<Uretim_UretimTablo>().ToList();
        }

        public void Sil(Uretim_UretimTablo obj)
        {
            var kayit = dc.UretimTablo.FirstOrDefault(x => x.Id == obj.Id);

            if (kayit != null) dc.UretimTablo.Remove(kayit);
        }

     
    }
}
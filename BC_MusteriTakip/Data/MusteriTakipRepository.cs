using Microsoft.EntityFrameworkCore;
using mnd.Logic.BC_MusteriTakip.Domain;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mnd.Logic.BC_MusteriTakip.Data
{
    public class MusteriTakipRepository
    {
        MusteriTakipDbContext db = new MusteriTakipDbContext();

        public List<Gorusme> GorusmeListe()
        {
            var s = db.Gorusmeler
                .Include(c => c.GorusmeKonuTip)
                .Include(c => c.GorusmeTip)
                .AsNoTracking()
                .ToList();

            return s;
        }

        public Task<List<Gorusme>> GorusmeleriGetir()
        {
            return db.Gorusmeler
                .Include(c => c.GorusmeKonuTip)
                .Include(c => c.GorusmeTip)
                .AsNoTracking()
                .ToListAsync();
        }


        public Task<List<Gorusme>> GorusmeleriPlasiyereGoreGetir(string[] bagliPlasiyerKodlari)
        {
            var sonuc = db.Gorusmeler
                .Include(c => c.GorusmeKonuTip)
                .Include(c => c.GorusmeTip)
                .Where(c => bagliPlasiyerKodlari.Any(x => x.ToString() == c.PlasiyerKod.ToString()))
                .AsNoTracking()
                .ToListAsync();

            return sonuc;
        }


        public Gorusme GorusmeGetir(int id)
        {
            return
                db.Gorusmeler
                .Include(c => c.GorusmeKonuTip)
                .Include(c => c.GorusmeTip)
                .Where(c => c.Id == id).First();
        }

        public Gorusme GorusmeGetir_NoTrack(int id)
        {
            return
                db.Gorusmeler
                .Include(c => c.GorusmeKonuTip)
                .Include(c => c.GorusmeTip)
                .AsNoTracking()
                .Where(c => c.Id == id).First();
        }


        public void GorusmeEkle(Gorusme gorusme)
        {
            db.Gorusmeler.Add(gorusme);
        }

        public void Kaydet()
        {
            db.SaveChanges();
        }


        public List<GorusmeKonuTip> GorusmeKonuTipleriGetir()
        {
            return db.GorusmeKonuTipleri.AsNoTracking().ToList();
        }


        public List<GorusmeTip> GorusmeTipleriGetir()
        {
            return db.GorusmeTipleri.AsNoTracking().ToList();
        }

        public List<YaslandirilmisFatura> YaslandirilmisFaturalariGetir(string cariKod, int dovizTipKod)
        {

            var sonuc = db.YazlandirilmisFaturalar
                        .FromSql("execute [MusteriTakip].[CariYaslandirilmisBorcAlacakFaturalar] {0},{1}", cariKod, dovizTipKod)
                        .ToList();

            return sonuc;
        }

        public List<Unvan> UnvanlariGetir(string dil = "tr")
        {
            var sonuc = db.Unvanlar.ToList();
            return sonuc;
        }
    }
}

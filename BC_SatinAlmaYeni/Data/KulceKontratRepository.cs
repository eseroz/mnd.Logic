using Microsoft.EntityFrameworkCore;
using mnd.Logic.BC_SatinAlmaYeni.Domain;
using mnd.Logic.Helper;
using System;
using System.Collections.ObjectModel;

namespace mnd.Logic.BC_SatinAlmaYeni.Data
{
    public class KulceKontratRepository
    {
        KulceSatinAlmaDbContext dc = new KulceSatinAlmaDbContext();

        public ObservableCollection<KulceKontrat> KulceKontratlariGetir()
        {
            return dc.KulceKontrats
                    .Include(c => c.KulceKontratDonemler)
                    .Include(c => c.KulceKontratDonemler).ThenInclude(p=>p.KulceProformalar)
                    .ToObservableCollection();
        }

        public void Kaydet()
        {
            dc.SaveChanges();
        }

        public void KulceKontratEkle(KulceKontrat kayit)
        {
            dc.KulceKontrats.Add(kayit);
        }
    }
}

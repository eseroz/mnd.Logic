using Microsoft.EntityFrameworkCore;
using mnd.Logic.BC_App.Domain;
using mnd.Logic.BC_SatinAlmaYeni.Domain;
using mnd.Logic.Helper;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mnd.Logic.BC_SatinAlmaYeni.Data
{
    public class AppRepositorySA
    {
        SatinAlmaDbContextYeni dc = new SatinAlmaDbContextYeni();

        public ObservableCollection<SurecTanim> SurecListe(string surecAd)
        {
            dc = new SatinAlmaDbContextYeni();

            var sonuc = dc.SurecTanimlar
                            .Where(c => c.SurecAd == surecAd)
                            .OrderBy(c=>c.Id)
                            .ToObservableCollection();
            return sonuc;
        }

        public ObservableCollection<SurecTanim> SurecListe()
        {
            dc = new SatinAlmaDbContextYeni();

            var sonuc = dc.SurecTanimlar
                                 .OrderBy(c => c.Id)
                            .ToObservableCollection();
            return sonuc;
        }

        public ObservableCollection<CariGecici> GeciciCariListe()
        {
            dc = new SatinAlmaDbContextYeni();
            var sonuc = dc.CariGeciciListe.ToObservableCollection();
            return sonuc;
        }

        public void GeciciCariEkle(CariGecici cari)
        {
            dc = new SatinAlmaDbContextYeni();
            var sonuc = dc.CariGeciciListe.Add(cari);
            dc.SaveChanges();

          
        }


    }
}

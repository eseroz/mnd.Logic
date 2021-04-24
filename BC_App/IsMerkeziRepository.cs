using Microsoft.EntityFrameworkCore;
using mnd.Logic.BC_App.Domain;
using mnd.Logic.BC_SatinAlmaYeni.Data;
using mnd.Logic.Helper;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using mnd.Logic.BC_App.Data;

namespace mnd.Logic.BC_App
{


    public class IsMerkeziRepository
    {
        AppDataContext dc = new AppDataContext();


        public void Kaydet()
        {
            dc.SaveChanges();
        }

        public ObservableCollection<IsMerkezi> IsMerkeziUretimMakinalariGetir()
        {
            SatinAlmaDbContextYeni dcIsMerkezi = new SatinAlmaDbContextYeni();

            var result = dc.IsMerkezleri
                .Where(c => c.UretimMakinasiMi.GetValueOrDefault() == true)
                .ToObservableCollection();

            return result;

        }

        public ObservableCollection<IsMerkezi> TumIsMerkezleriGetir()
        {
            SatinAlmaDbContextYeni dcIsMerkezi = new SatinAlmaDbContextYeni();

            var result = dc.IsMerkezleri
                        .ToObservableCollection();

            return result;

        }

        public ObservableCollection<IsMerkezi> TeknikDepoIsMerkezleriGetir()
        {
            SatinAlmaDbContextYeni dcIsMerkezi = new SatinAlmaDbContextYeni();

            var result = dc.IsMerkezleri
                .Where(c => c.MasrafRehber == "TD")
                .ToObservableCollection();

            return result;

        }


        public List<IsMerkezi> MakinalariGetir()
        {
            var result = dc.IsMerkezleri
                        .Where(c => c.MakinaMi.GetValueOrDefault() == true)
                        .ToList();
                        

            return result;

        }

        public List<IsMerkezi> UretimMakinalariGetir()
        {
            var result = dc.IsMerkezleri
                        .Where(c => c.UretimMakinasiMi.GetValueOrDefault() == true)
                        .ToList();


            return result;

        }


       

        public void Sil(IsMerkezi obj)
        {
            dc.Remove(obj);
        }

        public void Ekle(IsMerkezi obj)
        {
            dc.Add(obj);
        }
    }
}

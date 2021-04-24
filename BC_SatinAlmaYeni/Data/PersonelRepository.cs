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
    public class PersonelRepository
    {
        SatinAlmaDbContextYeni dc = new SatinAlmaDbContextYeni();


        public ObservableCollection<PersonelBilgi> PersonelListeGetir()
        {
            var result = dc.Personeller.ToObservableCollection();
            return result;
        }

        public ObservableCollection<PersonelBilgi> TalepPersonelListeGetir()
        {
            var result = dc.Personeller
                .Where(c=>c.TalepYetkiliMi.GetValueOrDefault()==true)
                .ToObservableCollection();
            return result;
        }
    }
}

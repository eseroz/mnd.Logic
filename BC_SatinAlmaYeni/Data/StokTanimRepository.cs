using Microsoft.EntityFrameworkCore;
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
    public class StokTanimRepository
    {
        public ObservableCollection<vwStokTanim> StokListesi(string grupKod)
        {
            SatinAlmaDbContextYeni dc = new SatinAlmaDbContextYeni();



            var sonuc = dc.StokTanimlar.AsQueryable();
                //.Include(c => c.StokGrupTanimNav).AsQueryable();

            if (grupKod.Length > 0) 
                sonuc = sonuc.Where(c => c.GRUP_KODU == grupKod);
 
            return sonuc.ToObservableCollection<vwStokTanim>();
        }


       
    }
}

using mnd.Logic.BC_App.Data;
using mnd.Logic.BC_App.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mnd.Logic.BC_App
{
    public class KullaniciDataServices
    {
        public static List<Kullanici> KullaniciGetirFromBirim(string birim)
        {
            AppDataContext dc = new AppDataContext();

            var sonuc=dc.Kullanicilar.Where(c => c.Birim == birim).ToList();

            dc.Dispose();

            return sonuc;
        }

        public static List<Kullanici> KullaniciGetirFromRol(string rol)
        {
            AppDataContext dc = new AppDataContext();

            var sonuc = dc.Kullanicilar.Where(c => c.KullaniciRol == rol).ToList();

            dc.Dispose();

            return sonuc;
        }

     
    }
}

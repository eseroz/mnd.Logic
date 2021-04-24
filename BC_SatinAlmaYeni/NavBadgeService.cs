using mnd.Logic.BC_SatinAlmaYeni.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mnd.Logic.BC_SatinAlmaYeni
{
    public class NavBadgeSatinAlmaService
    {
        public static Dictionary<string, int> SatinAlmaSurecSayilariniGetir()
        {
            SatinAlmaDbContextYeni dc = new SatinAlmaDbContextYeni();

            var sonuc = dc.Talepler
                .OrderBy(c => c.TalepSurecKonum)
                .GroupBy(c => c.TalepSurecKonum)
                .Select(c => new SurecInfo { SurecAd = c.Key, SurecSayi = c.Count() })
                .ToList();

            return sonuc.ToDictionary(c => c.SurecAd, c => c.SurecSayi); ;
        }




    }
}

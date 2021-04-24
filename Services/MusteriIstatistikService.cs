using Microsoft.EntityFrameworkCore;
using mnd.Common.Helpers;
using mnd.Logic.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mnd.Logic.Services
{
    public class CariIstatistikDto
    {
        public string CariKod { get; set; }
        public int? IsYuku_Ton { get; set; }

        public int SiparisMiktarToplam_Ton { get; set; }
        public int PaketlenenToplam_Kg { get; internal set; }
    }

    public class MusteriIstatistikService
    {
        public static List<CariIstatistikDto> MusteriIsYuku_Getir(string cariKod = "")
        {
            //PandapContext _dc = new PandapContext();

            //var query = _dc.Siparisler
            //   .Include(c => c.SiparisKalemleri)
            //   .Where(c => c.SiparisAcikMi == true)
            //   .Where(c => c.SiparisSurecDurum == SIPARISSURECDURUM.MUSTERIONAYLI)
            //   .Where(c => cariKod == "" || c.CariKod == cariKod)
            //   .Select(c => new
            //   {
            //       CariKod = c.CariKod,
            //       SiparisKalemDTO_List = c.SiparisKalemleri.ToList()

            //   })
            //   .AsNoTracking()
            //   .ToList()
            //   .Select(c => new
            //   {
            //       CariKod = c.CariKod
            //   })
            //   .GroupBy(g => g.CariKod)
            //   .Select(c => new CariIstatistikDto
            //   {
            //       CariKod = c.Key,


            //   });

            //_dc.Dispose();

            //return query.ToList();
            return new List<CariIstatistikDto>();

        }
    }
}

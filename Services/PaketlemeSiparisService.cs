using Microsoft.EntityFrameworkCore;
using mnd.Logic.Model.Satis;
using mnd.Logic.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mnd.Logic.Services
{
    public class PaketlemeSiparisService
    {
        public static string  PaketlemeNotGetir(string siparisKod)
        {
            PandapContext dc = new PandapContext();

            var not = dc.Siparisler
                .AsNoTracking()
                .First(c => c.SiparisKod == siparisKod)
                 .PaketlemeNot;
            return not;
        }

        public static SiparisKalem SiparisKalemGetir(string siparisKalemKod)
        {
            PandapContext dc = new PandapContext();

            var kalem = dc.SiparisKalemleri.AsNoTracking()
                .First(c => c.SiparisKalemKod == siparisKalemKod);

            return kalem;

        }



    }
}

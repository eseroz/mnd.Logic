using mnd.Logic.Model.Satis;
using mnd.Logic.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mnd.Logic.Services
{
    public class LmeService
    {
        public static LmeGunluk LmeFiyatGetirTarihten(DateTime date)
        {
            PandapContext _dc = new PandapContext();

            var lme = _dc.LmeGunluks.Where(c => c.Tarih == date).FirstOrDefault();
            _dc.Dispose();

            return lme;

        }
    }
}

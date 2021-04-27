using mnd.Logic.BC_App.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pandap.Logic.Persistence.Repositories
{
    public class PlasiyerRepository
    {
        private AppDataContext _dc;

        public PlasiyerRepository(AppDataContext context)
        {
            _dc = context;
        }

        public string[] PlasiyerKodlari() {
            var kodlar = _dc.Kullanicilar.Where(p => p.PlasiyerKod != null).Select(c => c.PlasiyerKod).ToArray();        
            return kodlar;
        }
    }
}

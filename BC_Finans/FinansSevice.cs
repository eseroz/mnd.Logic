using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mnd.Logic.BC_Finans
{
    public class FinansSevice
    {

        public List<vwBanka> BankaRaporGetir_HazirDegerler()
        {
            FinansDbContext dc = new FinansDbContext();
            var sonuc=dc.BankaFinansRapor
                .AsNoTracking()
                .ToList();

            return sonuc;
        }


    }
}

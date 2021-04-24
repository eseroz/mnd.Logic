using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mnd.Logic.BC_Dashboard
{
    public class MaliyetRaporServices
    {
        public List<Exw> ExwMaliyetGetir()
        {
            MaliyetDbContext dc = new MaliyetDbContext();

            var sonuc=dc.ExwRapor.AsNoTracking().ToList();

            return sonuc;
        }

    }
}

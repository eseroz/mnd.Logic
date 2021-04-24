using Microsoft.EntityFrameworkCore;
using mnd.Logic.BC_Satis.Data_LookUp;
using mnd.Logic.BC_Satis.Data_LookUp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mnd.Logic.BC_Satis.DataServices
{
    public class SatisLookUpService
    {
        public static List<OdemeTip> OdemeTipleriGetir()
        {
            _SatisLookUpDbContext dc = new _SatisLookUpDbContext();

            var liste = dc.OdemeTipleri
                .AsNoTracking()
                .ToList();
            dc.Dispose();

            return liste;
        }
    }
}

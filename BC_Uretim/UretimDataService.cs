using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mnd.Logic.BC_Uretim
{
    public class UretimDataService
    {

        
        public static List<MakinaDurusTanim> MakinaDuruslariGetir()
        {
            UretimDbContext dc = new UretimDbContext();

            var result = dc.MakinaDurusTanimlar
                .ToList();

            return result;
        }
    }
}

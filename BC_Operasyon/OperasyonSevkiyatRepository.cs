using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace mnd.Logic.BC_Operasyon
{
    public class OperasyonSevkiyatRepository
    {
        public OperasyonSevkiyatRepository()
        {

        }

        public List<vwPaletSevkPivot> CariBazliSevkedilenPaletDataFetir()
        {
            OperasyonIstatistikDbContext dc = new OperasyonIstatistikDbContext();
            var result=dc.vwPaletSevkPivots.AsNoTracking().ToList();

            return result;
        }
    }
}

using Microsoft.EntityFrameworkCore;
using mnd.Logic.BC_Satis.Data;
using mnd.Logic.BC_Satis.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mnd.Logic.BC_Satis.DataServices
{
    public class SatisCariService
    {
        public static List<Musteri> MusterileriGetir()
        {
            _SatisDbContext dc = new _SatisDbContext();

            var sonuclar = dc.Musteriler
                .AsNoTracking()
                .ToList();
            dc.Dispose();

            return sonuclar;
        }

        public static Musteri MusteriGetir(string musteriKod)
        {
            _SatisDbContext dc = new _SatisDbContext();

            var sonuc = dc.Musteriler.FirstOrDefault(c => c.CariKod == musteriKod);

            dc.Dispose();

            return sonuc;
        }
    }
}

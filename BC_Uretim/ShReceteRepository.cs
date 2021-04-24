using mnd.Logic.BC_Uretim.SH_RotaModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mnd.Logic.BC_Uretim
{
    public class ShRecete_TrackingRepository
    {
        private UretimDbContext dc = new UretimDbContext();
        public List<ShRecete> ReceteSatirlariGetir()
        {
            var sonuc = dc.ShReceteler
                .ToList();

            return sonuc;
        }

        public List<ShRecete> ReceteSatirlariGetir(string rotaKartId)
        {
            var sonuc = dc.ShReceteler
                .Where(c => c.RotaKartId == rotaKartId)
                .ToList();

            return sonuc;
        }

        public void Kaydet()
        {
            dc.SaveChanges();
        }

        public ShRecete UygunReceteGetir(string receteKod)
        {
            

            var sonuc = dc.ShReceteler
                 .Where(c => c.RotaKartId == receteKod)
                 .FirstOrDefault();

            return sonuc;
        }
    }
}

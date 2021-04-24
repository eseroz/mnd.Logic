using Microsoft.EntityFrameworkCore;
using mnd.Logic.BC_Uretim.SH_RotaModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mnd.Logic.BC_Uretim
{
    public class ShRotaKartTrackingRepository
    {
        private UretimDbContext dc = new UretimDbContext();
        public List<ShRotaKart> RotaKartlariGetir()
        {
            var sonuc = dc.ShRotaKartlari
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

        public string YeniShNoGetir()
        {
            var dcx = new UretimDbContext();
            var son = dcx.ShRotaKartlari.LastOrDefault();

            if(son==null)
            {
                return "SH" + (DateTime.Now.ToString("yy")) + "001";
            }

            var yeniYilMi = son.KartNo.Substring(2,2)!= DateTime.Now.ToString("yy");

            if (yeniYilMi) return "SH" + (DateTime.Now.ToString("yy")) + "001";

            var yeniNo = int.Parse(son.KartNo.Substring(2, 5)) + 1;

            return "SH" + yeniNo;

        }

        public void RotaKartEkle(ShRotaKart shRotaKartModel)
        {
            dc.ShRotaKartlari.Add(shRotaKartModel);
        }

        public ShRotaKart RotaKartiGetir(string kartNo)
        {
            var sonuc = dc.ShRotaKartlari
                .Include(c => c.Fazlar)
                .Include(c => c.Fazlar).ThenInclude(p => p.FazOperasyonlar)
                .Include(c => c.DokumBobinler)
                .First(c => c.KartNo == kartNo);

            return sonuc;
        }

        public List<ShRotaKart> RotaKartlariGetirYildan(int seciliYil)
        {
            var sonuc = dc.ShRotaKartlari
                .Include(c=>c.Fazlar)
                .Include(c => c.Fazlar).ThenInclude(p=>p.FazOperasyonlar)
                .Where(c=>c.Tarih.Year==seciliYil)
                .ToList();

            return sonuc;
        }
    }
}

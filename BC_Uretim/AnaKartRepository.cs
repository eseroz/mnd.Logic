using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mnd.Logic.BC_Uretim
{
    public class AnaKartRepository
    {

        private UretimDbContext dc = new UretimDbContext();


        public List<Anakart> AnaKartlariGetir()
        {
            var sonuc = dc.Anakartlar
                .ToList();

            return sonuc;
        }

        public void Kaydet()
        {
            dc.SaveChanges();
        }

        public string SonAnakartNoGetir()
        {
            var sonuc = dc.Anakartlar
              .AsNoTracking()
             .OrderByDescending(c => c.AnakartNo)
             .First();

            return sonuc.AnakartNo;
        }

        public string SonUretimEmriKartNoGetir(string AnaKartNo)
        {
            var sonuc = dc.UretimEmirleri
                 .AsNoTracking()
                .Where(c=>c.KartNo.Contains(AnaKartNo + "/"))
             .OrderByDescending(c => c.EklenmeTarih)
            
             .First();


            return sonuc.KartNo;
        }

        public bool AnakartVarMi(string anakartNo)
        {
            var anakartVarMi = dc.Anakartlar.AsNoTracking()
                .Any(c => c.AnakartNo == anakartNo);

            return anakartVarMi;

        }


        public void UretimEmriVerimGuncelle(string uretimEmriKod,int kombinMiktari_kg,int maxKombinEni)
        {
            var dcx = new UretimDbContext();

            var uretimEmri=dcx.UretimEmirleri.Where(c => c.UretimEmriKod == uretimEmriKod).First();

            uretimEmri.KombinMiktari_kg = kombinMiktari_kg;
            uretimEmri.MaxKombinEni = maxKombinEni;

            dcx.SaveChanges();
        }

        public void UretimEmriRuloGuncelle(int ıd, int? dokumEni_mm, int dokmeRuloAgirligi_kg)
        {
            var dcx = new UretimDbContext();

            var uretimEmri = dcx.UretimEmriRulolar.Where(c => c.Id == ıd).First();

            uretimEmri.DokumEni_mm = dokumEni_mm;
            uretimEmri.DokmeRuloAgirligi_kg = dokmeRuloAgirligi_kg;

            dcx.SaveChanges();
        }

        public void AnakartEkle(Anakart anakart)
        {
            var anakartVarMi = dc.Anakartlar.Any(c => c.AnakartNo == anakart.AnakartNo);

            if(anakartVarMi==false)
            {
                dc.Anakartlar.Add(anakart);
                dc.SaveChanges();
            }

         
        }
    }
}

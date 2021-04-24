using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mnd.Logic.BC_Satis._Sikayet.DataServices
{
    public class SikayetDataService
    {
        public List<SikayetKonuKategori> SikayetKonuKategorileriGetir()
        {
            _SikayetDbContext dc = new _SikayetDbContext();
            var sonuc = dc.KonuKategorileri.ToList();

            return sonuc;


        }

        public List<SikayetBolum> SikayetBolumleriGetir()
        {
            _SikayetDbContext dc = new _SikayetDbContext();
            var sonuc = dc.SikayetBolumleri.ToList();

            return sonuc;


        }

        public void KaliteDataGuncelle(int id, decimal? iadeMiktari, string duzeltmeOnlemeFaliyetNo, string konuDetay)
        {
            _SikayetDbContext dc = new _SikayetDbContext();
            var sikayet = dc.Sikayetler.Find(id);

            sikayet.IadeMiktari = iadeMiktari;
            sikayet.DuzeltmeOnlemeFaliyetNo = duzeltmeOnlemeFaliyetNo;
            sikayet.KonuDetay = konuDetay;

            dc.SaveChanges();

           
        }
    }
}

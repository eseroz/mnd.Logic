using Microsoft.EntityFrameworkCore;
using mnd.Logic.BC_SatinAlmaYeni.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mnd.Logic.BC_Satis._Siparis.DataServices
{
    public class NavBadgeSatisService
    {
        public static Dictionary<string, int> SiparisSurecSayilariniGetir(string[] bagliPlasiyerKodlari, string strSiparisSurecDurum=null)
        {
            SiparisDbContex dc = new SiparisDbContex();

             var sonuc = dc.Siparisler
                .Where(c=>c.SiparisSurecDurum== strSiparisSurecDurum || strSiparisSurecDurum==null)
                .Where(c=>c.SiparisAcikMi==true)
                .Where(c => bagliPlasiyerKodlari.Contains(c.CariKartNavigation.PlasiyerKod))
                .OrderBy(c => c.SiparisSurecDurum)
                .GroupBy(c => c.SiparisSurecDurum)
                .Select(c => new SurecInfo { SurecAd = c.Key, SurecSayi = c.Count() })
                .ToList();

            dc.Dispose();

            return sonuc.ToDictionary(c => c.SurecAd, c => c.SurecSayi); ;
        }
        public static Dictionary<string, int> SiparisSurecSayilariniGrupluGetir(string[] bagliPlasiyerKodlari, string strSiparisSurecDurum = null)
        {
            SiparisDbContex dc = new SiparisDbContex();


            var sonuc = dc.Siparisler
                .Where(c => c.SiparisSurecDurum == strSiparisSurecDurum || strSiparisSurecDurum == null)
                .Where(c => c.SiparisAcikMi == true)
                .Where(c => bagliPlasiyerKodlari.Contains(c.CariKartNavigation.PlasiyerKod))
                .OrderBy(c => c.SiparisSurecDurum)
                .GroupBy(c => new { c.SiparisSurecDurum, c.KapasitifMi})
                .Select(c => new SurecInfo { SurecAd = c.Key.SiparisSurecDurum, Param1 = c.Key.KapasitifMi.ToString(), SurecSayi = c.Count() })
                .ToList();

            dc.Dispose();

            return sonuc.ToDictionary(c => c.SurecAd + "_" + c.Param1, c => c.SurecSayi); ;
        }
        
    }
}

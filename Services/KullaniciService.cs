using mnd.Common.Helpers;
using mnd.Logic.Model.App;
using mnd.Logic.Persistence;
using System.Collections.Generic;
using System.Linq;

namespace mnd.Logic.Services
{
    public class KullaniciService
    {


        public static Kullanici KullaniciGetirFromKullanici(string id)
        {
            PandapContext _dc = new PandapContext();

            return _dc.Kullanicilar.Where(c => c.KullaniciId == id).FirstOrDefault();

        }

        public static List<Kullanici> PlasiyerleriGetir()
        {
            PandapContext _dc = new PandapContext();

            return _dc.Kullanicilar.Where(c => (c.KullaniciRol == KULLANICIROLLERI.SATIS || c.KullaniciRol == KULLANICIROLLERI.SATISYONETICI_BOLGE) 
                                    && c.AktifMi.GetValueOrDefault() == true)
                                    .ToList();

        }

        public static List<Kullanici> SahaSorumlulariGetir()
        {
            PandapContext _dc = new PandapContext();

            return _dc.Kullanicilar.Where(c => c.SahaSorumlusuMu.GetValueOrDefault()==true  && c.AktifMi.GetValueOrDefault() == true)
                                    .ToList();
        }

        public static List<Kullanici> AgentlariGetir()
        {
            PandapContext _dc = new PandapContext();

            return _dc.Kullanicilar.Where(c => c.KullaniciRol == "AGENT" && c.AktifMi.GetValueOrDefault() == true)
                                    .ToList();
        }
    }
}

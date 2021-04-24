using Microsoft.EntityFrameworkCore;
using mnd.Logic.Helper;
using mnd.Logic.Persistence;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace mnd.Logic.QueryModel.Repositories
{
    public class SatisDolulukRepository
    {
        private PandapQueryContext dc = new PandapQueryContext();
        private PandapContext dc_main = new PandapContext();

        public SatisDolulukRepository()
        {
        }

        public ObservableCollection<vwSiparisDolulukSon> VwSiparisDolulukGetir()
        {
            return dc.VwSiparisDoluluks.AsNoTracking().OrderBy(c => c.CariIsim).ToObservableCollection();
        }

        public void UpsertSiparisDoluluk()
        {
            var liste = dc_main.SiparisKalemleri
                        .Include(c => c.SiparisNav)
                        .Where(c => c.SiparisNav.SevkYil == 2018)
                        .Select(c => new SiparisDolulukGrupDto
                        {
                            CariKod = c.SiparisNav.CariKod,
     
                            SevkYil = c.SiparisNav.SevkYil.GetValueOrDefault()
                        })

                        .AsNoTracking()
                        .ToList()
                        .Distinct()

                        ;

            var sayi = liste.Count();

            var yukluOlanlar = dc.SiparisDoluluklar.ToList();

            foreach (var item in liste)
            {
                var satirSipDoluluk = yukluOlanlar.Where(c => c.SevkYili == item.SevkYil
                          && c.KullanimAlanTipKod == item.KullanimAlanTipKod
                          && c.CariKod == item.CariKod)
                        .FirstOrDefault();

                if (satirSipDoluluk == null)
                {
                    dc.SiparisDoluluklar.Add(new SiparisDoluluk { CariKod = item.CariKod, KullanimAlanTipKod = item.KullanimAlanTipKod, SevkYili = item.SevkYil });
                }

                dc.SaveChanges();
            }
        }

        public void Guncelle(vwSiparisDolulukSon satisDoluluk)
        {
            var sipDoluluk = dc.SiparisDoluluklar
                .Where(c => c.SevkYili == satisDoluluk.SevkYili && c.CariKod == satisDoluluk.CariKod && c.KullanimAlanTipKod == satisDoluluk.KullanimAlanTipKod)
                .FirstOrDefault();

            sipDoluluk.KapasiteYil_ton = satisDoluluk.KapasiteYil_ton.GetValueOrDefault();
            sipDoluluk.UrunKod = satisDoluluk.UrunKod;
            sipDoluluk.KullanimAlanTipKod = satisDoluluk.KullanimAlanTipKod;
            sipDoluluk.CariKod = satisDoluluk.CariKod;
            sipDoluluk.SevkYili = satisDoluluk.SevkYili;

            sipDoluluk.OcakButce = satisDoluluk.B_Ocak;
            sipDoluluk.SubatButce = satisDoluluk.B_Subat;
            sipDoluluk.MartButce = satisDoluluk.B_Mart;
            sipDoluluk.NisanButce = satisDoluluk.B_Nisan;
            sipDoluluk.MayisButce = satisDoluluk.B_Mayis;
            sipDoluluk.HaziranButce = satisDoluluk.B_Haziran;
            sipDoluluk.TemmuzButce = satisDoluluk.B_Temmuz;
            sipDoluluk.AgustosButce = satisDoluluk.B_Agustos;
            sipDoluluk.EylulButce = satisDoluluk.B_Eylul;

            sipDoluluk.EkimButce = satisDoluluk.B_Ekim;
            sipDoluluk.KasimButce = satisDoluluk.B_Kasim;
            sipDoluluk.AralikButce = satisDoluluk.B_Aralik;

            dc.SaveChanges();
        }

        public void Kaydet()
        {
            dc.SaveChanges();
        }
    }
}
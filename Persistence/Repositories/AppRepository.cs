using Microsoft.EntityFrameworkCore;
using mnd.Logic.Helper;
using mnd.Logic.Model.App;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace mnd.Logic.Persistence.Repositories
{
    public class AppRepository : RepositoryAsync<Ayarlar>
    {
        public AppRepository(PandapContext dc) : base(dc)
        {
        }

        public Ayarlar UygulamaBilgiGetir()
        {
            return _dc.Ayarlars.First();
        }

        public Layout LayoutGetir(string kullaniciId, string layoutName)
        {
            var sonuc = _dc.Layouts.Where(c => c.KullaniciId == kullaniciId && c.LayoutName == c.LayoutName).FirstOrDefault();

            if (sonuc == null) return null;

            return sonuc;
        }

        public ObservableCollection<Ayarlar> AyarlariGetir()
        {
            return _dc.Ayarlars.ToObservableCollection();
        }

        public List<ExcelImportTanim> ExcelImportTanimlar(string formAdi)
        {
            return _dc.ExcelImportTanims.Where(c => c.FormAdi == formAdi && c.ExcelBaslikHücreKonum != null).AsNoTracking().ToList();
        }

        public ObservableCollection<FormKomutYetki> AllFormPermissions()
        {
            return _dc.ViewCommandYetkis.ToObservableCollection();
        }

        public ObservableCollection<FormKomutYetki> FormPermissions(string formAdi)
        {
            return _dc.ViewCommandYetkis.Where(c => c.FormAd == formAdi).ToObservableCollection();
        }

        public void CommandYetkiEkle(FormKomutYetki yetki)
        {
            _dc.ViewCommandYetkis.Add(yetki);
        }

        public void CommandYetkiSil(FormKomutYetki yetki)
        {
            _dc.ViewCommandYetkis.Remove(yetki);
        }

        public ObservableCollection<FormKomutYetki> FormPermissions(string role, string menuAd)
        {
            var sonuc = _dc.ViewCommandYetkis.Where(
                c => c.FormAd == menuAd)
                .ToList();

            var sonuc1 = sonuc.Where(c =>
                 (
                      c.YetkiliRoller == "*"
                        ||
                        c.YetkiliRoller.Split(';').Contains(role) && !c.YetkiliRoller.Split(';').Contains("-") 
                        || role=="ADMIN"

                 ))
                .Where(c => c.YetkiliRoller != "-")
                .ToObservableCollection();

            return sonuc1;
        }
    }
}
using mnd.Logic.Helper;
using mnd.Logic.Model.App;
using mnd.Logic.Model.Satis;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace mnd.Logic.Persistence.Repositories
{
    public class KullaniciRepository : RepositoryAsync<Siparis>
    {
        public KullaniciRepository(PandapContext dc) : base(dc)
        {
        }

        public KullaniciBildirim KullaniciBildirimGetir(string KullaniciId)
        {
            return _dc.KullaniciBildirim.Where(p => p.KullaniciId == KullaniciId).LastOrDefault();

        }

        public Kullanici KullaniciGetir(string kullaniciId)
        {
            return _dc.Kullanicilar.Where(c => c.KullaniciId == kullaniciId).FirstOrDefault();
        }

        public List<Kullanici> SatisPersonelleriGetir()
        {
            return _dc.Kullanicilar.Where(c => c.KullaniciRol.Contains("SATIS"))
                .Where(c=>c.AktifMi==true)
                .ToList();
        }

        public ObservableCollection<Kullanici> KullanicilariGetir()
        {
            return _dc.Kullanicilar.ToObservableCollection();
        }

        public void KullaniciEkle(Kullanici k)
        {
            _dc.Kullanicilar.Add(k);
        }

        public void KullaniciRolEkle(KullaniciRol k)
        {
            _dc.KullaniciRols.Add(k);
        }

        public Kullanici KullaniciGetir(string kullaniciId, string parola)
        {            
            return _dc.Kullanicilar.Where(c => c.KullaniciId == kullaniciId && c.Parola == parola).FirstOrDefault();
        }

        public string TumBagliKullanicilariGetir()
        {
            return _dc.Kullanicilar.Select(c => c.KullaniciId).ToList()
                    .Aggregate((current, next) => current + ";" + next);
        }

        public ObservableCollection<KullaniciRol> KullaniciRolleriGetir()
        {
            return _dc.KullaniciRols
                .OrderBy(c=>c.RolAd)
                .ToObservableCollection();
        }

        public Kullanici RoleGoreIlkKullaniciGetir(string kullaniciRol)
        {
            return _dc.Kullanicilar.Where(c => c.KullaniciRol == kullaniciRol).First();
        }
    }
}
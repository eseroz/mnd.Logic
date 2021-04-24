using Microsoft.EntityFrameworkCore;
using mnd.Logic.Helper;
using mnd.Logic.Model.Satis;
using mnd.Logic.Model.Uretim;
using System.Collections.ObjectModel;
using System.Linq;

namespace mnd.Logic.Persistence.Repositories
{
    public class KaliteRepository : RepositoryAsync<Siparis>
    {
        public KaliteRepository(PandapContext dc) : base(dc)
        {
        }

        public KaliteStandart VarsayilanKaliteAralikGetir(string kullanim_alani, string alasim, string sertlik, decimal? kalinlik)
        {
            var x = _dc.KaliteStandartlari.Where(c =>
                        c.KullanimAlanlari.Contains(kullanim_alani) &&
                        alasim.Contains(c.AlasimKod) &&
                        c.KondisyonKod == sertlik)
                    .AsNoTracking();

            var sonuc = x.Where(c =>
                   kalinlik.Value >= decimal.Parse(c.KalinlikAralik.Split('-')[0]) &&
                   kalinlik.Value <= decimal.Parse(c.KalinlikAralik.Split('-')[1]))
                 .FirstOrDefault();

            return sonuc;
        }

        public ObservableCollection<Recete> ReceteListesiGetir()
        {
            return _dc.Receteler.ToObservableCollection();
        }

        public void ReceteEkle(Recete obj)
        {
            _dc.Receteler.Add(obj);
            _dc.SaveChanges();
        }

        public void KaliteStandartEkle(KaliteStandart obj)
        {
            _dc.KaliteStandartlari.Add(obj);
            _dc.SaveChanges();
        }

        public void UrunEkle(Urun obj)
        {
            _dc.Urunler.Add(obj);
            _dc.SaveChanges();
        }

        public ObservableCollection<Urun> UrunListesiGetir()
        {
            return _dc.Urunler.ToObservableCollection();
        }

        public ObservableCollection<KaliteStandart> KaliteStandartlariGetir()
        {
            return _dc.KaliteStandartlari.ToObservableCollection();
        }
    }
}
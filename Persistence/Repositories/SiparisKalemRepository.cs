using Microsoft.EntityFrameworkCore;
using mnd.Common;
using mnd.Common.Helpers;
using mnd.Logic.Helper;
using mnd.Logic.Model._Ref;
using mnd.Logic.Model.Satis;
using mnd.Logic.Model.Stok;
using mnd.Logic.Model.Uretim;
using System.Collections.ObjectModel;
using System.Linq;

namespace mnd.Logic.Persistence.Repositories
{
    public class SiparisKalemRepository : RepositoryAsync<Siparis>
    {
        public SiparisKalemRepository(PandapContext dc = null) : base(dc)
        {
            dc = new PandapContext();
        }

        public ObservableCollection<SiparisKalem> SiparisKalemleriGetir()
        {
            return _dc.SiparisKalemleri
                .Include(p => p.SiparisNav)
                .Include(c => c.SiparisNav.CariKartNavigation)
                .ToObservableCollection();
        }

        public ObservableCollection<SiparisKalem> AktifSiparisKalemleriIleEmirleriGetir()
        {
            return _dc.SiparisKalemleri
                    .Include(p => p.SiparisNav)
                    .Include(c => c.SiparisNav.CariKartNavigation)
                    .Where(t => t.SiparisNav.SiparisSurecDurum ==
                    SIPARISSURECDURUM.MUSTERIONAYLI)
                    .ToList()
                    .Select(c =>
                    {
                       c.SevkYilAy = c.SiparisNav.SevkYilHafta.Split('/')[0] + "/" +
                       CalenderUtil.MounthFromWeekNumber(int.Parse(c.SiparisNav.SevkYilHafta.Split('/')[0])
                      , int.Parse(c.SiparisNav.SevkYilHafta.Split('/')[1]))
                      .ToString().PadLeft(2, '0');
                        return c;
                    })
                .ToObservableCollection();
        }

        public int KapatilmisKalemSayisiGetir()
        {
            return 0;
        }

        public IQueryable<SiparisKalem> SiparisSurecDurumaGoreKalemler(string surecdurum)
        {
            return _dc.SiparisKalemleri
                    .Include(p => p.SiparisNav)
                    .Where(c => c.SiparisNav.SiparisSurecDurum == surecdurum);
        }

        public ObservableCollection<SiparisKalem> KapatilmisSiparisKalemleriIleEmirleriGetir()
        {
            return Queryable.Where<SiparisKalem>(_dc.SiparisKalemleri
                    .Include(p => p.SiparisNav)
                    .Include(c => c.SiparisNav.CariKartNavigation), t => t.SiparisNav.SiparisSurecDurum == SIPARISSURECDURUM.MUSTERIONAYLI)
                .ToObservableCollection();
        }

        public SiparisKalem SiparisKalemiGetir(string kalemKod)
        {
            return _dc.SiparisKalemleri
                    .Include(c => c.SiparisNav)
                    .Include(c => c.SiparisNav).ThenInclude(c => c.CariKartNavigation)
                    .Where(c => c.SiparisKalemKod == kalemKod)
                    .FirstOrDefault();

        }

        public SiparisKalem MusteriUrunKodundan_SiparisKalemiGetir(string musteri_urunKod, string siparisKalemKod)
        {
            return _dc.SiparisKalemleri
                    .Where(c => c.MusteriUrunKodu == musteri_urunKod && c.SiparisKalemKod != siparisKalemKod)
                    .OrderByDescending(c => c.SiparisKalemKod)
                    .FirstOrDefault();

        }


        public ObservableCollection<LmeTip> LmeTipleriGetir() => _dc.LmeTipleri.ToObservableCollection();

        public ObservableCollection<DovizTip> DovizTipleriGetir() => _dc.DovizTipleri.ToObservableCollection();

        public ObservableCollection<KulcePrimTip> KulcePrimTipleriGetir() => _dc.KulceTipleri.ToObservableCollection();

        public ObservableCollection<BirimTip> BirimTipleriGetir() => _dc.BirimTipleri.ToObservableCollection();

        public ObservableCollection<AlasimTip> AlasimTipleriGetir() => _dc.AlasimTipleri.ToObservableCollection();

        public ObservableCollection<MasuraTip> MasuraTipleriGetir() => _dc.MasuraTipleri.ToObservableCollection();

        public ObservableCollection<YuzeyTip> YuzeyTipleriGetir() => _dc.YuzeyTipleri.ToObservableCollection();

        public ObservableCollection<SertlikTip> SertlikTipleriGetir() => _dc.SertlikTipleri.ToObservableCollection();

        public ObservableCollection<KullanimAlanTip> KullanimAlanTipleriGetir() => _dc.KullanimAlaniTipleri.ToObservableCollection();

        public ObservableCollection<AmbalajTip> AmbalajTipleriGetir() => _dc.AmbalajTipleri.ToObservableCollection();


        public ObservableCollection<TBLIHRSTK> UrunleriGetir() => _dc.Urunler.ToObservableCollection();
        public ObservableCollection<TBLIHRSTK> UrunleriGetirReadOnly() => _dc.Urunler.AsNoTracking().ToObservableCollection();

        public SiparisKalem SipariseAitIlkKalemiGetir(string ilgiliKapasitifSiparisKod)
        {
            return _dc.SiparisKalemleri.AsNoTracking().First(c => c.SiparisKod == ilgiliKapasitifSiparisKod);
        }


    }
}
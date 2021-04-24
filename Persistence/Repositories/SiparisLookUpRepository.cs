using mnd.Logic.Helper;
using mnd.Logic.Model._Ref;
using mnd.Logic.Model.Netsis;
using mnd.Logic.Model.Satis;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace mnd.Logic.Persistence.Repositories
{
    public class SiparisLookUpRepository : RepositoryAsync<Siparis>
    {
        public SiparisLookUpRepository(PandapContext dc = null) : base(dc)
        {
            if (dc == null)
                dc = new PandapContext();
        }

        public ObservableCollection<OdemeTip> OdemeTipleriGetir()
        {
            return _dc.OdemeTipleri.ToObservableCollection();
        }

        public ObservableCollection<SatisTip> SatisTipleriGetir()
        {
            return _dc.SatisTipleri.ToObservableCollection();
        }

        public ObservableCollection<TeslimTip> TeslimTipleriGetir()
        {
            return _dc.TeslimTipleri.ToObservableCollection();
        }

        public ObservableCollection<TeslimTip> TeslimTipleriGetir(string satisTip)
        {
            var s = _dc.TeslimTipleri.Where(c => c.SatisTiptenFiltre.Contains(satisTip)).ToObservableCollection();
            return s;
        }

        public ObservableCollection<DovizTip> DovizTipleriGetir()
        {
            return _dc.DovizTipleri.ToObservableCollection();
        }

        public ObservableCollection<CariKart> CariKartlariGetir(string[] plasiyerKodlar)
        {
            return _dc.CariKartlar.Where(c => plasiyerKodlar.Contains(c.PlasiyerKod)).ToObservableCollection();
        }

        public CariKart CariKartGetir(string cariKod)
        {
            return _dc.CariKartlar.Where(c => c.CariKod == cariKod).FirstOrDefault();
        }

        public DovizKur NetsisDovizKurunuGetir(string dovizAd, DateTime tarih)
        {
            var v = _dc.DovizKurlari.Where(c => c.Tarih == tarih.Date && c.DovizAd == dovizAd).FirstOrDefault();
            return v;
        }

        public List<DovizKur> NetsisGunlukDovizKurunuGetir(DateTime tarih)
        {
            var v = _dc.DovizKurlari.Where(c => c.Tarih == tarih.Date).ToList();
            return v;
        }

        public List<DovizKur> NetsisBelirliTarihtenSonrakiDovizKurlariniGetir(DateTime tarih)
        {
            var v = _dc.DovizKurlari.Where(c => c.Tarih >= tarih.Date).ToList();
            return v;
        }

        public List<DovizKur> NetsisKayitliSonDovizKurlariniGetir()
        {
            var sonKayitTarihi = _dc.DovizKurlari
                       .OrderByDescending(c => c.Tarih)
                       .First().Tarih;

            var v = _dc.DovizKurlari.Where(c => c.Tarih >= sonKayitTarihi.Value.Date).ToList();
            return v;
        }


        public ObservableCollection<LmeTip> LmeBaglamaTipleriGetir()
        {
            var v = _dc.LmeTipleri.OrderBy(c => c.CiktiSira).ToObservableCollection();
            return v;
        }
    }
}
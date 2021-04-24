using Microsoft.EntityFrameworkCore;
using mnd.Common.Helpers;
using mnd.Logic.Helper;
using mnd.Logic.Model.Operasyon;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace mnd.Logic.Persistence.Repositories
{



    public class SevkiyatEmirRepository : RepositoryAsync<SevkiyatEmri>
    {
        public SevkiyatEmirRepository(PandapContext dc) : base(dc)
        {
        }


        public void SevkiyatEmriEkle(SevkiyatEmri emir)
        {

            _dc.SevkiyatEmirleri.Add(emir);
        }

        public ObservableCollection<SevkiyatEmri> YuklemedekiSevkiyatEmirleriGetir()
        {
            var q = YuklemeSevkiyatEmirleriGetirQuery()
                .OrderBy(c => c.YuklemeBitisTarih.GetValueOrDefault())
                    .ThenByDescending(c => c.YuklemeBaslamaTarih.GetValueOrDefault())
                .Where(c => c.SevkSurecDurum == SEVKSURECKONUM.YUKLEME || c.YuklemeBaslamaTarih.GetValueOrDefault().Date == DateTime.Now.Date);

            return q.ToObservableCollection();
        }

        public SevkiyatEmri YuklemedekiSevkiyatEmirleriGetir(int id)
        {
            var q = YuklemeSevkiyatEmirleriGetirQuery().Where(c => c.SevkiyatEmriId == id).FirstOrDefault();

            return q;
        }

        public ObservableCollection<SevkiyatEmri> SevkiyatEmirleriGetir(string durum)
        {
            var q = SevkiyatEmirleriGetirQuery();

            if (durum == "") return q.ToObservableCollection();

            if (durum == SEVKSURECKONUM.MUHASEBE)
            {
                q = q.Where(c => c.SevkSurecDurum == SEVKSURECKONUM.MUHASEBE);
            }
            else
            {
                q = q.Where(c => c.SevkSurecDurum != SEVKSURECKONUM.MUHASEBE);
            }

            return q.ToObservableCollection();
        }

        public IQueryable<SevkiyatEmri> YuklemeSevkiyatEmirleriGetirQuery()
        {
            var s = _dc.SevkiyatEmirleri
                .Include(c => c.CariIrsaliyeler)
                .Include(c => c.CariIrsaliyeler).ThenInclude(c => c.CariKodNav)
                .Include(c => c.CariIrsaliyeler).ThenInclude(c => c.IrsaliyePaletler)
                .AsNoTracking()
                .AsQueryable();

            return s;
        }

        public IQueryable<SevkiyatEmri> SevkiyatEmirleriGetirQuery()
        {
            var s = _dc.SevkiyatEmirleri
                .Include(c => c.CariIrsaliyeler)
                .Include(c => c.CariIrsaliyeler).ThenInclude(c => c.IrsaliyePaletler)
                .AsNoTracking()
                .AsQueryable();

            return s;
        }


        public SevkiyatEmri SevkiyatEmriGetirFromId(int id)
        {

            var emir = _dc.SevkiyatEmirleri
              .Include(c => c.CariIrsaliyeler)
              .Include(c => c.CariIrsaliyeler).ThenInclude(c => c.IrsaliyePaletler)
              .Where(c => c.SevkiyatEmriId == id).FirstOrDefault();

            return emir;
        }

        public IrsaliyePalet IrsaliyePaletGetir(int paletId)
        {
            return _dc.CariIrsaliyePaletler.Where(c => c.PaletId == paletId).First();
        }

        public void IrsaliyePaletSil(int paletId)
        {
            var irsPalet = _dc.CariIrsaliyePaletler.Where(c => c.PaletId == paletId).First();

            _dc.CariIrsaliyePaletler.Remove(irsPalet);
        }


        public void PaletDurumDegistir(int paletId, string paletDurum)
        {

            var palet = _dc.UretimPaletler.Find(paletId);
            palet.PaletKonum = paletDurum;
        }

        public void PaletiSevkiyattanCikar(int paletId)
        {

            var palet = _dc.UretimPaletler.Find(paletId);
            palet.SevkiyatEmriId = null;
        }



        public Irsaliye CariIrsaliyeGetir(int irsaliyeId)
        {


            var irsaliye = _dc.CariIrsaliyeler
                            .Include(c => c.IrsaliyePaletler)
                            .Where(c => c.IrsaliyeId == irsaliyeId)
                            .FirstOrDefault();

            return irsaliye;
        }


        public Irsaliye BirOncekiCariIrsaliyeGetir(string cariKod, int irsaliyeId)
        {
            PandapContext dcAlt = new PandapContext();

            var irsaliye = dcAlt.CariIrsaliyeler
                            .Where(c => c.CariKod == cariKod && c.IrsaliyeId != irsaliyeId)
                            .ToList()
                            .OrderByDescending(c => c.IrsaliyeId)
                            .FirstOrDefault();

            return irsaliye;
        }

        public SevkiyatEmri SevkEmriEkle(SevkiyatEmri seciliSevkiyatEmri)
        {
            _dc.SevkiyatEmirleri.Add(seciliSevkiyatEmri);
            return seciliSevkiyatEmri;
        }

        public SevkiyatEmri SevkEmriSil(SevkiyatEmri seciliSevkiyatEmri)
        {
            _dc.SevkiyatEmirleri.Remove(seciliSevkiyatEmri);
            return seciliSevkiyatEmri;
        }

        public void SevkiyatTeslimEdildi(int sevkiyatEmriId, DateTime teslimTarihi)
        {
            PandapContext dcAlt = new PandapContext();

            var sevkiyat = dcAlt.SevkiyatEmirleri
               .FirstOrDefault(c => c.SevkiyatEmriId == sevkiyatEmriId);

            sevkiyat.TeslimTarihi = teslimTarihi;


            dcAlt.SaveChanges();


        }

        public void SevkiyatSurecDegistir(int sevkiyatEmriId, string surec)
        {
            PandapContext dcAlt = new PandapContext();

            var sevkiyat = dcAlt.SevkiyatEmirleri
               .FirstOrDefault(c => c.SevkiyatEmriId == sevkiyatEmriId);

            sevkiyat.SevkSurecDurum = surec;


            dcAlt.SaveChanges();


        }

        public void CariKodNavUpdateIgnore(SevkiyatEmri seciliSevkiyatEmri)
        {
            foreach (var irs in seciliSevkiyatEmri.CariIrsaliyeler)
            {
                if (irs.CariKodNav != null)
                    _dc.Entry(irs.CariKodNav).State = EntityState.Unchanged;
            }

        }

        public string SevkEmriDurumGetir(int sevkiyatEmriId)
        {
            PandapContext dcAlt = new PandapContext();

            var sevkiyat = dcAlt.SevkiyatEmirleri
               .FirstOrDefault(c => c.SevkiyatEmriId == sevkiyatEmriId);

            if (sevkiyat == null) return SEVKSURECKONUM.OPERASYON;

            return sevkiyat.SevkSurecDurum;
        }
    }
}
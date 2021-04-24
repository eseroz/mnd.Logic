using mnd.Logic.Helper;
using mnd.Logic.Model._Ref;
using System.Collections.ObjectModel;
using System.Linq;

namespace mnd.Logic.Persistence.Repositories
{
    public class LookUpRepository
    {
        PandapContext dc = new PandapContext();

        public ObservableCollection<KullanimAlanTip> KullanimAlanlariniGetir()
        {
            var sonuc = dc.KullanimAlaniTipleri.ToObservableCollection();
            return sonuc;
        }

        public KullanimAlanTip KullanimAlanlarini(string kullanimAlanTipKod)
        {


            var sonuc = dc.KullanimAlaniTipleri.Where(c => c.KullanimAlanKod == kullanimAlanTipKod).FirstOrDefault();

            if (sonuc == null) return new KullanimAlanTip { KullanimAlanKod = "YOK", Aciklama = "Tanımlı Değil", Aciklama_EN = "Tanımlı Değil" };
            return sonuc;
        }
    }
}

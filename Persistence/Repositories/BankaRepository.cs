using mnd.Logic.Helper;
using mnd.Logic.Model.App;
using System.Collections.ObjectModel;
using System.Linq;

namespace mnd.Logic.Persistence.Repositories
{
    public class BankaRepository
    {
        private PandapContext _dc;

        public BankaRepository(PandapContext dc)
        {
            _dc = dc;
        }

        public ObservableCollection<Banka> AktifBankalariGetir()
        {
            return _dc.Bankas.Where(c => c.AktifMi == true).ToObservableCollection();
        }

        public ObservableCollection<Banka> BankalariGetir()
        {
            return _dc.Bankas.ToObservableCollection();
        }

        public Banka BankaGetir(string bankaKod)
        {
            return _dc.Bankas.Where(c => c.BankaKod == bankaKod).First();
        }

        public void Ekle(Banka banka)
        {
            _dc.Bankas.Add(banka);
        }

        public void Sil(Banka banka)
        {
            _dc.Bankas.Remove(banka);
        }
    }
}
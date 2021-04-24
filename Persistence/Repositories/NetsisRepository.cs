using Microsoft.EntityFrameworkCore;
using mnd.Logic.Helper;
using mnd.Logic.Model.Netsis;
using mnd.Logic.Model.Operasyon;
using mnd.Logic.Model.Satis;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace mnd.Logic.Persistence.Repositories
{
    public class NetsisRepository : RepositoryAsync<Siparis>
    {
        public NetsisRepository(PandapContext dc) : base(dc)
        {
        }

        public CariRiskKontrol RiskDurumGetir(string cariKod)
        {
            return Queryable.Where<CariRiskKontrol>(_dc.CariRiskKontrols, c => c.CariKod == cariKod).FirstOrDefault();
        }

        public async Task<ObservableCollection<CariRiskKontrol>> CariRiskListeGetirAsync()
        {
            ObservableCollection<CariRiskKontrol> sonuc = null;
            await Task.Run(() =>
            {
                sonuc = _dc.CariRiskKontrols.Take(200).ToObservableCollection();
            });

            return sonuc;
        }

        public CariEmail CariIlgiliKisiGetir(string carikod)
        {
            return _dc.CariEmailleri
                    .AsNoTracking()
                   .FirstOrDefault(c => c.CariKod == carikod);
        }
    }
}
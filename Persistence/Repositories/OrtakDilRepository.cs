using mnd.Logic.Helper;
using mnd.Logic.Model.App;
using System.Collections.ObjectModel;

namespace mnd.Logic.Persistence.Repositories
{
    public class OrtakDilRepository : RepositoryAsync<OrtakDilTanim>
    {
        public OrtakDilRepository(PandapContext dc) : base(dc)
        {
        }

        public ObservableCollection<OrtakDilTanim> OrtakDilTanimListeGetir()
        {
            return _dc.OrtakDilTanims.ToObservableCollection();
        }
    }
}
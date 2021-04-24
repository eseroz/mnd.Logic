using mnd.Logic.Helper;
using mnd.Logic.Model.Uretim;
using System.Collections.ObjectModel;

namespace mnd.Logic.Persistence.Repositories
{
    public class ReceteRepository
    {
        private PandapContext _dc;

        public ReceteRepository(PandapContext dc)
        {
            _dc = dc;
        }

        public ObservableCollection<Recete> ReceteleriGetir()
        {
            return _dc.Receteler
                .ToObservableCollection();
        }
    }
}
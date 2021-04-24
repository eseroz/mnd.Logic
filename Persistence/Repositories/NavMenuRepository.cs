using mnd.Logic.Helper;
using mnd.Logic.Model.App;
using System.Collections.ObjectModel;

namespace mnd.Logic.Persistence.Repositories
{
    public class NavMenuRepository
    {
        private PandapContext _context;

        public NavMenuRepository(PandapContext context)
        {
            _context = context;
        }

        public ObservableCollection<FormMenuItem> NavMenuItemGetir()
        {
            return _context.NavMenuItems.ToObservableCollection();
        }

        public void Ekle(FormMenuItem obj)
        {
            _context.NavMenuItems.Add(obj);
        }
    }
}
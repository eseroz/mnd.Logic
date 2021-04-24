using mnd.Logic.Helper;
using mnd.Logic.Model.App;
using mnd.Logic.Persistence;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mnd.Logic.AppRepositories
{
    public class NavMenuRepository1
    {
        PandapContext _context = new PandapContext();

       
        public ObservableCollection<FormMenuItem> NavMenuItemGetir()
        {
            return _context.NavMenuItems.Where(p=>p.Visibility==true).ToObservableCollection();
        }

        public void Ekle(FormMenuItem obj)
        {
            _context.NavMenuItems.Add(obj);
        }
    }
}

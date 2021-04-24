using Microsoft.EntityFrameworkCore;
using mnd.Logic.Helper;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace mnd.Logic.BC_Satis._Seyahat.DataServices
{
    public class SeyahatRepository
    {
        _SeyahatDbContext dc;
        public SeyahatRepository()
        {
            dc = new _SeyahatDbContext();
        }

        public ObservableCollection<Seyahat> SeyahatleriGetir()
        {
            dc = new _SeyahatDbContext();
            var Seyahatler = dc.Seyahatler
                .Include(c => c.Gorusmeler)
                .OrderByDescending(c => c.Id)
                .AsNoTracking()
                .ToObservableCollection();

            return Seyahatler;

        }

        public void Kaydet()
        {
            dc.SaveChanges();
        }

        public void Ekle(Seyahat Seyahat)
        {
            dc.Seyahatler.Add(Seyahat);
        }

        public Seyahat SeyahatGetirNoTrack(int id)
        {
            var Seyahat = dc.Seyahatler
                .Include(c => c.Gorusmeler)
                .Where(c => c.Id == id)
                .AsNoTracking()
                .FirstOrDefault();

            return Seyahat;
        }

        public Seyahat SeyahatGetir(int id)
        {
            var Seyahat = dc.Seyahatler
                .Include(c=>c.Gorusmeler)
                .Where(c => c.Id == id).FirstOrDefault();

            return Seyahat;
        }

        public List<UlkeSabit> UlkeleriGetir()
        {
            return dc.UlkeSabits.AsNoTracking().ToList();
        }

       
    }
}
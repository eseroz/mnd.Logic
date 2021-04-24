using Microsoft.EntityFrameworkCore;
using mnd.Logic.Helper;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mnd.Logic.BC_Satis._Sikayet.DataServices
{
    public class SikayetRepository
    {
        _SikayetDbContext dc;
        public SikayetRepository()
        {
            dc = new _SikayetDbContext();
        }

        public ObservableCollection<Sikayet> SikayetleriGetir()
        {
            dc = new _SikayetDbContext();
            var sikayetler = dc.Sikayetler
                .OrderByDescending(c=>c.Id)
                .AsNoTracking()
                .ToObservableCollection();

            return sikayetler;

        }

        public void Kaydet()
        {
            dc.SaveChanges();
        }

        public void Ekle(Sikayet sikayet)
        {
            dc.Sikayetler.Add(sikayet);
        }

        public Sikayet SikayetGetir(int id)
        {
            var sikayet = dc.Sikayetler.Where(c => c.Id == id).FirstOrDefault();

            return sikayet;
        }
    }
}

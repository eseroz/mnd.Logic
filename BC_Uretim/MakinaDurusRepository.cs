using mnd.Logic.Helper;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mnd.Logic.BC_Uretim
{
    public class MakinaDurusRepository
    {
        private UretimDbContext dc = new UretimDbContext();


        public ObservableCollection<MakinaDurusTanim> MakinaDurusTanimlariGetir()
        {
            var sonuc = dc.MakinaDurusTanimlar.ToList();

            return sonuc.ToObservableCollection();
        }

        public void MakinaDurusTanimEkle(MakinaDurusTanim makinaDurus)
        {
            dc.MakinaDurusTanimlar.Add(makinaDurus);
            dc.SaveChanges();

           
        }

        public void Kaydet()
        {
            dc.SaveChanges();
        }
    }
}

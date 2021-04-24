using mnd.Logic.Helper;
using System.Collections.ObjectModel;
using System.Linq;

namespace mnd.Logic.BC_Personel
{
    public class PersonelService
    {
        public ObservableCollection<PersonelBilgi> AktifPersonelleriGetir()
        {
            PersonelDbContext dc = new PersonelDbContext();

            var result = dc.Personeller
                .Where(c => c.AKTIF == 'E')
                .OrderBy(c => c.ADSOYAD)
                .ToObservableCollection();

            return result;
        }

        public PersonelBilgi AktifPersonelGetir(string tc)
        {
            PersonelDbContext dc = new PersonelDbContext();

            var result = dc.Personeller
                .Where(c => c.AKTIF == 'E')
                .Where(c => c.TCKIMLIKNO == tc)
                .First();

            return result;
        }


        public ObservableCollection<PersonelBilgi> PersonelleriGetir()
        {
            PersonelDbContext dc = new PersonelDbContext();

            var result = dc.Personeller.ToObservableCollection();

            return result;
        }
    }
}

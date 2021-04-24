using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mnd.Logic.BC_Uretim
{
    public class MakinaParcaRepository
    {

        private UretimDbContext dc = new UretimDbContext();


        public List<MakinaParca> MakinaParcalarigetir()
        {
            var sonuc = dc.MakinaParcalari.ToList();

            return sonuc;
        }

        public void Kaydet()
        {
            dc.SaveChanges();
        }
    }
}

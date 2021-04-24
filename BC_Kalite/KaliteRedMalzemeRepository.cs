using mnd.Logic.BC_Kalite.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mnd.Logic.BC_Kalite
{
    public class KaliteRedMalzemeRepository
    {
        KaliteDbContext dc = new KaliteDbContext();

        public List<KaliteRedMalzeme> KaliteRedMalzemeler()
        {
            var s = dc.KalteRedMalzemeler.ToList();

            return s;
        }

        public void Kaydet()
        {
            dc.SaveChanges();
        }

        public void Ekle(KaliteRedMalzeme kayit)
        {
            dc.KalteRedMalzemeler.Add(kayit);
        }

        public KaliteRedMalzeme GetirById(int id)
        {
            var sonuc = dc.KalteRedMalzemeler.Where(c => c.Id == id).FirstOrDefault();

            return sonuc;
        }
    }
}

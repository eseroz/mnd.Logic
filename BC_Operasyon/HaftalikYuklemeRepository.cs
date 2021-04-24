using mnd.Logic.Helper;
using mnd.Logic.Model.Operasyon;
using System.Collections.ObjectModel;
using System.Linq;

namespace mnd.Logic.BC_Operasyon
{
    public class HaftalikYuklemeRepository
    {
        OperasyonIstatistikDbContext dc = new OperasyonIstatistikDbContext();

        public ObservableCollection<HaftalikYuklemePlan> HaftalikYuklemePlaniGetir(int yil, int haftaId)
        {
            var result = dc.YuklemePlanlari.Where(c => c.HaftaId == haftaId && c.Yil == yil).ToObservableCollection();

            if (result.Count == 0)
            {

                for (int i = 1; i <= 15; i++)
                {
                    var hPlan = new HaftalikYuklemePlan();
                    hPlan.HaftaId = haftaId;
                    hPlan.Yil = yil;
                    hPlan.Sirano = i;

                    dc.YuklemePlanlari.Add(hPlan);
                    dc.SaveChanges();
                }


                var yeniHaftaSonuc = dc.YuklemePlanlari.Where(c => c.HaftaId == haftaId && c.Yil == yil).ToObservableCollection();

                return yeniHaftaSonuc;
            }

            return result;

        }

        public void Kaydet()
        {
            dc.SaveChanges();
        }
    }



}

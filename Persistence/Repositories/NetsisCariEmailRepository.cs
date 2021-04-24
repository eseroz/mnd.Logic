using mnd.Logic.Model.Netsis;
using System.Linq;

namespace mnd.Logic.Persistence.Repositories
{
    public class NetsisCariEmailRepository
    {
        PandapContext dc = new PandapContext();

        public CariEmail CariEmailGetir(int id)
        {
            return dc.CariEmailleri.Where(c => c.Id == id).FirstOrDefault();
        }

        public void Guncelle()
        {
            dc.SaveChanges();
        }

        public void Ekle(CariEmail mail)
        {
            dc.CariEmailleri.Add(mail);
        }
    }
}

using Microsoft.EntityFrameworkCore;
using mnd.Logic.Model.App;
using System.Linq;

namespace mnd.Logic.Persistence.Repositories
{
    public class RaporTanimRepository
    {
        private PandapContext _context;

        public RaporTanimRepository(PandapContext context=null)
        {
            if (context == null) context = new PandapContext();
            _context = context;
        }

        public RaporTanim RaporGetirFromId(int id)
        {
            return _context.RaporTanims.AsNoTracking().First(c => c.Id == id);
        }

        public void RaporTanimKaydet(RaporTanim rp)
        {
            var r = _context.RaporTanims.Find(rp.Id);

            r.RaporAd = rp.RaporAd;
            r.RaporXmlStream = rp.RaporXmlStream;

            _context.SaveChanges();
        }
    }
}
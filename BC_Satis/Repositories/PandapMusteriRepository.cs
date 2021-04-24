using mnd.Logic.BC_Satis.Data;
using mnd.Logic.BC_Satis.Domain;
using mnd.Logic.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mnd.Logic.BC_Satis.Repositories
{
    public class PandapMusteriRepository
    {
        public List<Musteri> PandapMusterileriGetir()
        {
            _SatisDbContext dc = new _SatisDbContext();

            return dc.Musteriler.ToList();
        }

        public IQueryable<Musteri> PandapMusterileriQuery()
        {
            _SatisDbContext dc = new _SatisDbContext();

            return dc.Musteriler.AsQueryable();
        }

        public IQueryable<Musteri> PandapSaticilarQuery()
        {
            PandapContext dc = new PandapContext();

            return dc.CariKart320lar.Select(c => new Musteri
            {
                CariKod = c.CariKod,
                CariIsim = c.CariIsim,
                CariTip = c.CariTip,
                PandaMusteriSorumluKod = c.PlasiyerKod,
                PlasiyerKod = c.PlasiyerKod,
                DovizTipNetsisKod = c.DovizTipNetsisKod,
                DovizAd = c.DovizAd,
                UlkeKod = c.UlkeKod,
                Sektor=c.Sektor
            });
   
        }
    }
}

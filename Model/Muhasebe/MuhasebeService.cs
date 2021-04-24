using System.Collections.Generic;
using System.Linq;

namespace mnd.Logic.Model.Muhasebe
{
    public class MuhasebeService
    {

        MuhasebeDbContext dc = new MuhasebeDbContext();

        public List<FinansalGarantor> FinansalGarantorleriGetir()
        {
            return dc.FinansalGarantorler.ToList();
        }


        public List<DahildeIslemeIzinBelge> DahildeIslemeIzinBelgeleriGetir()
        {
            return dc.DahildeIslemeIzinBelgeleri.ToList();
        }




        public string Diib_SatirKodGetir(DahildeIslemeIzinBelge belge, decimal kalinlik)
        {

            if (kalinlik <= 20) return belge.SatirKod1;
            if (kalinlik <= 200) return belge.SatirKod2;
            if (kalinlik <= 2000) return belge.SatirKod3;

            return "";
        }

        public string Diib_GTipNoGetir(DahildeIslemeIzinBelge belge, decimal kalinlik)
        {

            if (kalinlik <= 20) return belge.GTipNo1;
            if (kalinlik <= 200) return belge.GTipNo2;
            if (kalinlik <= 2000) return belge.GTipNo3;

            return "";
        }



    }
}

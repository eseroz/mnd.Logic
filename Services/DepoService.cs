using mnd.Logic.Persistence;

namespace mnd.Logic.Services
{

    public class DepoService
    {


        public static void PaletDurumDegistir(int paletId, string paletDurum)
        {
            PandapContext dc = new PandapContext();
            var palet = dc.UretimPaletler.Find(paletId);
            palet.PaletKonum = paletDurum;
            dc.SaveChanges();
            dc.Dispose();

        }


    }
}

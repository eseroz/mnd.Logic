using mnd.Logic.Model.Uretim;

namespace mnd.Logic.Services.SiparisService
{
    public class UretimBobinDTO
    {
        public string UretimEmriKod { get; set; }
        public string BobinNo { get; set; }
        public int? Agirlik_kg { get;  set; }
        public Palet PaletNav { get;  set; }


        
    }
}
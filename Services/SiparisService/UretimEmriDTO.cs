using System.Collections.Generic;

namespace mnd.Logic.Services.SiparisService
{
    public class UretimEmriDTO
    {
        public string UretimEmriKod { get; set; }
        public IEnumerable<UretimBobinDTO> BobinlerDTO_List { get;  set; }
        public bool KapatildiMi { get;  set; }
        public int? Uretim_PlanlananMiktar { get; internal set; }
        public int? Uretim_UretimdekiMiktar { get; internal set; }
        public string KartNo { get; internal set; }
        public int? Uretim_PaketlenenMiktar { get; internal set; }
    }
}
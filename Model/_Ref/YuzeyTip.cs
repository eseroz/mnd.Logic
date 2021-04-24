using mnd.Logic.Model.Satis;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace mnd.Logic.Model._Ref
{
    public partial class YuzeyTip
    {
        [Key]
        public string YuzeyKod { get; set; }

        public string Aciklama { get; set; }
        public string Aciklama_EN { get; set; }

        //public ICollection<SiparisKalem> _SiparisKalem { get; set; }
    }
}
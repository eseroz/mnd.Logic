using mnd.Logic.Model.Satis;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace mnd.Logic.Model._Ref
{
    public partial class KullanimAlanTip
    {
        public KullanimAlanTip()
        {
            //_SiparisKalem = new HashSet<SiparisKalem>();
        }

        [Key]
        public string KullanimAlanKod { get; set; }

        public string Aciklama { get; set; }
        public string Aciklama_EN { get; set; }

        public string UretimUrunGrup { get; set; }

        public int AylikTonaj { get; set; }

        //public ICollection<SiparisKalem> _SiparisKalem { get; set; }
    }
}
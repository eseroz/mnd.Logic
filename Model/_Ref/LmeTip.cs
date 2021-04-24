using mnd.Logic.Model.Satis;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace mnd.Logic.Model._Ref
{
    public partial class LmeTip
    {
        public LmeTip()
        {
            //_SiparisKalem = new HashSet<SiparisKalem>();
        }

        [Key]
        public string LmeTipKod { get; set; }

        public string Aciklama { get; set; }
        public int? CiktiSira { get; set; }

        //public ICollection<SiparisKalem> _SiparisKalem { get; set; }
    }
}
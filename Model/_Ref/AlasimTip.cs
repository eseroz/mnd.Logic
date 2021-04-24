using mnd.Logic.Model.Satis;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace mnd.Logic.Model._Ref
{
    public partial class AlasimTip
    {
        public AlasimTip()
        {
            //_SiparisKalem = new HashSet<SiparisKalem>();
        }

        [Key]
        public string AlasimKod { get; set; }

        public string Aciklama { get; set; }

        //public ICollection<SiparisKalem> _SiparisKalem { get; set; }
    }
}
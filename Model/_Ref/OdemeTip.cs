using mnd.Logic.Model.Satis;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace mnd.Logic.Model._Ref
{
    public partial class OdemeTip
    {
        public OdemeTip()
        {
            _Siparis = new HashSet<Siparis>();
        }

        [Key]
        public string OdemeTipKod { get; set; }

        public string Aciklama { get; set; }
        public string Aciklama_En { get; set; }

        public ICollection<Siparis> _Siparis { get; set; }
    }
}
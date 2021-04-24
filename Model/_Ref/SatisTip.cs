using mnd.Logic.Model.Satis;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace mnd.Logic.Model._Ref
{
    public partial class SatisTip
    {
        public SatisTip()
        {
            _Siparis = new HashSet<Siparis>();
        }

        [Key]
        public string SatisTipKod { get; set; }

        public string Aciklama { get; set; }
        public int? NetsisId { get; set; }
        public string OzelKod1 { get; set; }

        public ICollection<Siparis> _Siparis { get; set; }
    }
}
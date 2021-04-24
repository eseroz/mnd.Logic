using mnd.Logic.Model.Satis;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace mnd.Logic.Model._Ref
{
    public partial class TeslimTip
    {
        public TeslimTip()
        {
            _Siparis = new HashSet<Siparis>();
        }

        [Key]
        public string TeslimTipKod { get; set; }

        public string Aciklama { get; set; }
        public string SatisTiptenFiltre { get; set; }
        public int? NetsisId { get; set; }
        public string OzelKod1 { get; set; }
        public int CiktiSira { get; set; }

        public ICollection<Siparis> _Siparis { get; set; }
    }
}
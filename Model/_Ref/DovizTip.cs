using System.ComponentModel.DataAnnotations;

namespace mnd.Logic.Model._Ref
{
    public partial class DovizTip
    {
        [Key]
        public string DovizTipKod { get; set; }

        public string Aciklama { get; set; }
        public string Simge { get; set; }
        public int? NetsisId { get; set; }
    }
}
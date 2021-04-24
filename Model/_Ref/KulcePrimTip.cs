using System.ComponentModel.DataAnnotations;

namespace mnd.Logic.Model._Ref
{
    public partial class KulcePrimTip
    {
        [Key]
        public string KulcePrimTipKod { get; set; }

        public string Aciklama { get; set; }
    }
}
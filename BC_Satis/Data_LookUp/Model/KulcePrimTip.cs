using System.ComponentModel.DataAnnotations;

namespace mnd.Logic.BC_Satis.Data_LookUp.Model
{
    public partial class KulcePrimTip
    {
        [Key]
        public string KulcePrimTipKod { get; set; }

        public string Aciklama { get; set; }
    }
}
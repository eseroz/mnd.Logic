using System.ComponentModel.DataAnnotations;

namespace mnd.Logic.BC_Satis.Data_LookUp.Model
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
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace mnd.Logic.BC_Satis.Data_LookUp.Model
{
    public partial class TeslimTip
    {


        [Key]
        public string TeslimTipKod { get; set; }

        public string Aciklama { get; set; }
        public string SatisTiptenFiltre { get; set; }
        public int? NetsisId { get; set; }
        public string OzelKod1 { get; set; }
        public int CiktiSira { get; set; }

    }
}
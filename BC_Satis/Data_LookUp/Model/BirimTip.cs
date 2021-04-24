using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace mnd.Logic.BC_Satis.Data_LookUp.Model
{
    public partial class BirimTip
    {

        [Key]
        public string BirimTipKod { get; set; }

        public string Aciklama { get; set; }
        public string Aciklama_EN { get; set; }

    }
}
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace mnd.Logic.BC_Satis.Data_LookUp.Model
{
    public partial class AmbalajTip
    {

        [Key]
        public string AmbalajKod { get; set; }

        public string Aciklama { get; set; }
        public string Aciklama_EN { get; set; }

    }
}
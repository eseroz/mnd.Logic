using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace mnd.Logic.BC_Satis.Data_LookUp.Model
{
    public partial class TasimaSekli
    {

        [Key]
        public string TasimaSekliAdi { get; set; }

        public string TasimaSekliAdi_EN { get; set; }
    }
}
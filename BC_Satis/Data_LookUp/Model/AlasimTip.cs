using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace mnd.Logic.BC_Satis.Data_LookUp.Model
{
    public partial class AlasimTip
    {

        [Key]
        public string AlasimKod { get; set; }

        public string Aciklama { get; set; }

        public string Renk { get; set; }

        public string FontRenk { get; set; }
        public decimal? DokumKalinlik { get; set; }

    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mnd.Logic.BC_Satis.Data_LookUp.Model
{
    public class GumrukTip
    {
        [Key]
        public string GumrukTipKod { get; set; }
        public string Aciklama { get; set; }
        public int CiktiSira { get; set; }
        public string GTipSatirKod { get; set; }

    }
}

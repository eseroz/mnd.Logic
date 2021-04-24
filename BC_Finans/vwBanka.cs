using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mnd.Logic.BC_Finans
{
    public class vwBanka
    {
        [Key]
        public Guid ID { get; set; }

        public string CariKod { get; set; }

        public string Firma { get; set; }

        public string DovizAd { get; set; }

        public string HesapTip { get; set; }

        public string AktifPasif { get; set; }

        public string AciklamaTr { get; set; }

        public decimal Bakiye { get; set; }


    }
}

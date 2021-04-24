using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mnd.Logic.BC_SatinAlmaYeni.Domain
{
    public class CariGecici
    {
        [Key]
        public string CariKod { get; set; }
        public string CariAd { get; set; }

        public string DovizTipKod { get; set; }
        public string UlkeKod { get; set; }
        public string PlasiyerKod { get; internal set; }
        public string Sektor { get; internal set; }
    }
}

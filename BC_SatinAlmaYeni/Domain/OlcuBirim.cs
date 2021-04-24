using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mnd.Logic.BC_SatinAlmaYeni.Domain
{
    public class OlcuBirim
    {
        [Key]
        public string BirimKod { get; set; }
        public string BirimAd { get; set; }

    }
}

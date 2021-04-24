using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mnd.Logic.BC_SatinAlmaYeni.Domain
{
    public class Vw_StokMiktarNetsis
    {
        [Key]
        public string StokKod { get; set; }
        public decimal Bakiye { get; set; }
    }
}

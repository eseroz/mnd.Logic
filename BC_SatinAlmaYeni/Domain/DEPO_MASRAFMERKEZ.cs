using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mnd.Logic.BC_SatinAlmaYeni.Domain
{
    public class DEPO_MASRAFMERKEZ
    {
        [Key]
        public string MKOD { get; set; }
        public string MASRAFMERKEZAD { get; set; }
    }
}

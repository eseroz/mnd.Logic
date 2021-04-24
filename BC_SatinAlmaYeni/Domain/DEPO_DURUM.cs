using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mnd.Logic.BC_SatinAlmaYeni.Domain
{
    public class DEPO_DURUM
    {
        [Key]
        public Guid ID { get; set; }
        public string STOKKODU { get; set; }
        public string HUCREKODU { get; set; }

    }
}

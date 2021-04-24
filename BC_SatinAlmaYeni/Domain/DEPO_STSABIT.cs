using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mnd.Logic.BC_SatinAlmaYeni.Domain
{
    public class DEPO_STSABIT
    {
        [Key]
        public string STOK_KODU { get; set; }
        public string STOK_ADI_TR { get; set; }
        public string GRUP_KODU { get; set; }
        public string KOD_1 { get; set; }
        public string KOD_2 { get; set; }
        public string OLCU_BR1 { get; set; }
        public string OLCU_BR2 { get; set; }
    }
}

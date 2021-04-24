using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mnd.Logic.BC_Satis._PotansiyelDisi
{
    public class P_UlkeSabit
    {
        [Key]
        public string UlkeKodu { get; set; }
        public string UlkeAdi { get; set; }
        public string UlkeTelKodu { get; set; }
    }
}

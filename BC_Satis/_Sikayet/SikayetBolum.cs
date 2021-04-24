using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mnd.Logic.BC_Satis._Sikayet
{
    public class SikayetBolum
    {
        [Key]
        public int Id { get; set; }
        public string BolumAd { get; set; }
    }
}

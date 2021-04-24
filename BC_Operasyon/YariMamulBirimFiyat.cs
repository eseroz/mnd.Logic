using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mnd.Logic.BC_Operasyon
{
    public class YariMamulBirimFiyat
    {
        [Key]
        public int Id { get; set; }
        public DateTime? Tarih { get; set; }

        public decimal _1050 { get; set; }
        public decimal _1100 { get; set; }
        public decimal _1200 { get; set; }
        public decimal _3003 { get; set; }
        public decimal _8011 { get; set; }
        public decimal _8079 { get; set; }
        public decimal _8156 { get; set; }
        public decimal _8006F { get; set; }
        public decimal _8006M { get; set; }

     
    }
}

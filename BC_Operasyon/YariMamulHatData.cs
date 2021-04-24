using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mnd.Logic.BC_Operasyon
{
    public class YariMamulHatData
    {
        [Key]
        public int Id { get; set; }
        public DateTime? Tarih { get; set; }

        public int Sirano { get; internal set; }
        public string UpdateUserId { get; set; }

        public string Hat { get; set; }
        public int? _1050 { get; set; }
        public int? _1100 { get; set; }
        public int? _1200 { get; set; }
        public int? _3003 { get; set; }
        public int? _8011 { get; set; }
        public int? _8079 { get; set; }
        public int? _8156 { get; set; }
        public int? _8006F { get; set; }
        public int? _8006M { get; set; }

        public DateTime? SonKayitTarihi { get; set; }

        public int Toplam => _1050.GetValueOrDefault() + _1100.GetValueOrDefault() + _1200.GetValueOrDefault() 
                            + _3003.GetValueOrDefault() + _8011.GetValueOrDefault() + _8079.GetValueOrDefault()
                            + _8156.GetValueOrDefault() + _8006F.GetValueOrDefault() + _8006M.GetValueOrDefault();

    }
}

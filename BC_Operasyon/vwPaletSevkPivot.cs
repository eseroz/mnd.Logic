using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mnd.Logic.BC_Operasyon
{
    public class vwPaletSevkPivot
    {
        [Key]
        public string SevkcariKod { get; set; }
        public int? Yil2017 { get; set; }
        public int? Yil2018 { get; set; }
        public int? Yil2019 { get; set; }
        public int? Yil2020 { get; set; }

        public int? Yil2021 { get; set; }


    }
}

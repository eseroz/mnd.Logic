using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mnd.Logic.BC_Uretim.QueryDTOs
{
    public class UretimEmriKaliteDTO
    {
        [Key]
        public string UretimEmriKod { get; set; }
        public decimal? Kalinlik { get; internal set; }
        public decimal? En { get; internal set; }
        public string Musteri { get; internal set; }
        public string Alasim { get; internal set; }
        public string Kondusyon { get; internal set; }
        public string KartNo { get; internal set; }
    }
}

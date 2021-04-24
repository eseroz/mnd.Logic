using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mnd.Logic.BC_SatinAlmaYeni.Domain
{
    public class Vw_StokAlimFiyatNetsis
    {
        [Key]
        public Guid Id { get; set; }
        public string StokKod { get; set; }
      
        public string Fis_No { get; set; }

        public DateTime IslemTarih { get; set; }
        public string CariKod { get; set; }

        public string CariIsim { get; set; }
        public string DovizTip { get; set; }

        public decimal? BirimFiyat { get; set; }

    }
}

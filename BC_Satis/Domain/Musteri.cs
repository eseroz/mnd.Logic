using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mnd.Logic.BC_Satis.Domain
{
    public class Musteri
    {
        [Key]
        public string CariKod { get; set; }

        public string CariIsim { get; set; }

        public string CariTip { get; set; }

        public string PandaMusteriSorumluKod { get; set; }

        public string PlasiyerKod { get; set; }

        public byte? DovizTipNetsisKod { get; set; }
        public string DovizAd { get; set; }

        public string UlkeKod { get; set; }

        public string Sektor { get; set; }



    }
}

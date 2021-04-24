using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mnd.Logic.Model.Netsis
{
    public partial class CariKart320
    {
        [Key]
        public string CariKod { get; set; }

        public string CariIsim { get; set; }

        public string PlasiyerKod { get; set; }
        public string PlasiyerAd { get; set; }

        public string CariTel { get; set; }
        public string CariIl { get; set; }
        public string UlkeKod { get; set; }
        public string UlkeAd { get; set; }

        public string CariTip { get; set; }
        public string CariAdres { get; set; }
        public string CariIlce { get; set; }
        public string VergiDairesi { get; set; }
        public string VergiNumarasi { get; set; }
        public byte DovizTipNetsisKod { get; set; }
        public string DovizAd { get; set; }

        public string Fax { get; set; }
        public string Email { get; set; }
        public string Web { get; set; }

        public string BagliCariKod { get; set; }
        public string Agent { get; internal set; }


        public string Sektor { get; set; }
    }
}

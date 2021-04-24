using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mnd.Logic.BC_Satis._Teklif
{
    public class TeklifKalem
    {
        [Key]
        public string TeklifKalemSiraKod { get; set; }
        public string TeklifSiraKod { get; set; }

        public string NakliyeDurumTip { get; set; }
        public string UrunKod { get; set; }
        public string TeklifKalemNot { get; set; }
        public DateTime TeslimTarihi { get; set; }
        public decimal SatisFiyati { get; set; }
        public decimal Tutar { get; set; }
        public decimal Miktar { get; set; }
        public string UrunAdiTR { get; set; }
        public string UrunAdiEN { get; set; }
        public decimal GR { get; set; }
        public decimal PCS { get; set; }
        public decimal BOX { get; set; }
        public decimal NETKG { get; set; }
        public decimal GROSS { get; set; }
        public decimal W { get; set; }
        public decimal L { get; set; }
        public decimal H { get; set; }
        public decimal M3 { get; set; }
        public decimal CRTN { get; set; }
        public decimal Butce { get; set; }

        public string TeslimYil { get; set; }
        public string DonemGrup { get; set; }
        public string Donem { get; set; }

   

    }
}

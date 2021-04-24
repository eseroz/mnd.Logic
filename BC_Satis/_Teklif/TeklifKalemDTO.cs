using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mnd.Logic.BC_Satis._Teklif
{
    public class TeklifKalemDTO
    {
        public int TeklifKalemId { get; set; }
        public string TeklifSiraKod { get; set; }
        public string AlasimKod { get; set; }
        public string SertlikKod { get; set; }
        public string KullanimAlanKod { get; set; }
        public string VarsayilanKaydirici { get; set; }
        public string AmbalajTipKod { get; set; }
        public string KalinlikAralik_µm { get; set; }

        public string EnAralik_mm { get; set; }

        public decimal IcCap_mm { get; set; }
        public decimal DisCapMin_mm { get; set; }

        public decimal DisCapMax_mm { get; set; }
        public decimal BirimFiyat { get; set; }
        public decimal MiktarMin { get; set; }

        public decimal ToplamFiyat { get; set; }

        public string NakliyeDurumTip { get; set; }
        public string ProformaUrunKod { get; set; }
        public string ProformaKalinlik_mm { get; set; }
        public string ProformaEn_mm { get; set; }
        public string TeslimYil { get; set; }
        public string DonemGrup { get; set; }
        public string Donem { get; set; }

        public decimal NET_W_ROW_TOTAL { get; set; }
        public decimal GROSS_W_ROW_TOTAL { get; set; }
        public decimal VOLUME_M3_ROW_TOTAL { get; set; }
    }
}

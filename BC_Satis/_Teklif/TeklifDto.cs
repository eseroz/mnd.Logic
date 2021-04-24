using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mnd.Logic.BC_Satis._Teklif
{
    public class TeklifDto
    {
        [Key]
        public string TeklifSiraKod { get; set; }

        public string PlasiyerTeklifSiraKod { get; set; }


        public DateTime TeklifTarih { get; set; }

        public string SatisTemsilcisiAdSoyad { get; set; }


        public DateTime SonGecerlilikTarihi { get; set; }

        public string CariKod { get; set; }

        public string CariAd { get; set; }

        public string CariDovizTipKod { get; set; }

        public string IletisimPersonelAdSoyad { get; set; }

        public string IletisimPersonelMail { get; set; }

        public string TeslimTipKod { get; set; }

        public string TeslimYeri { get; set; }
        public string TeslimNot { get; set; }

        public string TeslimYeriPostaKod { get; set; }

        public string LmeBelirlemeSekli { get; set; }

        public string OdemeSekliKod { get; set; }

        public int SevkYil { get; set; }
        public int SevkHafta { get; set; }

        public int TeslimYil { get; set; }
        public int TeslimHafta { get; set; }

        public string MiktarOlcuBirim { get; set; }

        public string Proforma_HSCODE { get; set; }

        public string TeklifGenelNot { get; set; }

        public string TasimaSekli { get; set; }
        public string GidecegiUlke { get; set; }

        public TeklifDto()
        {
            TeklifKalemler = new List<TeklifKalemDTO>();
        }

        public List<TeklifKalemDTO> TeklifKalemler { get; set; }
    }
}

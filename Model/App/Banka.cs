using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mnd.Logic.Model.App
{
    public class Banka
    {
        [Key]
        public string BankaKod { get; set; }

        public string BankaAd { get; set; }
        public string Sube { get; set; }
        public string Hesap { get; set; }
        public string SubeKodu { get; set; }
        public string ParaCinsi { get; set; }
        public string Iban { get; set; }
        public string SwiftKod { get; set; }
        public string HesapSahibi { get; set; }

        public string BankaHesapListeAd { get; set; }
        public string BankaSablonHtml { get; set; }

        [NotMapped]
        public string BankaRaporCiktiHtml
        {
            get
            {
                if (BankaSablonHtml != null) return BankaSablonHtml;

                return
                    "<div style='font-family:arial;font-size:12px>'" +
                    "<p style='text-decoration:underline; font-weight:bold'>BANK DETAILS :</p>" +
                    $"<strong>{BankaAd}</strong></br>" +
                    $"<strong>Branch :</strong>{Sube}</br>" +
                    $"<strong>Branch Code :</strong>{SubeKodu}</br>" +
                    $"<strong>IBAN {ParaCinsi.ToUpper()}:</strong>{Iban}</br>" +
                    $"<strong>SWIFT CODE :</strong>{SwiftKod}</br>" +
                    $"<strong>BENEFICIARY :</strong>{ HesapSahibi} </br>" +
                    "</div>";
            }
        }

        public bool AktifMi { get; set; }
    }
}
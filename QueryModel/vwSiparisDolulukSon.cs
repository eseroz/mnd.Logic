using System;
using System.ComponentModel.DataAnnotations;

namespace mnd.Logic.QueryModel
{
    public class vwSiparisDolulukSon
    {
        [Key]
        public int Id { get; set; }

        public string CariKod { get; set; }
        public int SevkYili { get; set; }
        public string KalinliklarBirlesik { get; set; }
        public int? KapasiteYil_ton { get; set; }
        public string UrunKod { get; set; }
        public string UlkeKod { get; set; }
        public string UlkeAd { get; set; }
        public string PlasiyerAd { get; set; }
        public string CariIsim { get; set; }
        public string UrunGrubu { get; set; }
        public string AlasimKod { get; set; }
        public decimal? KalinlikMm { get; set; }

        public int ButceToplam
        {
            get
            {
                return B_Ocak.GetValueOrDefault() + B_Subat.GetValueOrDefault() + B_Mart.GetValueOrDefault()
                        + B_Nisan.GetValueOrDefault() + B_Mayis.GetValueOrDefault() + B_Haziran.GetValueOrDefault()
                        + B_Temmuz.GetValueOrDefault() + B_Agustos.GetValueOrDefault() + B_Eylul.GetValueOrDefault()
                        + B_Ekim.GetValueOrDefault() + B_Kasim.GetValueOrDefault() + B_Aralik.GetValueOrDefault();
            }
        }

        public int OlcuToplam
        {
            get
            {
                return O_Ocak.GetValueOrDefault() + O_Subat.GetValueOrDefault() + O_Mart.GetValueOrDefault()
                        + O_Nisan.GetValueOrDefault() + O_Mayis.GetValueOrDefault() + O_Haziran.GetValueOrDefault()
                        + O_Temmuz.GetValueOrDefault() + O_Agustos.GetValueOrDefault() + O_Eylul.GetValueOrDefault()
                        + O_Ekim.GetValueOrDefault() + O_Kasim.GetValueOrDefault() + O_Aralik.GetValueOrDefault();
            }
        }

        public int KapasitifToplam
        {
            get
            {
                return K_Ocak.GetValueOrDefault() + K_Subat.GetValueOrDefault() + K_Mart.GetValueOrDefault()
                        + K_Nisan.GetValueOrDefault() + K_Mayis.GetValueOrDefault() + K_Haziran.GetValueOrDefault()
                        + K_Temmuz.GetValueOrDefault() + K_Agustos.GetValueOrDefault() + K_Eylul.GetValueOrDefault()
                        + K_Ekim.GetValueOrDefault() + K_Kasim.GetValueOrDefault() + K_Aralik.GetValueOrDefault();
            }
        }

        public decimal GerceklesenHedefOran
        {
            get
            {
                if (ButceToplam == 0) return 0;
                return Convert.ToDecimal(OlcuToplam) / Convert.ToDecimal(ButceToplam) * 100;
            }
        }

        public int? B_Ocak { get; set; }
        public int? K_Ocak { get; set; }
        public int? O_Ocak { get; set; }

        public int? B_Subat { get; set; }
        public int? K_Subat { get; set; }
        public int? O_Subat { get; set; }

        public int? B_Mart { get; set; }
        public int? K_Mart { get; set; }
        public int? O_Mart { get; set; }

        public int? B_Nisan { get; set; }
        public int? K_Nisan { get; set; }
        public int? O_Nisan { get; set; }

        public int? B_Mayis { get; set; }
        public int? K_Mayis { get; set; }
        public int? O_Mayis { get; set; }

        public int? B_Haziran { get; set; }
        public int? K_Haziran { get; set; }
        public int? O_Haziran { get; set; }

        public int? B_Temmuz { get; set; }
        public int? K_Temmuz { get; set; }
        public int? O_Temmuz { get; set; }

        public int? B_Agustos { get; set; }
        public int? O_Agustos { get; set; }
        public int? K_Agustos { get; set; }

        public int? B_Eylul { get; set; }
        public int? K_Eylul { get; set; }
        public int? O_Eylul { get; set; }

        public int? B_Ekim { get; set; }
        public int? K_Ekim { get; set; }
        public int? O_Ekim { get; set; }

        public int? B_Kasim { get; set; }
        public int? K_Kasim { get; set; }
        public int? O_Kasim { get; set; }

        public int? B_Aralik { get; set; }
        public int? K_Aralik { get; set; }
        public int? O_Aralik { get; set; }
        public string KullanimAlanTipKod { get; internal set; }
    }
}
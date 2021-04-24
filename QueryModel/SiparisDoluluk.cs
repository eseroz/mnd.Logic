using System.ComponentModel.DataAnnotations;

namespace mnd.Logic.QueryModel
{
    public class SiparisDoluluk
    {
        [Key]
        public int Id { get; set; }

        public int? SevkYili { get; set; }
        public string CariKod { get; set; }
        public string UrunKod { get; set; }

        public string KullanimAlanTipKod { get; set; }
        public int KapasiteYil_ton { get; set; }
        public decimal? KalinlikMm { get; set; }
        public int? OcakButce { get; set; }
        public int? SubatButce { get; set; }
        public int? MartButce { get; set; }
        public int? NisanButce { get; set; }
        public int? MayisButce { get; set; }
        public int? HaziranButce { get; set; }
        public int? TemmuzButce { get; set; }
        public int? AgustosButce { get; set; }
        public int? EylulButce { get; set; }
        public int? EkimButce { get; set; }
        public int? KasimButce { get; set; }
        public int? AralikButce { get; set; }
    }
}
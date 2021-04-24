using System;
using System.ComponentModel.DataAnnotations;

namespace mnd.Logic.Model.App
{
    public partial class Kullanici
    {
        private decimal? mevcutButce;

        [Key]
        public string KullaniciId { get; set; }

        public bool? SahaSorumlusuMu { get; set; }

        public string SatisTeklifUserKod { get; set; }

        public string Email { get; set; }
        public string AdSoyad { get; set; }
        public string KullaniciRol { get; set; }
        public string Parola { get; set; }
        public string BagliKullanicilar { get; set; }
        public string BagliNetsisPlasiyerKodlari { get; set; }
        public string NetsisKullaniciAdi { get; set; }
        public string NetsisParola { get; set; }
        public string Resim { get; set; }
        public DateTime? LastLoginDate { get; set; }

        public string PlasiyerKod { get; set; }
        public bool? AktifMi { get; set; }

        public string YetkiliMakinalar { get; set; }
        public static bool YoneticiMi => false;



        public decimal? MevcutButce { get => mevcutButce; set => mevcutButce = value; }
    }

}
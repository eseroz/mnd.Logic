using System.ComponentModel.DataAnnotations;

namespace mnd.Logic.Model.Netsis
{
    public partial class CariEmail
    {
        public int Id { get; set; }

        [Key]
        public string CariKod { get; set; }
        public string YetkiliKisi { get; set; }
        public string Unvan { get; set; }
        public string Tel { get; set; }
        public string DahiliTel { get; set; }
        public string CepTel { get; set; }
        public string Adres { get; set; }
        public string Email { get; set; }
        public string Birim { get; set; }
    
    }

    public partial class CariEmailYeni : MyBindableBase
    {
        private string birim;
        private string email;
        private string unvan;
        private string durum;

        [Key]
        public int Id { get; set; }

        public string CariKod { get; set; }
        public string YetkiliKisi { get; set; }
        public string Unvan { get => unvan; set => SetProperty(ref unvan, value); }
        public string Tel { get; set; }
        public string DahiliTel { get; set; }
        public string CepTel { get; set; }
        public string Adres { get; set; }
        public string Email { get => email; set => SetProperty(ref email, value); }
        public string Birim { get => birim; set => SetProperty(ref birim, value); }
        public string Durum { get => durum; set => SetProperty(ref durum, value); }
    }
}
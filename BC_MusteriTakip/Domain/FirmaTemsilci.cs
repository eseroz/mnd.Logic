using System.ComponentModel.DataAnnotations;
using mnd.Logic.Model;

namespace mnd.Logic.BC_MusteriTakip.Domain
{
    public class FirmaTemsilci : MyBindableBase
    {
        private string adSoyad;
        private int id;
        private string tel;
        private string email;
        private string unvan;

        [Key]
        public int Id { get => id; set => SetProperty(ref id, value); }
        public string AdSoyad
        {
            get
            {
                return adSoyad;
            }
            set
            {

                SetProperty(ref adSoyad, value);
            }
        }
        public string Tel { get => tel; set => SetProperty(ref tel, value); }
        public string Email { get => email; set => SetProperty(ref email, value); }
        public string Unvan { get => unvan; set => SetProperty(ref unvan, value); }

        public string Birim { get; set; }

        public string CariKod { get; set; }
        public string Adres { get; set; }
        public string UlkeKod { get; set; }
        public string ResimBase64 { get; set; }
        public string RowGuid { get; set; }


    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mnd.Logic.BC_Personel
{
    public class PersonelBilgi
    {
        [Key]
        public string TCKIMLIKNO { get; set; }
        public string ADI { get; set; }
        public string SOYADI { get; set; }

        [NotMapped]
        public string ADSOYAD => ADI + " " + SOYADI;

        public string GOREVTANIMI { get; set; }
        public string UNVAN { get; set; }
        public string GRUP { get; set; }
        public char AKTIF { get; set; }
    }
}

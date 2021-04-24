using System.ComponentModel.DataAnnotations;

namespace mnd.Logic.Model.App
{
    public class KullaniciRol
    {
        [Key]
        public int Id { get; set; }

        public string RolKod { get; set; }
        public string RolAd { get; set; }
        public string VarsayilanMenu { get; set; }
    }
}
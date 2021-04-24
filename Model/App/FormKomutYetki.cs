using System.ComponentModel.DataAnnotations;

namespace mnd.Logic.Model.App
{
    public class FormKomutYetki
    {
        [Key]
        public int Id { get; set; }

        public string FormAd { get; set; }
        public string Komut { get; set; }
        public string YetkiliRoller { get; set; }
    }
}
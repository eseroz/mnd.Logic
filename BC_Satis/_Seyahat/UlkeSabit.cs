using System.ComponentModel.DataAnnotations;

namespace mnd.Logic.BC_Satis._Seyahat
{
    public class UlkeSabit
    {
        [Key]
        public string UlkeKodu { get; set; }
        public string UlkeAdi { get; set; }
        public string UlkeTelKodu { get; set; }
    }
}
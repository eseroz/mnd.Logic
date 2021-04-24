using System.ComponentModel.DataAnnotations;

namespace mnd.Logic.BC_MusteriTakip.Domain
{
    public class Unvan
    {
        [Key]
        public int Id { get; set; }
        public string UnvanTr { get; set; }
        public string UnvanEn { get; set; }


    }
}

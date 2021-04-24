using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mnd.Logic.Model.Muhasebe
{
    public class NetsisCariHareket
    {
        [Key]
        public int ID { get; set; }

        public string CARI_KOD_TR { get; set; }

        public decimal BORC_ { get; set; }

        public decimal ALACAK_ { get; set; }

        [NotMapped]
        public decimal? BAKIYE => BORC_ - ALACAK_;



    }
}

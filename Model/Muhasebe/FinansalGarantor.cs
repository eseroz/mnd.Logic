using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mnd.Logic.Model.Muhasebe
{
    [Table(nameof(FinansalGarantor), Schema = "Muhasebe")]
    public class FinansalGarantor
    {
        [Key]
        public int Id { get; set; }
        public string FinansalGarantorAd { get; set; }
    }


}

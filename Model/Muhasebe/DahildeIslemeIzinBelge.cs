using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mnd.Logic.Model.Muhasebe
{

    [Table(nameof(DahildeIslemeIzinBelge), Schema = "Muhasebe")]
    public class DahildeIslemeIzinBelge
    {
        [Key]
        public int Id { get; set; }
        public string BelgeNo { get; set; }
        public string BelgeAciklama { get; set; }
        public string SatirKod1 { get; set; }
        public string SatirKod2 { get; set; }
        public string SatirKod3 { get; set; }

        public string GTipNo1 { get; set; }
        public string GTipNo2 { get; set; }
        public string GTipNo3 { get; set; }
    }

}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mnd.Logic.BC_SatinAlmaYeni.Domain
{
    [Table(nameof(KullanimYer), Schema = "SatinAlma")]
    public class KullanimYer
    {
        [Key]
        public string KullanimYerKod { get; set; }
        public string KullanimYerAd { get; set; }
        public string IsMerkezi { get; set; }
        public string IsMerkeziAltGrup { get; set; }
    }
}
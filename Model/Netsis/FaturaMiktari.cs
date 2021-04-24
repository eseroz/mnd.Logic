using mnd.Logic.Model.Satis;
using System.ComponentModel.DataAnnotations;

namespace mnd.Logic.Model.Netsis
{
    public class FaturaMiktari
    {
        [Key]
        public string SiparisKalemKod { get; set; }

        public decimal? FaturaMik { get; set; }

        public SiparisKalem SiparisKalemNav { get; set; }
    }
}
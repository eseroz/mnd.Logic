using mnd.Logic.Model;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mnd.Logic.BC_SatinAlmaYeni.Domain
{
    [Table(nameof(StokGrupTanim), Schema = "SatinAlma")]
    public class StokGrupTanim : MyBindableBase
    {
        private string stokGrupAd;

        [Key]
        public string StokGrupKod { get; set; }
        public string StokGrupAd { get => stokGrupAd; set => stokGrupAd = value; }



    }
}
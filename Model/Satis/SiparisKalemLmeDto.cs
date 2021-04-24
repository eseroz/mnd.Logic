using System.ComponentModel.DataAnnotations;

namespace mnd.Logic.Model.Satis
{
    public class SiparisKalemLmeDto
    {
        [Key]
        public string SiparisKalemKod { get; set; }

        public string LmeBaglamaKod { get; set; }
        public string SiparisKod { get; set; }

        public int Miktar_kg { get; set; }
    }
}
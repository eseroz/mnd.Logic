using System.ComponentModel.DataAnnotations;

namespace mnd.Logic.Persistence
{
    public class IsYukuDto
    {
        [Key]
        public string CariKod { get; set; }

        public int ToplamSiparisMiktari { get; set; }
        public int KalanIsYuku { get; set; }
    }
}

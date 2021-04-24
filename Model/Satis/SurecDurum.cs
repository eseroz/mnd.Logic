using System.ComponentModel.DataAnnotations;

namespace mnd.Logic.Model.Satis
{
    public class SurecDurum
    {
        [Key]
        public int Id { get; set; }
        public string SiparisSurecDurum { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;
using mnd.Logic.Model;

namespace mnd.Logic.BC_MusteriTakip.Domain
{
    public class GorusmeTip : MyBindableBase
    {
        private string _ad;

        [Key]
        public int Id { get; set; }
        public string Ad { get => _ad; set => SetProperty(ref _ad, value); }
    }
}

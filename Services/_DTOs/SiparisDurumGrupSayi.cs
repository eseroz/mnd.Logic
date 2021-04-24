using System.ComponentModel.DataAnnotations;
using mnd.Logic.Model;

namespace mnd.Logic.Services._DTOs
{
    public class SqlGrupSayi : MyBindableBase
    {
        private int _siparisDurumSayi;

        [Key]
        public string GrupAd { get; set; }

        public int GrupSayı
        {
            get { return _siparisDurumSayi; }
            set { SetProperty(ref _siparisDurumSayi, value); }
        }
    }
}
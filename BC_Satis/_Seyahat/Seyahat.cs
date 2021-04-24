using mnd.Logic.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mnd.Logic.BC_Satis._Seyahat
{
    public class Seyahat : MyBindableBase
    {
        private string ulkeAd;
        private DateTime? baslangicTarihi;
        private DateTime? bitisTarihi;
        private ObservableCollection<SeyahatGorusme> gorusmeler;

        [Key]
        public int Id { get; set; }
        public DateTime? BaslangicTarihi { get => baslangicTarihi; set => SetProperty(ref baslangicTarihi, value); }
        public DateTime? BitisTarihi { get => bitisTarihi; set => SetProperty(ref bitisTarihi, value); }

        public string UlkeAd { get => ulkeAd; set => SetProperty(ref ulkeAd, value); }
        public string Ekleyen { get; set; }

        public ObservableCollection<SeyahatGorusme> Gorusmeler { get => gorusmeler; set => SetProperty(ref gorusmeler , value); }
    }

}

using mnd.Logic.Model.Satis;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace mnd.Logic.Model.Uretim
{
    public partial class Urun : MyBindableBase
    {
        [Key]
        public string UrunKod { get; set; }

        private string urunGrubu;

        public string UrunGrubu
        {
            get => urunGrubu;
            set => SetProperty(ref urunGrubu, value);
        }

        private string alasimKod;

        public string AlasimKod
        {
            get => alasimKod;
            set => SetProperty(ref alasimKod, value);
        }

        private string yuzeyKod;

        public string YuzeyKod
        {
            get => yuzeyKod;
            set => SetProperty(ref yuzeyKod, value);
        }

        private string kalinlikAralik;

        public string KalinlikAralik
        {
            get => kalinlikAralik;
            set => SetProperty(ref kalinlikAralik, value);
        }

        private int? ciktiSira;
        private string _sertlik;

        public int? CiktiSira
        {
            get => ciktiSira;
            set => SetProperty(ref ciktiSira, value);
        }

        public string Sertlik { get => _sertlik; set => SetProperty(ref _sertlik, value); }

        public Urun()
        {
            SiparisKalem = new HashSet<SiparisKalem>();
        }

        public ICollection<SiparisKalem> SiparisKalem { get; set; }
    }
}
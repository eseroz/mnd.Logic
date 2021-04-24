using mnd.Logic.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mnd.Logic.BC_Satis.Data_LookUp.Model
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

      
    }
}

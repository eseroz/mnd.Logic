using mnd.Logic.BC_Satis._PotansiyelDisi;
using mnd.Logic.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mnd.Logic.BC_App.Domain
{
    public class Kullanici: MyBindableBase
    {
        [Key]
        public string KullaniciId { get; set; }

        public string AdSoyad { get; set; }
        public bool? AktifMi { get; set; }

        public string KullaniciRol { get; set; }

        public string Birim { get; set; }

        public string YetkiliMakinalar { get; set; }

        public string PlasiyerKod { get; set; }



    }
}

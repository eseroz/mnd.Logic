using mnd.Logic.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mnd.Logic.BC_App.Domain
{
    public class DxGridLayout : MyBindableBase
    {
        private string baslik;

        [Key]
        public int Id { get; set; }

        public string GrupAd { get; set; }
        public string Baslik { get => baslik; set => SetProperty(ref baslik, value); }
        public string KullaniciId { get; set; }

        public string XmlData { get; set; }
    }
}
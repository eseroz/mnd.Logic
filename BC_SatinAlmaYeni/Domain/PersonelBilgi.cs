using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mnd.Logic.BC_SatinAlmaYeni.Domain
{
    [Table( name: "PersonelBilgi", Schema = "Personel")]
    public class PersonelBilgi  {      

        [Key]
        public string TcKimlikNo { get; set; }
        public int? OzlukId { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }

        public string AdSoyad => Ad + " " + Soyad;
        public string GorevTanim { get; set; }
        public string Unvan { get; set; }
        public string Grup { get; set; }
        public string Aktif_EH { get; set; }
        public bool? TalepYetkiliMi { get; set; }
        public string IsMerkezi { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace mnd.Logic.BC_PandapForms.DataModels
{
    [Table("FORM_GUNLUK")]
    public class FormGunluk
    {
        [Key]
        public int Id { get; set; }
        public string FormAd { get; set; }
        public DateTime? FormOlusturmaTarihi { get; set; }
        public string DoldurulmaYuzde { get; set; }
        public DateTime? FormGuncellenmeTarihi { get; set; }
        public string YetkiliRoller { get; set; }

        public string OperatorAdSoyad { get; set; }

        public int? BulunanProblemSayisi { get; set; }

    }
}

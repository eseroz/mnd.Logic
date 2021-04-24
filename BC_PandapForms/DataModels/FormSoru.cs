using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace mnd.Logic.BC_PandapForms.DataModels
{
    [Table("FORM_SORU")]
    public class FormSoru
    {
        [Key]
        public int Id { get; set; }
        public string FormAdi { get; set; }
        public string Makina { get; set; }
        public string SoruKod { get; set; }
        public string Soru { get; set; }

        public string SoruOzelAciklama { get; set; }

        public string HtmlKontrolTip { get; set; }
        public string KontrolTip { get; set; }
        public string MinMax { get; set; }
        public bool? ZorunluMu { get; set; }
        public string VarsayılanDeğer { get; set; }
        public string Secenekler { get; set; }

    }
}

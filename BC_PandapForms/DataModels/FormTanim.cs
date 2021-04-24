using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace mnd.Logic.BC_PandapForms.DataModels
{
    [Table("FORM_TANIM")]
    public class FormTanim
    {
        public int Id { get; set; }
        public string FormAdıUzun { get; set; }
        public string FormAd { get; set; }
        public string FormUstBaslik { get; set; }
        public string FormAltBaslik { get; set; }
        public string YetkiliRoller { get; set; }
        public string Periyod { get; set; }


    }
}

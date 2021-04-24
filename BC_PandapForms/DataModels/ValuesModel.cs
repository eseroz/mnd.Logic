using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace mnd.Logic.BC_PandapForms.DataModels
{
    public class ValueModel
    {
        [Key]
        public int Id { get; set; }
        public string Value1 { get; set; }
        public string Value2 { get; set; }
    }
}

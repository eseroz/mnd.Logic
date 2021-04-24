using mnd.Logic.Model.Uretim;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mnd.Logic.BC_Uretim
{
    public class Anakart
    {
        [Key]
        public string AnakartNo { get; set; }

        public DateTime? BaslamaTarihi { get; set; }

        public List<UretimEmri> UretimEmirleri { get; set; }
    }
}

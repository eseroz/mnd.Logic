using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mnd.Logic.BC_App.Domain
{
    public class MailLog
    {
        [Key]
        public int Id { get; set; }
        public string MailAdi { get; set; }
        public DateTime MailGonderimTarihi { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mnd.Logic.BC_App.Domain
{
    public class MailTanim
    {
        [Key]
        public int Id { get; set; }
        public string MailAd { get; set; }

        public string KonuAciklama { get; set; }

        public string Kimlere { get; set; }

        public string GonderenHesap { get; set; }
        public string HesapParola { get; set; }

        public string GunlukMailSaati { get; set; }

        public DateTime GunlukMailGondermeZamani => DateTime.Parse(DateTime.Now.Date.ToShortDateString() + " " + GunlukMailSaati);

    }
}

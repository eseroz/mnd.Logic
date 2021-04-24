using mnd.Logic.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mnd.Logic.BC_Uretim
{
    public class MakinaDurusTanim : MyBindableBase
    {
        [Key]
        public int Id { get; set; }

        private string durusAd;

    
        public string DurusKod { get; set; }
        public string DurusAd { get => durusAd; set => SetProperty(ref durusAd , value); }


        public string DurusKodBirlesik => DurusKod + "-" + DurusAd;
        public string DurusGrup { get; set; }
        public string Guncelleyen { get; set; }
        public DateTime? GuncellenmeTarihi { get; set; }
    }
}

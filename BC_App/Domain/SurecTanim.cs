using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mnd.Logic.BC_App.Domain
{
    [Table("SurecTanim",Schema ="App")]
    public class SurecTanim
    {
        [Key]
        public decimal Id { get; set; }
        public string SurecAd { get; set; }
        public int AdimSira { get; set; }
        public string Adim { get; set; }

        public string YetkiliRoller { get; set; }
        public string YetkiliKullanici { get; set; }
        public int OnayAdim { get; set; }
        public int RetAdim { get; set; }
        public string MetinEklensinMi { get; set; }

        public string SurecAdimKod { get; set; }


        public string IslemCepMesaj { get; set; }


        public string Param1 { get; set; }
        public string Param2 { get; set; }


    }
}

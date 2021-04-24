using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mnd.Logic.BC_Uretim
{
    public class MakinaParca
    {
        [Key]
        public int SatirId { get; set; }
        public int? MakinaKod { get; set; }
        public string MakinaParcaKod { get; set; }
        public string MakinaParcaKodMetin { get; set; }
        public string MakinaParcaAd { get; set; }
        public string ParcaTipKod { get; set; }
        public string Marka { get; set; }
        public string MotorGucuHp { get; set; }
        public decimal? MotorGucuKw { get; set; }

        public int HatHiziYuzde { get; set; }
        public string Akim { get; set; }
        public string AkimTip { get; set; }
        public string Gerilim { get; set; }
        public string Rpm { get; set; }
        public string Frekans { get; set; }
        public string Cosq { get; set; }
    }
}

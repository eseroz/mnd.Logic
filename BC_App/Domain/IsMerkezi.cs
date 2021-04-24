using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mnd.Logic.BC_App.Domain
{
    public class IsMerkezi
    {
        private bool? uretimMakinasiMi = false;
        private bool? levhaYariMamulMu = false;
        private bool? folyoYariMamulMu = false;
        private bool? makinaMi;

        [Key]
        public int Kod { get; set; }

        public int ParentId { get; set; }

        public string Tanim { get; set; }

        public int Seviye { get; set; }

        public string MasrafRehber { get; set; }

        public bool? MakinaMi { get => makinaMi.GetValueOrDefault(); set => makinaMi = value; }

        [NotMapped]
        public string KayitModu { get; set; }


        public bool? UretimMakinasiMi { get => uretimMakinasiMi.GetValueOrDefault(); set => uretimMakinasiMi = value; }
        public bool? LevhaYariMamulMu { get => levhaYariMamulMu.GetValueOrDefault(); set => levhaYariMamulMu = value; }
        public bool? FolyoYariMamulMu { get => folyoYariMamulMu.GetValueOrDefault(); set => folyoYariMamulMu = value; }

        [NotMapped]
        public string YariMamulTip { get; set; }

        [NotMapped]
        public decimal MakinaToplamKwh { get; set; }

    }
}

using mnd.Logic.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mnd.Logic.BC_Uretim.SH_RotaModel
{
    [Table("SH_RotaKart_Faz", Schema = "Uretim")]
    public partial class ShRotaKartFaz:MyBindableBase
    {
        private decimal? ezmeYuzde;

        [Key]
        public int Id { get; set; }

  
        public string ShRotaKartKartNo { get; set; }
        public int? SiraNo { get; set; }
        public string MakinaIslem { get; set; }
        public decimal? EzmeYuzde { get => ezmeYuzde; set => SetProperty(ref ezmeYuzde, value); }
        public decimal? ProsesMax { get; set; }
        public decimal? ProsesMin { get; set; }

        public string ProsesMaxStr { get; set; }
        public string ProsesMinStr { get; set; }

        public string ProsesMetin { get; set; }

        public List<ShRotaKartFazOperasyon> FazOperasyonlar { get; set; }

        public ShRotaKartFaz()
        {
            FazOperasyonlar = new List<ShRotaKartFazOperasyon>();
        }
    }
}
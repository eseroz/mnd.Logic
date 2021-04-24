using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mnd.Logic.BC_Uretim.SH_RotaModel
{
    [Table("SH_RotaKart_DokumBobin", Schema = "Uretim")]
    public partial class ShRotaKartDokumBobin
    {
        [Key]
        public int Id { get; set; }

      
        public string ShRotaKartKartNo { get; set; }
        public int BobinNo { get; set; }
        public int? DokumMiktari { get; set; }
        public decimal? DokumEni { get; set; }
        public string Aciklama { get; set; }
        public int SiraNo { get; set; }
    }
}
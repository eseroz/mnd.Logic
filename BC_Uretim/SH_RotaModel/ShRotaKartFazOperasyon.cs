using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mnd.Logic.BC_Uretim.SH_RotaModel
{
    [Table("Sh_RotaKart_Faz_Operasyon", Schema = "Uretim")]
    public partial class ShRotaKartFazOperasyon
    {
        [Key]
        public int Id { get; set; }

       
        public int ShRotaKartFazId { get; set; }
        public string OperatorAdSoyad { get; set; }
        public int? SiraNo { get; set; }
        public int? Islem { get; set; }
        public decimal? EzmeYuzde { get; set; }
        public DateTime? Tarih { get; set; }
        public DateTime? BaslamaSaati { get; set; }
        public DateTime? BitisSaati { get; set; }
        public string CekilenMiktari { get; set; }
        public string IslemKodu { get; set; }
        public string Ek { get; set; }
        public string EkKodu { get; set; }
        public string Aciklama { get; set; }
    }
}
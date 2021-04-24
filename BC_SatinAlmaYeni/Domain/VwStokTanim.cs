using mnd.Common.EntityHelpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mnd.Logic.BC_SatinAlmaYeni.Domain
{
    public class vwStokTanim : MyBindableBaseLite
    {
        private decimal? bAKIYE;
        private int? satinAlmaSayisi;
        private string sTOKADI_TR;
        private decimal stokToplami_Euro;
        private string hucreKod;

        [Key]
        public string STOK_KODU { get; set; }
        public string STOKADI_TR { get => sTOKADI_TR; set => SetProperty(ref sTOKADI_TR, value); }
        public string OLCU_BR1 { get; set; }




        public string GRUP_KODU { get; set; }
        public string GRUP_AD { get; set; }
        public string KOD1_AD { get; set; }
        public string KOD2_AD { get; set; }
        public string KOD3_AD { get; set; }
        public string KOD4_AD { get; set; }
        public string KOD5_AD { get; set; }


        public decimal? BAKIYE { get => bAKIYE.GetValueOrDefault(); set => bAKIYE = value; }

        public decimal? SonFiyat { get; set; }

        public decimal? ToplamFiyat { get; set; }

        public string DovizTipi { get; set; }

        [NotMapped]
        public decimal StokToplami_Euro { get => stokToplami_Euro; set => SetProperty(ref stokToplami_Euro, value); }

        public int? SatinAlmaSayisi { get => satinAlmaSayisi.GetValueOrDefault(); set => satinAlmaSayisi = value; }

        [NotMapped]
        public string YariMamulTip { get; set; }

        public string HucreKod { get => hucreKod; set => SetProperty(ref hucreKod , value); }
    }
}

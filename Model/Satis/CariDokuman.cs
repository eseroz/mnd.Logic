using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mnd.Logic.Model.Satis
{
    public class CariDokuman
    {
        [Key]
        public int Id { get; set; }

        public string CariKod { get; set; }

        public string DosyaAd { get; set; }
        public Guid RowGuid { get; set; }
        public string Aciklama { get; set; }

        public DateTime Tarih { get; set; }
        public string Ekleyen { get; set; }

        [NotMapped]
        public string DokumanIcerik { get; set; }


    }
}
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mnd.Logic.Model.Satis
{
    [Table(nameof(LmeOrtalamaVeri), Schema = "Satis")]
    public class LmeOrtalamaVeri : MyBindableBase
    {



        [Key]
        public int Id { get; set; }
        public int Yil { get; set; }
        public int Ay { get; set; }
        public int? Ort3M_Usd { get; set; }
        public int? OrtCash_Usd { get; set; }

        public int? Ort3M_Eur { get; set; }
        public int? OrtCash_Eur { get; set; }


        public Guid RowGuid { get; set; }

        private int _mesajSayisi;
        private int _okunmamisMesajSayisi;

        [NotMapped]
        public int MesajSayisi { get => _mesajSayisi; set => SetProperty(ref _mesajSayisi, value); }

        [NotMapped]
        public int OkunmamisMesajSayisi { get => _okunmamisMesajSayisi; set => SetProperty(ref _okunmamisMesajSayisi, value); }

    }
}

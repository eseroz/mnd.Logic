using Newtonsoft.Json;
using mnd.Logic.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mnd.Logic.BC_Kalite.QueryDTOs
{
    public class RedMalzemeDto: MyBindableBase
    {
        private int _mesajSayisi;
        private int _okunmamisMesajSayisi;
        private Guid _rowGuid;

        [Key]
        public int Id { get; set; }
        public string UretimEmriKod { get; set; }
        public DateTime? Tarih { get; set; }
        public double? Vardiya { get; set; }
        public string Operator { get; set; }
        public string KafileNo { get; set; }
        public string BobinNo { get; set; }
        public string MalzemeNo { get; set; }
        public string Alasim { get; set; }
        public string Kondusyon { get; set; }
        public string En { get; set; }
        public string Kalinlik { get; set; }
        public string RedYeri { get; set; }
        public int RedMiktarKg { get; set; }
        public string Musteri { get; set; }
        public string RedNedeni { get; set; }
        public string KaliteTeknisyeni { get; set; }



        [NotMapped]
        [JsonIgnore]
        public int MesajSayisi { get => _mesajSayisi; set => SetProperty(ref _mesajSayisi, value); }

        [NotMapped]
        [JsonIgnore]
        public int OkunmamisMesajSayisi { get => _okunmamisMesajSayisi; set => SetProperty(ref _okunmamisMesajSayisi, value); }

        public Guid RowGuid { get => _rowGuid; set => SetProperty(ref _rowGuid, value); }

    }
}

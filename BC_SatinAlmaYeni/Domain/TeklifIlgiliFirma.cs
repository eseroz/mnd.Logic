using Newtonsoft.Json;
using mnd.Logic.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mnd.Logic.BC_SatinAlmaYeni.Domain
{
    [Table(nameof(TeklifIlgiliFirma), Schema = "SatinAlma")]
    public class TeklifIlgiliFirma : MyBindableBase
    {
        private string fiyatDovizCinsi;
        private string odemeSekli;
        private string nakliyeDurum;
        private int _mesajSayisi;
        private int _okunmamisMesajSayisi;
        private Guid _rowGuid;

        public TeklifIlgiliFirma()
        {
            RowGuid = Guid.NewGuid();
        }

        [Key]
        public int Id { get; set; }
        public int TalepId { get; set; }
        public string CariKod { get; set; }
        public string CariAd { get; set; }
        public string CariMail { get; set; }
        public string CariAdres { get; set; }

        public string DovizTip { get => fiyatDovizCinsi; set => SetProperty(ref fiyatDovizCinsi, value); }
        public string OdemeSekli { get => odemeSekli; set => SetProperty(ref odemeSekli, value); }

        public string NakliyeDurum { get => nakliyeDurum; set => SetProperty(ref nakliyeDurum , value); }

        [NotMapped]
        [JsonIgnore]
        public int MesajSayisi { get => _mesajSayisi; set => SetProperty(ref _mesajSayisi, value); }

        [NotMapped]
        [JsonIgnore]
        public int OkunmamisMesajSayisi { get => _okunmamisMesajSayisi; set => SetProperty(ref _okunmamisMesajSayisi, value); }

        public Guid RowGuid { get => _rowGuid; set => SetProperty(ref _rowGuid, value); }
        public decimal? IndirimMiktari { get; set; }
    }
}

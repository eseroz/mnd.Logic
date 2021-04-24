using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mnd.Logic.Model.App
{
    public class OrtakDilTanim : MyBindableBase
    {
        private int _okunmamisMesajSayisi;
        private int _mesajSayisi;
        private Guid _rowGuid;
        private string ekleyen;
        private DateTime? eklenmeTarihi;
        private string guncelleyen;
        private DateTime? guncellenmeTarihi;
        private string onaylayan;
        private DateTime? onaylanmaTarihi;

        [Key]
        public int Id { get; set; }

        public string Bolum { get; set; }
        public string TanimAd { get; set; }
        public string Tanim { get; set; }


        public string Ekleyen { get => ekleyen; set => SetProperty(ref ekleyen, value); }
        public DateTime? EklenmeTarihi { get => eklenmeTarihi; set => SetProperty(ref eklenmeTarihi, value); }

        public string Guncelleyen { get => guncelleyen; set => SetProperty(ref guncelleyen, value); }
        public DateTime? GuncellenmeTarihi { get => guncellenmeTarihi; set => SetProperty(ref guncellenmeTarihi, value); }

        public string Onaylayan { get => onaylayan; set => SetProperty(ref onaylayan, value); }
        public DateTime? OnaylanmaTarihi { get => onaylanmaTarihi; set => SetProperty(ref onaylanmaTarihi, value); }

        public string EklemeData => Ekleyen + " " + Guncelleyen + " " + Onaylayan;


        [NotMapped]
        [JsonIgnore]
        public int MesajSayisi { get => _mesajSayisi; set => SetProperty(ref _mesajSayisi, value); }

        [NotMapped]
        [JsonIgnore]
        public int OkunmamisMesajSayisi { get => _okunmamisMesajSayisi; set => SetProperty(ref _okunmamisMesajSayisi, value); }

        public Guid RowGuid { get => _rowGuid; set => SetProperty(ref _rowGuid, value); }

    }
}
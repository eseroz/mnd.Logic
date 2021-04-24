using Newtonsoft.Json;
using mnd.Common;
using mnd.Logic.Model;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace mnd.Logic.BC_MusteriTakip.DTOs
{
    public class GorusmeDTO : MyBindableBase
    {
        private int _mesajSayisi;
        private int _okunmamisMesajSayisi;
        private Guid _rowGuid;
        private string musteriGrubu;

        public int Id { get; set; }        
        public string MusteriGrubu { get => musteriGrubu; set => musteriGrubu = value; }
        public DateTime GorusmeTarih { get; set; }
        public string CariIsim { get; set; }
        public string GorusulenKisi { get; set; }
        public string GorusmeKonuTipAd { get; set; }
        public string GorusmeTipAd { get; set; }
        public string GorusmeDetay { get; set; }

        public string PlasiyerKod { get; set; }


        public int GorusmeHafta => CalenderUtil.GetWeekNumberFromDate(GorusmeTarih);

        public string GorusmeAy => GorusmeTarih.ToString("MMMM", CultureInfo.GetCultureInfo("Tr-tr"));


        [NotMapped]
        [JsonIgnore]
        public int MesajSayisi { get => _mesajSayisi; set => SetProperty(ref _mesajSayisi, value); }

        [NotMapped]
        [JsonIgnore]
        public int OkunmamisMesajSayisi { get => _okunmamisMesajSayisi; set => SetProperty(ref _okunmamisMesajSayisi, value); }

        public Guid RowGuid { get => _rowGuid; set => SetProperty(ref _rowGuid, value); }
        public string UlkeKod { get; internal set; }
        public string Ekleyen { get; internal set; }
        public string KullanimAlanTipKod { get; internal set; }
    }
}

using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace mnd.Logic.Model.App
{
    public partial class Ayarlar : MyBindableBase
    {
        public int Id { get; set; }
        public string UygulamaAdi { get; set; }
        public string FirmaAdi { get; set; }
        public Guid? RowGuid { get; set; }

        public int PaketMax_UEmri_yuzde { get; set; }

        public int KapasitiftenSiparisMiktarTolerans_yuzde { get; set; }
        public bool SiparisteRiskLimitKontrolu { get; set; }




        private int _mesajSayisi;
        private int _okunmamisMesajSayisi;

        [NotMapped]
        public int MesajSayisi { get => _mesajSayisi; set => SetProperty(ref _mesajSayisi, value); }

        [NotMapped]
        public int OkunmamisMesajSayisi { get => _okunmamisMesajSayisi; set => SetProperty(ref _okunmamisMesajSayisi, value); }


        public bool ServiceBrokerAktifMi { get; set; }
    }
}
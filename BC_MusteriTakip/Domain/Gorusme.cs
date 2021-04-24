using Newtonsoft.Json;
using mnd.Common;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using mnd.Logic.Model;

namespace mnd.Logic.BC_MusteriTakip.Domain
{
    public class Gorusme : MyBindableBase
    {
        private string _gorusmeDetayi;
        private Guid _rowGuid;
        private int _mesajSayisi;
        private int _okunmamisMesajSayisi;
        private int _gorusmeTipId;
        private int _gorusmeKonuTipId;
        private GorusmeKonuTip _gorusmeKonuTip;
        private GorusmeTip _gorusmeTip;
        private string _gorusulenKisi;
        private string _musteriCariKod;
        private string _cariIsim;
        private string _ulkeKod;
        private string _ulkeAd;
        private string _gorusulenKisiTel;
        private string _gorusulenKisiMail;
        private string _pandaTemsilcisi;
        private string _plasiyerAdSoyad;
        private string _gorusulenKisiUnvan;
        private string _kullanimAlanTipKod;
        private DateTime? _randevuTarih;
        private DateTime _gorusmeTarih;
        private string musteriGrubu;

        [Key]
        public int Id { get; set; }

        public string MusteriGrubu { get => musteriGrubu; set => musteriGrubu = value; }
        public string KullanimAlanTipKod { get => _kullanimAlanTipKod; set => SetProperty(ref _kullanimAlanTipKod, value); }

        public string MusteriCariKod { get => _musteriCariKod; set => SetProperty(ref _musteriCariKod, value); }

        public string CariIsim { get => _cariIsim; set => SetProperty(ref _cariIsim, value); }

        public string UlkeKod { get => _ulkeKod; set => SetProperty(ref _ulkeKod, value); }

        public string UlkeAd { get => _ulkeAd; set => SetProperty(ref _ulkeAd, value); }

        public DateTime GorusmeTarih { get => _gorusmeTarih; set => SetProperty(ref _gorusmeTarih, value); }


        public string PlasiyerAdSoyad { get => _plasiyerAdSoyad; set => SetProperty(ref _plasiyerAdSoyad, value); }

        public string PlasiyerKod { get; set; }

        public int? GorusulenKisiNetsisId { get; set; }

        public string GorusulenKisiUnvan { get => _gorusulenKisiUnvan; set => SetProperty(ref _gorusulenKisiUnvan, value); }
        public string GorusulenKisi { get => _gorusulenKisi; set => SetProperty(ref _gorusulenKisi, value); }
        public string GorusulenKisiTel { get => _gorusulenKisiTel; set => SetProperty(ref _gorusulenKisiTel, value); }


 
        public string GorusulenKisiEmail {
            get => _gorusulenKisiMail; 
            set => SetProperty(ref _gorusulenKisiMail, value);
        }



        public string GorusmeDetay { get => _gorusmeDetayi; set => SetProperty(ref _gorusmeDetayi, value); }

        public int OnemDerecesi { get; set; }

        public DateTime? RandevuTarih { get => _randevuTarih; set => SetProperty(ref _randevuTarih, value); }

        public bool RandevuIptalMi { get; set; }

        [JsonIgnore]
        public string InsertedBy { get; set; }
        [JsonIgnore]
        public DateTime? InsertionDate { get; set; }
        [JsonIgnore]
        public string ModifiedBy { get; set; }
        [JsonIgnore]
        public DateTime? ModifiedDate { get; set; }


        public int GorusmeKonuTipId { get => _gorusmeKonuTipId; set => SetProperty(ref _gorusmeKonuTipId, value); }

        public int GorusmeTipId { get => _gorusmeTipId; set => SetProperty(ref _gorusmeTipId, value); }


        public string Ekleyen { get; set; }

        [JsonIgnore]
        public GorusmeTip GorusmeTip { get => _gorusmeTip; set => SetProperty(ref _gorusmeTip, value); }

        [JsonIgnore]
        public GorusmeKonuTip GorusmeKonuTip { get => _gorusmeKonuTip; set => SetProperty(ref _gorusmeKonuTip, value); }


        public int GorusmeHafta => CalenderUtil.GetWeekNumberFromDate(GorusmeTarih);

        public string GorusmeAy => GorusmeTarih.ToString("MMMM", CultureInfo.GetCultureInfo("Tr-tr"));


        [NotMapped]
        [JsonIgnore]
        public int MesajSayisi { get => _mesajSayisi; set => SetProperty(ref _mesajSayisi, value); }

        [NotMapped]
        [JsonIgnore]
        public int OkunmamisMesajSayisi { get => _okunmamisMesajSayisi; set => SetProperty(ref _okunmamisMesajSayisi, value); }

        public Guid RowGuid { get => _rowGuid; set => SetProperty(ref _rowGuid, value); }

        public string PandaTemsilcisi { get => _pandaTemsilcisi; set => SetProperty(ref _pandaTemsilcisi, value); }
    }
}

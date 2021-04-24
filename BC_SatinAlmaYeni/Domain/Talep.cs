using Newtonsoft.Json;
using mnd.Logic.Model;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mnd.Logic.BC_SatinAlmaYeni.Domain
{
    public class Talep : MyBindableBase
    {
        private string _kullanimYeri;
        private string _talepSurecKonum;
        private ObservableCollection<TeklifIlgiliFirma> teklifIlgiliFirmalar;
        private int ısMerkeziKod;

        private string ısMerkeziAd;
        private string stokGrupAd;
        private int ısMerkeziKod1;
        private string tip;
        private string stokGrupKod;
        private Guid _rowGuid;
        private int _okunmamisMesajSayisi;
        private int _mesajSayisi;
        private string talepNot;
        private bool teklifKararFormGorebilirMi;
        private bool kalemlerSutunSeciliMi;

        [Key]
        public int TalepId { get; set; }

        [NotMapped]
        public bool KalemlerSutunSeciliMi { get => kalemlerSutunSeciliMi; set => SetProperty(ref kalemlerSutunSeciliMi, value); }

        public string Tip { get => tip; set => SetProperty(ref tip, value); }
        public DateTime TalepTarihi { get; set; }
        public string TalepEdenTc { get; set; }

        public string TalepEdenAdSoyad { get; set; }

        public string DepoOnayKisiTc { get; set; }
        public string TalepOnayKisiTc { get; set; }

        public string AciliyetDurum { get; set; }

        public string StokGrupKod { get => stokGrupKod; set => SetProperty(ref stokGrupKod, value); }

        public string StokGrupAd { get => stokGrupAd; set => SetProperty(ref stokGrupAd, value); }


        public int IsMerkeziKod { get => ısMerkeziKod1; set => SetProperty(ref ısMerkeziKod1, value); }
        public string IsMerkeziAd { get => ısMerkeziAd; set => SetProperty(ref ısMerkeziAd, value); }


        public string TalepOnayDurum { get; set; }
        public string TalepDurumSorgu { get; set; }

        public string TalepNot { get => talepNot; set => SetProperty(ref talepNot, value); }



        public Talep()
        {
            TalepKalemler = new ObservableCollection<TalepKalem>();
            TeklifIlgiliFirmalar = new ObservableCollection<TeklifIlgiliFirma>();
        }


        public string OnaylananFirmaKod { get; set; }

        public string OnaylananFirmaAd { get; set; }



        public ObservableCollection<TalepKalem> TalepKalemler { get; set; }
        public ObservableCollection<TeklifIlgiliFirma> TeklifIlgiliFirmalar
        {
            get => teklifIlgiliFirmalar;
            set => SetProperty(ref teklifIlgiliFirmalar, value);
        }



        public string TalepSurecKonum { get => _talepSurecKonum; set => SetProperty(ref _talepSurecKonum, value); }

        public string Ekleyen { get; set; }


        [NotMapped]
        [JsonIgnore]
        public int MesajSayisi { get => _mesajSayisi; set => SetProperty(ref _mesajSayisi, value); }

        [NotMapped]
        [JsonIgnore]
        public int OkunmamisMesajSayisi { get => _okunmamisMesajSayisi; set => SetProperty(ref _okunmamisMesajSayisi, value); }

        public Guid RowGuid { get => _rowGuid; set => SetProperty(ref _rowGuid, value); }
        public string SiparisTeslimSekli { get; set; }
        public string SiparisOdemeSekli { get; set; }
        public int? TeklifNo { get; set; }
        public string SiparisFirmaDovizCinsi { get; set; }

        public DateTime? SiparisTarih { get; set; }

        public string TeklifAtananSatinAlmaPersonel { get; set; }


        [NotMapped]
        public bool TeklifKararFormGorebilirMi { get => teklifKararFormGorebilirMi; set => SetProperty(ref teklifKararFormGorebilirMi, value); }
        public decimal? FirmaIndirimTutar { get; set; }

        [NotMapped]
        public string StokAdlariBirlesik { get;  set; }
    }
}

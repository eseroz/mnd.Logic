using Newtonsoft.Json;
using mnd.Common.Helpers;
using mnd.Logic.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.Linq;

namespace mnd.Logic.BC_Satis._Siparis.Entities
{
    public partial class Siparis : MyBindableBase
    {

        private string siparisKod;

        [Key]
        public string SiparisKod
        {
            get => siparisKod;
            set => SetProperty(ref siparisKod, value);
        }

        private string cariKod;

        [Required(ErrorMessage = "Bu alan girilmesi gereklidir.")]
        public string CariKod
        {
            get => cariKod;
            set => SetProperty(ref cariKod, value);
        }

       
        public DateTime? SiparisTarih { get => _siparisTarih; set => SetProperty(ref _siparisTarih, value); }

        public string SiparisSurecDurum { get; set; }
        public string SiparisSurecDurumOnceki { get; set; }

     
        public int? SevkYil { get; set; }
        public int? SevkHafta { get; set; }
        public int? TeslimYil { get; set; }
        public int? TeslimHafta { get; set; }

        public string TemsilciAdSoyad { get; set; }

        public string SevkYilHafta => SevkYil.GetValueOrDefault().ToString() + "/" + SevkHafta.GetValueOrDefault().ToString().PadLeft(2, '0');

        public string TeslimYilHafta => TeslimYil.GetValueOrDefault().ToString() + "/" + TeslimHafta.GetValueOrDefault().ToString().PadLeft(2, '0');

        public DateTime? SiparisSurecDurumIslemTarih { get; set; }

        [Required(ErrorMessage = "Bu alan girilmesi gereklidir.")]
        public string OdemeTipKod { get; set; }

        private string odemeAciklama;

        public string OdemeAciklama
        {
            get => odemeAciklama;
            set => SetProperty(ref odemeAciklama, value);
        }

        public string FirmaSiparisNo { get; set; }

        private string satisTipKod;

        public string SatisTipKod
        {
            get => satisTipKod;
            set => SetProperty(ref satisTipKod, value);
        }

        private string teslimTipKod;

        [Required(ErrorMessage = "Bu alan girilmesi gereklidir.")]
        public string TeslimTipKod
        {
            get => teslimTipKod;
            set => SetProperty(ref teslimTipKod, value);
        }

        private bool? kapasitifMi;

        public bool? KapasitifMi
        {
            get => kapasitifMi;
            set => SetProperty(ref kapasitifMi, value);
        }

     
        private string faturaDovizTipKod;

        public string FaturaDovizTipKod
        {
            get => faturaDovizTipKod;
            set => SetProperty(ref faturaDovizTipKod, value);
        }

        private decimal? faturaDovizKuru;

        public decimal? FaturaDovizKuru
        {
            get => faturaDovizKuru;
            set => SetProperty(ref faturaDovizKuru, value);
        }


        private string takipDovizTipKod;

        public string TakipDovizTipKod
        {
            get => takipDovizTipKod;
            set => SetProperty(ref takipDovizTipKod, value);
        }

        private decimal? takipDovizKuru;

        public decimal? TakipDovizKuru
        {
            get => takipDovizKuru;
            set => SetProperty(ref takipDovizKuru, value);
        }

   

        public string OzelNot { get; set; }
        public string TeknikOzellikNot { get; set; }
        public string PaketlemeNot { get; set; }
        private string lmeBaglamaNot;

        public string LmeBaglamaNot
        {
            get => lmeBaglamaNot;
            set => SetProperty(ref lmeBaglamaNot, value);
        }

        public string IrsaliyeAdresi { get; set; }

        public string IrsaliyeAdresi2 { get; set; }

        public string FaturaAdresi { get => _faturaAdresi; set => SetProperty(ref _faturaAdresi, value); }

        public string OdemeBankaKod { get => _odemeBankaKod; set => SetProperty(ref _odemeBankaKod, value); }

       

        public string CreatedUserId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string LastEditedBy { get; set; }
        public DateTime? LastEditedDate { get; set; }

        public Guid? RowGuid { get; set; }

        private string ilgiliKapasitifSiparisKod;
        private DateTime? _siparisTarih;
        private string _odemeBankaKod;
        private string _faturaAdresi;
        private string _lmeDurumKod;
        private string _ilgiliNot;
        private bool? _sarjMi;

        public string IlgiliKapasitifSiparisKod
        {
            get => ilgiliKapasitifSiparisKod;
            private set => SetProperty(ref ilgiliKapasitifSiparisKod, value);
        }

        [JsonIgnore]
        [ForeignKey("CariKod")]
        public CariKart CariKartNavigation { get; set; }

        public bool? SiparisAcikMi { get; set; }
    }
}
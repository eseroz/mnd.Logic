using mnd.Logic.Model.Netsis;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace mnd.Logic.Model.Operasyon
{
    [Table(nameof(Irsaliye), Schema = "Operasyon")]
    public class Irsaliye : MyBindableBase
    {
        public Irsaliye()
        {
            IrsaliyePaletler = new ObservableCollection<IrsaliyePalet>();
        }

        [Key]
        public int IrsaliyeId { get; set; }


        public Guid RowGuid { get; set; }

        [NotMapped]
        public int MesajSayisi { get => _mesajSayisi; set => SetProperty(ref _mesajSayisi, value); }

        [NotMapped]
        public int OkunmamisMesajSayisi { get => _okunmamisMesajSayisi; set => SetProperty(ref _okunmamisMesajSayisi, value); }


        public decimal? LmeBirimFiyat
        {
            get => _lmeBirimFiyat.GetValueOrDefault();
            set => SetProperty(ref _lmeBirimFiyat, value);
        }

        public string NetsisIrsaliyeNo { get; set; }

        public DateTime? IrsaliyeTarihi { get; set; }

        private string _finansalGarantorAd;
        private string _dIIB_No;
        private ObservableCollection<IrsaliyePalet> _irsaliyePaletGruplu;
        private int _mesajSayisi;
        private int _okunmamisMesajSayisi;
        private decimal? _lmeBirimFiyat;
        private string faturaKesimCariKod;

        public string CariKod { get; set; }

        [ForeignKey(nameof(CariKod))]
        public CariKart CariKodNav { get; set; }

        public string CariAd { get; set; }

        public string FaturaDovizTip { get; set; }

        public string FaturaDovizTipSimge { get; set; }

        public string FaturaKesimCariKod { get => faturaKesimCariKod; set => SetProperty(ref faturaKesimCariKod,value); }

        public string IhracatFaturaNo { get; set; }

        public DateTime? IhracatFaturaTarih { get; set; }


        public int SevkiyatEmriId { get; set; }

        public string UlasimTip { get; set; }

        public string KontainerNo { get; set; }


        public string FinansalGarantorAd { get => _finansalGarantorAd; set => SetProperty(ref _finansalGarantorAd, value); }

        public string DIIB_No { get => _dIIB_No; set => SetProperty(ref _dIIB_No, value); }

        public string FaturaAdresi { get; set; }
        public string IrsaliyeAdresi1 { get; set; }

        public string IrsaliyeAdresi2 { get; set; }
        public string IrsaliyeAdresi2_Baslik => String.IsNullOrEmpty(IrsaliyeAdresi2) == true ? null : "DELIVERY ADRES 2";

        public string PandaSiparisNoBirlesik { get; set; }

        public string OdemeBankaKod { get; set; }
        public string OdemeBankaAd { get; set; }
        public string OdemeBankaSubeAd { get; set; }
        public string OdemeBankaSubeKod { get; set; }
        public string OdemeBankaIBAN { get; set; }
        public string OdemeBankaSwiftCode { get; set; }
        public string OdemeBankaHakSahip { get; set; }

        [NotMapped]
        public string BankaRaporCiktiHtml { get; set; }


        public string FirmaIlgiliKisiAdSoyad { get; set; }
        public string FirmaIlgiliKisiTel { get; set; }
        public string FirmaIlgiliKisiEposta { get; set; }

        public string TeslimSekli { get; set; }
        public string OdemeSekli { get; set; }

        public string OdemeBankaDovizTip { get; set; }

        public string NetsiseAktarimDurum { get; set; }

        public DateTime? NetsiseAktarimDurumTarih { get; set; }

        public SevkiyatEmri SevkiyatEmriNav { get; set; }

       

       

        public string SiparisKodlariBirlesik => string.Join(";", IrsaliyePaletler.Select(c => c.SiparisKod).Distinct());

        public string FirmaSiparisNoBirlesik => string.Join(";", IrsaliyePaletler.Select(c => c.FirmaSiparisNo).Distinct());




        public ObservableCollection<IrsaliyePalet> IrsaliyePaletler { get; set; }

        [NotMapped]
        public ObservableCollection<IrsaliyePalet> IrsaliyePaletGruplu
        { get => _irsaliyePaletGruplu; set => SetProperty(ref _irsaliyePaletGruplu, value); }



        public int? IrsPaletNet_TKg => IrsaliyePaletler.Sum(p => p.PaletNet_Kg);



        public int? IrsPaletDara_TKg => IrsaliyePaletler.Sum(p => p.PaletDara_Kg);


        public int? IrsPaletBrut_TKg => IrsaliyePaletler.Sum(p => p.PaletBrut_Kg);


        public int IrsPaletSayisi => IrsaliyePaletler.Count();


        public int IrsMasuraSayisi => IrsaliyePaletler.Sum(c => c.MasuraSayisi);




        public decimal IrsaliyeToplamTutar => IrsaliyePaletler.Sum(c => c.PaletGenelToplamTutar);

        public int? FaturaDovizTipNetsisKod { get; set; }

        [NotMapped]
        public string KaliteMetin { get; set; }
    }
}

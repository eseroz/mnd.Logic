using mnd.Common;
using mnd.Logic.Model.Satis;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mnd.Logic.Model.Operasyon
{
    [Table(nameof(IrsaliyePalet), Schema = "Operasyon")]
    public class IrsaliyePalet : MyBindableBase
    {
        private readonly string alan;
        private int _paletDara_Kg;
        private decimal _lmeBF_Ton;
        private decimal _birimFiyat_Kg;
        private bool? _yuklendiMi;

        [Key]
        public int Id { get; set; }
        public int IrsaliyeId { get; set; }
        public string NetsisIrsaliyeNo { get; set; }


        public string AdresNot { get; set; }
        public DateTime StogaGirisTarih { get; set; }

        public int PaletId { get; set; }
        public string PaletGrupKey => FiyatKalemKod + " " + Kalinlik + "x" + En;

        public int FirinNo { get; set; }
        public int TavNo { get; set; }
        public int SehpaNo { get; set; }

        public string UrunKod { get; set; }
        public decimal? Kalinlik { get; set; }
        public decimal? Kalinlik_mm => Kalinlik.GetValueOrDefault() / 1000;

        public decimal? En { get; set; }
        public string Alasim { get; set; }
        public string Sertlik { get; set; }

        public int PaletNet_Kg { get; set; }
        public int PaletDara_Kg { get => _paletDara_Kg; set => SetProperty(ref _paletDara_Kg, value); }

        public int PaletBrut_Kg { get; set; }

        public int PaletSayisi { get; set; }

        public string PaletEbat { get; set; }


        public double Alan
        {
            get
            {
                var alan = RuloAlanHesapHelper.RuloAlanHesapla(PaletNet_Kg, En, MasuraSayisi);

                return alan;
            }
        }

        public string KartNo { get; set; }

        public string UretimEmriKod { get; set; }
        public string FiyatKalemKod { get; set; }

        public string BobinlerBirlesik { get; set; }
        public int MasuraSayisi { get; set; }


        [ForeignKey(nameof(FiyatKalemKod))]
       public SiparisKalem SiparisKalemNav { get; set; }


        // diğer alanlar için

        public string SiparisKod { get; set; }

        public string UrunFaturaAd { get; set; }

        public string UrunFaturaAd_YD { get; set; }



        public decimal IscilikBF_Ton { get; set; }
        public decimal LmeBF_Ton { get => _lmeBF_Ton; set => SetProperty(ref _lmeBF_Ton, value); }


        public decimal PaletToplamTutar { get; set; }
        public decimal PaletKdvTutar { get; set; }
        public decimal PaletGenelToplamTutar { get; set; }

        public string DovizTipKod { get; set; }
        public decimal BirimFiyat_Kg { get => _birimFiyat_Kg; set => SetProperty(ref _birimFiyat_Kg, value); }
        public decimal KdvOran { get; set; }
        public string NetsisStokKod { get; set; }
        public string LfxKod { get; set; }

        public decimal FaturaDovizKur { get; set; }
        public int? NetsisSatisFaturaTipId { get; set; }
        public int? NetsisTeslimTipId { get; set; }
        public int? NetsisDovizTipId { get; set; }
        public string NetsisBirimTipKod { get; set; }

        public string GTip { get; set; }
        public string GTipSatirKod { get; set; }
        public string GTipNo { get; set; }

        public string FirmaSiparisNo { get; set; }
        public string FirmaUrunNo { get; set; }

        [NotMapped]
        public object Ambalaj { get; set; }
        public string Aciklama { get; set; }
        public int? Metraj { get; set; }
        public int? RuloDisCap { get; set; }

        [NotMapped]
        public string CariKod { get; set; }


        public decimal? KulceBF_Ton { get; set; }
        public decimal? IscilikVadeFarkiOran { get; set; }
        public decimal? IscilikVadeFarkiTutar { get; set; }
        public bool? YuklendiMi { get => _yuklendiMi; set => SetProperty(ref _yuklendiMi, value); }

        public void PaletGenelToplamGuncelle()
        {
            var varsayilanBirimFiyat_Kg = (decimal)(LmeBF_Ton + KulceBF_Ton.GetValueOrDefault() + IscilikBF_Ton) / 1000;

            IscilikVadeFarkiTutar = varsayilanBirimFiyat_Kg * (IscilikVadeFarkiOran / 100);  // kdv gibi ekleniyor

            BirimFiyat_Kg = varsayilanBirimFiyat_Kg + IscilikVadeFarkiTutar.GetValueOrDefault();

            BirimFiyat_Kg = Math.Round(BirimFiyat_Kg, 3);

            PaletToplamTutar = BirimFiyat_Kg * PaletNet_Kg;

            PaletKdvTutar = PaletToplamTutar * KdvOran / (decimal)100.0;

            PaletGenelToplamTutar = (PaletToplamTutar + PaletKdvTutar);
        }

    }
}

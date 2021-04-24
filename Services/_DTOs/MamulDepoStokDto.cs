using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using mnd.Logic.Persistence.Repositories;
using mnd.Logic.Model;

namespace mnd.Logic.Services._DTOs
{
    public class MamulDepoStokDto : MyBindableBase
    {
        [Key]
        public int PaletId { get; set; }

        private bool sec;

        [NotMapped]
        public bool Sec
        {
            get => sec;
            set => SetProperty(ref sec, value);
        }

        public int? SevkiyatEmriId { get; set; }
        public string SevkSurecDurum { get; set; }
        public DateTime? DepoKabulTarihi { get; set; }

        public DateTime? SevkiyatTarihi { get; set; }


 
        public string UrunKod { get; set; }

        public string MaliyetStokKod => AlasimTipKod + "-" + SertlikTipKod;

        public String AlasimTipKod { get; set; }
        public String SertlikTipKod { get; set; }
        public string KullanimAlaniTipKod { get; set; }
        public decimal? Kalinlik_micron { get; set; }
        public decimal? En_mm { get; set; }


        public String SiparisKod { get; set; }
        public String SiparisKalemKod { get; set; }
        public String KartNo { get; set; }
        public String BobinlerBirlesik { get; set; }

        public int? FirinNo { get; set; }
        public int? TavNo { get; set; }
        public int? SehpaNo { get; set; }



        public int? PaletNet_Kg { get; set; }
        public int? PaletDara_Kg { get => _paletDara_Kg; set => SetProperty(ref _paletDara_Kg, value); }
        public int? PaletBrut_Kg { get; set; }
        public String PaletEbat { get; set; }

        public string GrupKey { get; set; }

        public int? SevkHafta { get; set; }
        public int? SevkYil { get; set; }

        public string SevkYilHafta { get; set; }

        public string CariKod { get; set; }
        public String CariIsim { get; set; }
        public String UlkeKod { get; set; }
        public String UlkeAd { get; set; }
        public int? StokGunSuresi { get; set; }

        public string FirmaSiparisNo { get; set; }
        public string FirmaUrunNo { get; set; }


        public decimal? FaturaMiktar { get; set; }

        public int? KalemTMiktar { get; set; }
        private string aciklama;

        public string Aciklama
        {
            get => aciklama;
            set => SetProperty(ref aciklama, value);
        }

        private string irsaliyeNo;
        private string _fiyatKalemKod;
        private int? _paletDara_Kg;

        public string NetsisIrsaliyeNo
        {
            get => irsaliyeNo;
            set => SetProperty(ref irsaliyeNo, value);
        }
        public string FiyatKalemKod { get => _fiyatKalemKod; set => SetProperty(ref _fiyatKalemKod, value); }
        public string UretimEmriKod { get; set; }
        public int? Metraj { get; set; }
        public int? RuloIcCap { get; set; }
        public string LfxKod { get; set; }

        public decimal? LmeBF_Ton { get; set; }
        public decimal? IscilikBF_Ton { get; set; }
        public decimal? KulceBF_Ton { get; set; }
        public decimal? IscilikVF_Oran { get; set; }
        public decimal? IscilikVF_Tutar { get; set; }



        public decimal? BirimFiyat_Kg { get; set; }
        public decimal? KdvOran { get; set; }
        public decimal? PaletToplamTutar { get; set; }
        public decimal? PaletKdvTutar { get; set; }
        public decimal? PaletGenelToplam { get; set; }

        public decimal? PaletGenelToplamEuro { get; set; }


        public string GumrukTipKod { get; set; }

        public string GTip { get; set; }
        public string GTipSatirKod { get; set; }


        public string DovizTipKod { get; set; }
        public int? NetsisDovizTipId { get; set; }
        public int? NetsisSatisFaturaTipId { get; set; }
        public int? NetsisTeslimTipId { get; set; }


        public int MasuraSayisi { get; set; }
        public string Agent { get;  set; }
        public string MusteriTemsilcisi { get;  set; }
        public string PaletKonum { get;  set; }
        internal List<BobinInfo> BobinlerTumu { get; set; }
        public string KullanimAlani { get;  set; }
        public string Kalinlik_En { get;  set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using mnd.Logic.Model;

namespace mnd.Logic.Services.SiparisService
{
    public class SiparisDTO : MyBindableBase
    {
        [Key]
        public string SiparisKod { get; set; }

        private DateTime? tarih;

        public DateTime? Tarih
        {
            get => tarih;
            set => SetProperty(ref tarih, value);
        }

        public Guid? RowGuid { get; set; }

        public string TeslimHaftasi { get; set; }
        public string SevkHaftasi { get; set; }

        public string LmeBaglamaDurumu { get; set; }

        private int okunmamisMesajSayisi;

        public int OkunmamisMesajSayisi
        {
            get => okunmamisMesajSayisi;
            set => SetProperty(ref okunmamisMesajSayisi, value);
        }

        public IEnumerable<SiparisKalemDTO> SiparisKalemDTO_List { get; set; }

        public SiparisDTO()
        {
            SiparisKalemDTO_List = new List<SiparisKalemDTO>();
        }

        private string cariKod;

        public string CariKod
        {
            get => cariKod;
            set => SetProperty(ref cariKod, value);
        }

        private string cariIsim;

        public string CariIsim
        {
            get => cariIsim;
            set => SetProperty(ref cariIsim, value);
        }

        private int miktar;

        public int Miktar
        {
            get => miktar;
            set => SetProperty(ref miktar, value);
        }

        public decimal? GenelToplamTutar { get; set; }

        public decimal? GenelToplamTutar_OtoLME { get; set; }


        

        private string plasiyer;

        public int DepodaUrunSayisi { get; set; }

        public string KaydiOlusturan
        {
            get => plasiyer;
            set => SetProperty(ref plasiyer, value);
        }

        public string SiparisSurecDurum { get; set; }

        public string TeknikOzellikNot { get; set; }
        public string PaketlemeNot { get; set; }

        public string UlkeKodIso { get; set; }
        public string GenelToplamTutarKurlu { get; set; }
        public decimal GenelIscilikTutar { get; set; }
        public decimal GenelIscilikVadeFarkiTutar { get; set; }
        public decimal? GenelIscilikTutarOrt { get; set; }
        public int SiparisUretimdekiMiktar { get; set; }
        public decimal SiparisKalanMiktar { get; set; }
        public string KapatisitiflikDurum { get; set; }

        public int MesajSayisi
        {
            get => _mesajSayisi;
            set => SetProperty(ref _mesajSayisi, value);
        }

        public string OdemeNot { get; set; }
        public DateTime? SiparisSurecDurumIslemTarih { get; set; }

        public bool PlanSiparisKapatildiMi { get; set; }
        public int KalemAdet { get; set; }
        public int AktifUretimEmriSayisi { get; set; }
        public int KapatilmisUretimEmriSayisi { get; set; }
        public bool? KapasitifMi { get; set; }

        private int? paketlenenMiktarKg;

        public int? PaketlenenMiktarKg
        {
            get => paketlenenMiktarKg;
            set => SetProperty(ref paketlenenMiktarKg, value);
        }

        public string NetsiseAktarilanKalemSayisi { get; set; }
        public double NetsiseAktarilanKalemOran { get; set; }
        public string FirmaSiparisNo { get; set; }
        public string SiparisSurecDurumOnceki { get; set; }
        public decimal? LmeMaxBagliDeger { get; set; }
        public string BagliLfxKodlari { get; set; }


        public string TemsilciAdSoyad { get; set; }

        public string SevkAyAdi { get; set; }

        private int kalanIsyukuKg;

        public int KalanIsyukuKg
        {
            get => kalanIsyukuKg;
            set => SetProperty(ref kalanIsyukuKg, value);
        }

        public int BobinPaketToplamKg { get; set; }

        private int paketlenenTumMiktarKg;
        private int _mesajSayisi;
        private int _faturaEdilenMiktar;
        private string faturaEdilenHaftalar;

        public int PaketlenenTumMiktarKg
        {
            get => paketlenenTumMiktarKg;
            set => SetProperty(ref paketlenenTumMiktarKg, value);
        }
        public string FaturaDovizCinsi { get; set; }
        public int SiparisUretimBakiye { get; set; }
        public int SiparisUretimPlanlanan { get; set; }

        [NotMapped]
        public int FaturaEdilenMiktar { get => _faturaEdilenMiktar; set => SetProperty(ref _faturaEdilenMiktar, value); }

        [NotMapped]
        public string FaturaEdilenHaftalar { get => faturaEdilenHaftalar; set =>SetProperty(ref faturaEdilenHaftalar, value); }
        public bool? SiparisAcikMi { get; internal set; }
        public int? SevkYil { get; internal set; }
        public int? SevkHafta { get; internal set; }
        public DateTime? SiparisTarih { get; internal set; }
        public int? TeslimYil { get; internal set; }
        public int? TeslimHafta { get; internal set; }
        public string OdemeAciklama { get; internal set; }
        public string FaturaDovizTipSimge { get; internal set; }
        public bool SevkHaftaGectiMi { get;  set; }
        public string LmeDovizTipKod { get; internal set; }
    }
}
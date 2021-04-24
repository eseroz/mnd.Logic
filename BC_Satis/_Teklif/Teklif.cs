using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using mnd.Logic.BC_Satis.Domain;

namespace mnd.Logic.BC_Satis._Teklif
{
    public class Teklif
    {
        private int _okunmamisMesajSayisi1;
        private string donusturulenSiparisKod;

        [Key]
        public string TeklifSiraKod { get; set; }
        public string PlasiyerKod { get; set; }
        public string PlasiyerTeklifSiraKod { get; set; }

        public string BankaHesapKod { get; set; }

        public DateTime TeklifTarih { get; set; }

        public string SatisTemsilcisiAdSoyad { get; set; }

        public string SatisTemsilcisiMail { get; set; }

        public string IletisimKisiUnvan { get; set; }
        public DateTime SonGecerlilikTarihi { get; set; }

        public string CariKod { get; set; }

        [ForeignKey(nameof(CariKod))]

        public string PotansiyelCariAd { get; set; }

        public Musteri MusteriNav { get; set; }

        public string CariAd { get; set; }

        public string CariDovizTipKod { get; set; }

        public int IletisimKisiId { get; set; }

        public string IletisimKisiAdSoyad { get; set; }

        public string IletisimKisiMail { get; set; }

        public string IletisimKisiTel { get; set; }

        public string TeslimTipKod { get; set; }

        public string TeslimYeri { get; set; }
        public string TeslimNot { get; set; }

        public string TeslimYeriPostaKod { get; set; }

        public string LmeBelirlemeSekli { get; set; }

        public string OdemeSekliKod { get; set; }

        public string OdemeSekliDetay { get; set; }

        public int SevkYil { get; set; }
        public int SevkHafta { get; set; }

        public int TeslimYil { get; set; }
        public int TeslimHafta { get; set; }

        public string MiktarOlcuBirim { get; set; }

        public string Proforma_HSCODE { get; set; }

        public string TeklifGenelNot { get; set; }

        public string TasimaSekliAdi_EN { get; set; }

        public string DonusturulenSiparisKod { get => donusturulenSiparisKod; set => donusturulenSiparisKod = value; }

        public Teklif()
        {
            TeklifKalemler = new ObservableCollection<TeklifKalem>();
        }

        public ObservableCollection<TeklifKalem> TeklifKalemler { get; set; }
        public string TeklifDurum { get; set; }

        public string RetNeden { get; set; }
        public string IslemNot { get; set; }

        public string TasimaSekli { get; set; }
        public string GidecegiUlke { get; set; }


        public Guid RowGuid { get; set; }

        public string CreateUserId { get; set; }
        public DateTime? CreateTime { get; set; }
        public string UpdateUserId { get; set; }
        public DateTime? UpdateTime { get; set; }

    }
}
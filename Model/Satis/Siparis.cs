using Newtonsoft.Json;
using mnd.Common.Helpers;
using mnd.Logic.BC_Satis._Teklif;
using mnd.Logic.Model._Ref;
using mnd.Logic.Model.App;
using mnd.Logic.Model.Netsis;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.Linq;

namespace mnd.Logic.Model.Satis
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
        public string IrsaliyeAdresi { get; set; }
        public string IrsaliyeAdresi2 { get; set; }
        public string TeslimSehir { get => teslimSehir; set => teslimSehir = value; }
        public string FaturaAdresi { get => _faturaAdresi; set => SetProperty(ref _faturaAdresi, value); }
        public string OdemeBankaKod { get => _odemeBankaKod; set => SetProperty(ref _odemeBankaKod, value); }
        public string IlgiliNot { get => _ilgiliNot; set => SetProperty(ref _ilgiliNot, value); }
        public string MNDNot { get; set; }

        public string TeklifSiraKod { get => teklifSiraKod; set => SetProperty(ref teklifSiraKod, value); }

        [JsonIgnore]
        [ForeignKey("OdemeBankaKod")]
        public Banka OdemeBankaKodNavigation { get; set; }

        [JsonIgnore]
        [ForeignKey("CariKod")]
        public CariKart CariKartNavigation { get; set; }

        [JsonIgnore]
        [ForeignKey("CariKod")]
        public CariEmail CariEmailNavigation { get; set; }

        [JsonIgnore]
        public OdemeTip OdemeTipKodNavigation { get; set; }

        [JsonIgnore]
        public SatisTip SatisTipKodNavigation { get; set; }

        [JsonIgnore]
        public TeslimTip TeslimTipKodNavigation { get; set; }

        [JsonIgnore]
        [ForeignKey("FaturaDovizTipKod")]
        public DovizTip FaturaDovizTipKodNavigation { get; set; }

        [JsonIgnore]
        [ForeignKey("TakipDovizTipKod")]
        public DovizTip TakipDovizTipKodNavigation { get; set; }

        public string CreatedUserId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string LastEditedBy { get; set; }
        public DateTime? LastEditedDate { get; set; }
        public Guid? RowGuid { get; set; }
        private DateTime? _siparisTarih;
        private string _odemeBankaKod;
        private string _faturaAdresi;
        private string _ilgiliNot;

        private readonly ObservableCollection<SiparisKalem> _siparisKalemleri;
        public IEnumerable<SiparisKalem> SiparisKalemleri => _siparisKalemleri;

        private Siparis()
        {
            this._siparisKalemleri = new ObservableCollection<SiparisKalem>();
        }

        private static Siparis VarsayilanYeniSiparisOlustur()
        {
            var siparis = new Siparis();
            siparis.RowGuid = Guid.NewGuid();
            siparis.SiparisTarih = DateTime.Now.Date;
            siparis.SiparisAcikMi = true;
            siparis.SiparisSurecDurum = mnd.Common.Helpers.SIPARISSURECDURUM.SATISTA;
            siparis.SiparisKod = null;
            siparis.SevkYil = DateTime.Now.Date.Year;
            siparis.TeslimYil = DateTime.Now.Date.Year;
            var num = CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(DateTime.Now.Date, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
            siparis.TeslimHafta = num;
            siparis.SevkHafta = num;
            return siparis;
        }

        public static Siparis SiparisOlustur(string teklifSıraKod, string kullaniciId)
        {
            if (teklifSıraKod.Length > 0)
            {
                TeklifRepository teklifRepo = new TeklifRepository();

                var teklif = teklifRepo.TeklifGetir(teklifSıraKod);

                var yeniSiparis = VarsayilanYeniSiparisOlustur();

                yeniSiparis.CreatedUserId = kullaniciId;

                yeniSiparis.TeklifSiraKod = teklifSıraKod;
                //yeniSiparis.FaturaAdresi
                //yeniSiparis.IrsaliyeAdresi
                //yeniSiparis.IrsaliyeAdresi1
                //yeniSiparis.TemsilciAdSoyad = teklif.


                teklif.TeklifKalemler.ToList().ForEach(teklifKalem =>
                {
                    SiparisKalem yeniSiparisKalem = new SiparisKalem
                    {
                        RowGuid = new Guid(),
                        UrunAdiTR = teklifKalem.UrunAdiTR,
                        UrunAdiEN = teklifKalem.UrunAdiEN,
                        BirimFiyat = teklifKalem.SatisFiyati,
                        Miktar = teklifKalem.Miktar,
                        Tutar = teklifKalem.Tutar,
                        GR = teklifKalem.GR,
                        BOX = teklifKalem.BOX,
                        PCS = teklifKalem.PCS,
                        GROSS = teklifKalem.GROSS,
                        CRTN = teklifKalem.CRTN,
                        NETKG = teklifKalem.NETKG,
                        W = teklifKalem.W,
                        H = teklifKalem.H,
                        L = teklifKalem.L,
                        UrunKod = teklifKalem.UrunKod,
                        SiparisKod = "000",
                        M3 = teklifKalem.M3
                    };

                    yeniSiparis._siparisKalemleri.Add(yeniSiparisKalem);
                });




                return yeniSiparis;
            }
            else
            {
                return new Siparis();
            }
        }

        private static T DeepCopyObject<T>(object o)
        {
            return JsonConvert.DeserializeObject<T>(JsonConvert.SerializeObject((object)o).ToString());
        }

        private int _mesajSayisi;
        private int _okunmamisMesajSayisi;
        private string teslimSehir;
        private string teklifSiraKod;

        [NotMapped]
        public int MesajSayisi { get => _mesajSayisi; set => SetProperty(ref _mesajSayisi, value); }

        [NotMapped]
        public int OkunmamisMesajSayisi { get => _okunmamisMesajSayisi; set => SetProperty(ref _okunmamisMesajSayisi, value); }

        public bool? SiparisAcikMi { get; set; }




    }
}
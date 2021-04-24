using mnd.Common.Helpers;
using mnd.Logic.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mnd.Logic.BC_Dokum.Model
{
    public class DokumBobin : MyBindableBase
    {
        private string alasimTipKod;
        private int? planBobinNo;
        private bool sec;
        private int? reelMiktar;
        private DateTime? reelBitisTarihi;
        private decimal? reelKalinlik;
        private int? reelEn;
        private string shKafileNo;
        private int? shCikisEn;
        private string aciklama;
        private string planlamaNot;
        private int _mesajSayisi;
        private int _okunmamisMesajSayisi;
        private decimal? planKalinlik;
        private string dokumOperatorAdSoyad;
        private DateTime? reelBaslamaTarihi;
        private bool secimiSerbestBirak;
        private string bobinAktifIslem;
        private string nereden;
        private string nereye;
        private string bobinDurum;
        private bool hazirMi;
        private bool calisiyorMu;
        private bool durdurulduMu;
        private bool bittiMi;

        [Key]
        public int Id { get; set; }

        public string DokumOperatorAdSoyad { get => dokumOperatorAdSoyad; set => SetProperty(ref dokumOperatorAdSoyad, value); }

        public int? DH_SatirId { get; set; }
        public string DokumHattiKod { get; set; }
        public string AlasimTipKod { get => alasimTipKod; set => SetProperty(ref alasimTipKod, value); }
        public int? BobinSiraNo { get; set; }
        public DateTime? PlanTarihi { get; set; }
        public int? PlanEn { get; set; }
        public decimal? PlanKalinlik { get => planKalinlik; set => SetProperty(ref planKalinlik, value); }
        public int? PlanMiktar { get; set; }
        public int? PlanBobinNo { get => planBobinNo; set => SetProperty(ref planBobinNo, value); }
        public int? ReelMiktar
        {
            get => reelMiktar;
            set
            {
                SetProperty(ref reelMiktar, value);
                OnPropertyChanged(nameof(RotaKartinaSecilebilirMi));
            }
        }

        public string QrOzet => "www.pandaalu.com" + Environment.NewLine
                        + "Alaşım:" + AlasimTipKod + Environment.NewLine
                        + "BobinNo:" + PlanBobinNo;
        public DateTime? ReelBitisTarihi { get => reelBitisTarihi; set => SetProperty(ref reelBitisTarihi, value); }

        public DateTime? ReelBaslamaTarihi { get => reelBaslamaTarihi; set => SetProperty(ref reelBaslamaTarihi, value); }

        public decimal? ReelKalinlik { get => reelKalinlik; set => SetProperty(ref reelKalinlik, value); }
        public int? ReelEn { get => reelEn; set => SetProperty(ref reelEn, value); }
        public string ShKafileNo { get => shKafileNo; set => SetProperty(ref shKafileNo, value); }
        public int? ShCikisEn { get => shCikisEn; set => SetProperty(ref shCikisEn, value); }
        public string Aciklama { get => aciklama; set => SetProperty(ref aciklama, value); }
        public string PlanlamaNot { get => planlamaNot; set => SetProperty(ref planlamaNot, value); }
        public string AnaKafileNo { get; set; }
        public int PlanBobinNo_Grup { get; set; }

        public bool BaslatabilirMi => this.ReelBaslamaTarihi == null;
        public bool BitirebilirMi => this.ReelBaslamaTarihi != null && this.ReelBitisTarihi == null;

        public bool DurdurabilirMi => this.ReelBaslamaTarihi != null && this.ReelBitisTarihi == null;

        public bool RotaKartinaSecilebilirMi =>
            (ReelMiktar != null && ShKafileNo == null) || (SecimiSerbestBirak == true && ShKafileNo == null);


        [NotMapped]
        public int BobinAdet { get; set; }


        [NotMapped]
        public bool Sec { get => sec; set => SetProperty(ref sec, value); }

        public Guid RowGuid { get; set; }

        [NotMapped]
        public int MesajSayisi { get => _mesajSayisi; set => SetProperty(ref _mesajSayisi, value); }

        [NotMapped]
        public int OkunmamisMesajSayisi { get => _okunmamisMesajSayisi; set => SetProperty(ref _okunmamisMesajSayisi, value); }


        [NotMapped]
        public bool SecimiSerbestBirak
        {
            get => secimiSerbestBirak;
            set
            {
                SetProperty(ref secimiSerbestBirak, value);

                OnPropertyChanged(nameof(RotaKartinaSecilebilirMi));
            }
        }

        public int? EkSayisi { get; set; }
        public string EkNedeni { get; set; }

        public string Kondisyon { get; set; }

        public int ShReceteNihaiKalinlik { get; set; }




        public ObservableCollection<DokumBobinIslemAdim> DokumBobinIslemAdimlari { get; set; }

        public string Nereden { get => nereden; set => SetProperty(ref nereden, value); }

        public string Nereye { get => nereye; set => SetProperty(ref nereye, value); }

        public string BobinKonum { get; set; }

        public string BobinSonrakiIslem => BobinSonrakiAdimGetir()?.MakinaIslem;

        public string BobinAktifIslem => BobinAktifAdimGetir()?.MakinaIslem;

        public DokumBobinIslemAdim AktifAdim => BobinAktifAdimGetir();

        public string GidecegiYerGetir()
        {
            var sonraki = BobinSonrakiAdimGetir().MakinaIslem;

            return sonraki?.Split('/')[0];

        }

        public string BobinIslemDurum { get => bobinDurum; set => SetProperty(ref bobinDurum, value); }
        public DateTime? BobinIslemBaslamaTarihi { get; set; }
        public DateTime? BobinIslemBitisTarihi { get; set; }

        public bool HazirMi => BobinIslemDurum == BOBIN_ISLEMADIM_DURUM.HAZIR;
        public bool CalisiyorMu => BobinIslemDurum == BOBIN_ISLEMADIM_DURUM.ÇALIŞIYOR;
        public bool DurdurulduMu => BobinIslemDurum == BOBIN_ISLEMADIM_DURUM.DURDURULDU;
        public bool BittiMi => BobinIslemDurum == BOBIN_ISLEMADIM_DURUM.BİTTİ;



        public DokumBobinIslemAdim BobinAktifAdimGetir()
        {
            return DokumBobinIslemAdimlari?
                .FirstOrDefault(c => c.AktifMi == true);
        }

        public DokumBobinIslemAdim BobinSonrakiAdimGetir()
        {
            var sonraki = DokumBobinIslemAdimlari?
                 .SkipWhile(c => c.AdimDurum == BOBIN_ISLEMADIM_DURUM.BİTTİ)
                 .Take(1).FirstOrDefault();

            return sonraki;
        }


        public DokumBobin()
        {
            DokumBobinIslemAdimlari = new ObservableCollection<DokumBobinIslemAdim>();

        }

        public string GecenSureStr
        {
            get
            {
                if (BobinIslemBaslamaTarihi == null) return "";
                return GetElapsedTimeString(DateTime.Now - BobinIslemBitisTarihi.GetValueOrDefault());


            }
        }

        public string GetElapsedTimeString(TimeSpan result)
        {
            string elapsedTimeString = string.Format("{0}:{1}:{2}",
                                              result.Hours.ToString("00"),
                                              result.Minutes.ToString("00"),
                                              result.Seconds.ToString("00")
                                             );

            return elapsedTimeString;
        }
    }

}

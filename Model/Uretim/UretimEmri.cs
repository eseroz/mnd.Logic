using mnd.Common.Helpers;
using mnd.Logic.BC_Kalite.Domain;
using mnd.Logic.Model.Satis;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace mnd.Logic.Model.Uretim
{
    public partial class UretimEmri : MyBindableBase
    {
        private string uretimEmriKod;


        [Key]
        public string UretimEmriKod
        {
            get => uretimEmriKod;
            set => SetProperty(ref uretimEmriKod, value);
        }

        public string SiparisKalemKod { get; set; }
        public string KartNo { get => kartNo; set => SetProperty(ref kartNo, value); }

        public string AnaKartNo { get => anaKartNo; set => SetProperty( ref anaKartNo , value); }

        public string Kombinler { get => _kombinler; set => SetProperty(ref _kombinler, value); }
        public double? KombinlerEnToplam { get => _kombinlerEnToplam; set => SetProperty(ref _kombinlerEnToplam, value); }
        public string PlanlamaNot { get => _planlamaNot; set => SetProperty(ref _planlamaNot, value); }
        public string DilmeSeperatorNot { get => _dilmeSeperatorNot; set => SetProperty(ref _dilmeSeperatorNot, value); }

        public string OzelTalimat { get; set; }

        private int? uretim_PlanlananMiktar;

        public int? Uretim_PlanlananMiktar
        {
            get => uretim_PlanlananMiktar;
            set => SetProperty(ref uretim_PlanlananMiktar, value);
        }

        [NotMapped]
        public int? Uretim_PaketlenenMiktar
        {
            get => UretimBobinler.Sum(c => c.Agirlik_kg.GetValueOrDefault());
        }

        public int? KaliteRedMiktar => KaliteRedMalzemeListe.Sum(u => u.RedMiktarKg);
        public int? PaketKarantinaMiktar => UretimPaletler
                                          .Where(plt => plt.PaletKonum == PALETKONUM.KARANTINA)
                                          .Sum(s => s.Bobinler.Sum(bo => bo.Agirlik_kg.GetValueOrDefault()));

        public int? Pas5 { get; set; }
        public int? Pas4 { get; set; }
        public int? Pas3 { get; set; }
        public int? Pas2 { get; set; }
        public int? Pas1 { get; set; }
        public int? FH_Toplam { get; set; }
        public int? Seperator1 { get; set; }
        public int? Seperator2 { get; set; }
        public int? Dilme { get; set; }

        public int? TavaGirecek { get; set; }
        public int? TavdanCikan { get; set; }
        public int? Tavda { get; set; }

        public int? Paketlenecek { get; set; }
        public int? Sp_Dilme_Cikis { get; set; }


        public int? FolyoHaddeToplam
        {
            get => Pas1.GetValueOrDefault()
                + Pas2.GetValueOrDefault()
                + Pas3.GetValueOrDefault()
                + Pas4.GetValueOrDefault()
                + Pas5.GetValueOrDefault();
        }

        public int UretimdekiMiktar
        {
            get
            {
                var sonuc = FolyoHaddeToplam.GetValueOrDefault()
                     + Seperator1.GetValueOrDefault()
                     + Seperator2.GetValueOrDefault()
                     + Dilme.GetValueOrDefault()
                     + TavaGirecek.GetValueOrDefault()
                     + Tavda.GetValueOrDefault()
                     + TavdanCikan.GetValueOrDefault()
                     + Paketlenecek.GetValueOrDefault();
                return sonuc;
            }
        }

        private bool? kapatildiMi;

        public bool? KapatildiMi
        {
            get => kapatildiMi;
            set => SetProperty(ref kapatildiMi, value.GetValueOrDefault());
        }

        public SiparisKalem SiparisKalemKodNav { get; set; }

        public DateTime EklenmeTarih { get; set; }

        private ObservableCollection<Bobin> uretimBobinler;

        public ObservableCollection<Bobin> UretimBobinler
        {
            get => uretimBobinler;
            set => SetProperty(ref uretimBobinler, value);
        }

        private ObservableCollection<Palet> uretimPaletler;
        private string _kombinler;
        private double? _kombinlerEnToplam;
        private string _planlamaNot;
        private string _dilmeSeperatorNot;
        private int _mesajSayisi;
        private int _okunmamisMesajSayisi;
        private string kartNo;
        private string anaKartNo;

        public ObservableCollection<Palet> UretimPaletler
        {
            get => uretimPaletler;
            set => SetProperty(ref uretimPaletler, value);
        }

        public ObservableCollection<UretimEmriRulo> PlanlamaRulolari { get; set; }

        public ObservableCollection<UretimEmriMakineAsama1> MakineAsamalari1 { get; set; }

        public ObservableCollection<UretimEmriMakineAsama2> MakineAsamalari2 { get; set; }

      

        [NotMapped]
        public KaliteStandart KaliteSinirlari { get; set; }

        public string KaliteStandartlari_Json { get; set; }


        public int UretimPlanYuruyen
        {
            get
            {
                
                if (kapatildiMi == true) return 0;

                var y = Uretim_PlanlananMiktar.GetValueOrDefault() 
                    - Uretim_PaketlenenMiktar.GetValueOrDefault() - KaliteRedMiktar.GetValueOrDefault();
                    
                return y < 0 ? 0 : y;
                  
            }
        }

        public DateTime? SonPaketlenmeTarihi => UretimPaletler.OrderByDescending(p => p.Id).FirstOrDefault()?.DepoOnayaGonderimTarihi;
    

        public Guid RowGuid { get; set; }

        [NotMapped]
        public int MesajSayisi { get => _mesajSayisi; set => SetProperty(ref _mesajSayisi, value); }

        [NotMapped]
        public int OkunmamisMesajSayisi { get => _okunmamisMesajSayisi; set => SetProperty(ref _okunmamisMesajSayisi, value); }
        public ObservableCollection<KaliteRedMalzeme> KaliteRedMalzemeListe { get;  set; }


        // verim için
        public int? MaxKombinEni { get; set; }
        public int? KombinMiktari_kg { get; set; }
        //

        public DateTime? KapatilmaTarihi { get; set; }
      

        public UretimEmri()
        {
            RowGuid = Guid.NewGuid();

            UretimBobinler = new ObservableCollection<Bobin>();
            UretimPaletler = new ObservableCollection<Palet>();
            PlanlamaRulolari = new ObservableCollection<UretimEmriRulo>();
            KaliteRedMalzemeListe = new ObservableCollection<KaliteRedMalzeme>();
            MakineAsamalari1 = new ObservableCollection<UretimEmriMakineAsama1>();
            MakineAsamalari2 = new ObservableCollection<UretimEmriMakineAsama2>();

            KapatildiMi = false;

        }
    }
}
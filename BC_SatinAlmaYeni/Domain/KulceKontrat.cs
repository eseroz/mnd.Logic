using Newtonsoft.Json;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using mnd.Logic.Model;

namespace mnd.Logic.BC_SatinAlmaYeni.Domain
{

    public class KulceKontrat : MyBindableBase
    {
        private decimal prim;
        private decimal lmeBF;
        private string cariKod;
        private string cariAd;
        private string dovizTip;
        private decimal toplamTutar;
        private decimal kalanKontratTon;
        private ObservableCollection<KulceKontratDonem> kulceKontratDonemler;
        private int? toplamGelenMiktarTon;
        private decimal tamamlanmaYuzde;
        private string kontratNo;
        private DateTime kontratTarihi;
        private int miktarTon;
        private string partiDonem;
        private string vergiDurum;
        private int _okunmamisMesajSayisi1;

        [Key]
        public int Id { get; set; }
        public string KontratNo { get => kontratNo; set => SetProperty(ref kontratNo, value); }
        public DateTime KontratTarihi { get => kontratTarihi; set => SetProperty(ref kontratTarihi, value); }
        public string CariKod { get => cariKod; set => SetProperty(ref cariKod, value); }

        public string CariIsim { get => cariAd; set => SetProperty(ref cariAd, value); }
        public string DovizTip { get => dovizTip; set => SetProperty(ref dovizTip, value); }

        public KulceKontrat()
        {
            KulceKontratDonemler = new ObservableCollection<KulceKontratDonem>();
        }

        public int MiktarTon { get => miktarTon; set => SetProperty(ref miktarTon, value); }

        public int? ToplamFiiliGelenMiktarTon { get => toplamGelenMiktarTon; set => SetProperty(ref toplamGelenMiktarTon, value); }


        public int PartiDonemYil { get; set; }

        public int PartiDonemAy { get; set; }

        public int PartiDonemBaslangicAy { get; set; }
        

        public string VergiDurum { get => vergiDurum; set => SetProperty(ref vergiDurum , value); }
        public decimal Prim
        {
            get => prim; set
            {
                SetProperty(ref prim, value);
                HesaplamariAta();
            }
        }
        public decimal LmeBF
        {
            get => lmeBF; set
            {
                SetProperty(ref lmeBF, value);
                HesaplamariAta();
            }
        }

        public decimal TamamlanmaYuzde
        {
            get
            {
                ToplamFiiliGelenMiktarTon = (KulceKontratDonemler == null ? 0 :
                    KulceKontratDonemler.SelectMany(p => p.KulceProformalar)
                    .Sum(c => c.FiiliGelenMiktarTon));

                KalanKontratTon = MiktarTon - ToplamFiiliGelenMiktarTon.GetValueOrDefault();

              
                return 100 - KalanKontratTon / MiktarTon * 100;
            }
        }

        public decimal ToplamTutar { get => toplamTutar; set => SetProperty(ref toplamTutar, value); }

        public decimal KalanKontratTon { get => kalanKontratTon; set => SetProperty(ref kalanKontratTon, value); }

        public ObservableCollection<KulceKontratDonem> KulceKontratDonemler { get => kulceKontratDonemler; set => SetProperty(ref kulceKontratDonemler, value); }


        public Guid RowGuid { get; set; }

        [JsonIgnore]
        [NotMapped]
        public int MesajSayisi { get; set; }

        [JsonIgnore]
        [NotMapped]
        public int OkunmamisMesajSayisi { get => _okunmamisMesajSayisi1; set => SetProperty(ref _okunmamisMesajSayisi1, value); }
        public string Ekleyen { get; set; }

        public void HesaplamariAta()
        {
            OnPropertyChanged(nameof(TamamlanmaYuzde));
        }

    }
}

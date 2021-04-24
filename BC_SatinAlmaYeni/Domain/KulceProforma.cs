using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using mnd.Logic.Model;

namespace mnd.Logic.BC_SatinAlmaYeni.Domain
{
    public class KulceProforma : MyBindableBase
    {
        private DateTime proformaTarih;
        private int miktarTon;
        private string proformaNo;
        private decimal lmeTon_BF;
        private decimal primTon_BF;
        private decimal kulceTon_BF;
        private decimal proformaTutari;
        private int fiiliGelenMiktarTon;
        private DateTime? fiiliGelenTarih;
        private string nakliyeFirmaAd;
        private string nakliyeFaturaNo;
        private decimal? fiilLmeTon_BF;
        private decimal? fiilPrimTon_BF;
        private decimal parite;
        private decimal kontango;
        private string dovizTip;
        private DateTime? pariteTarih;
        private int _okunmamisMesajSayisi1;
        private decimal metalBulletin;

        [Key]
        public int Id { get; set; }
        public int KulceKontratDonemId { get; set; }

        public DateTime ProformaTarih { get => proformaTarih; set => SetProperty(ref proformaTarih, value); }
        public string ProformaNo { get => proformaNo; set => SetProperty(ref proformaNo, value); }

        public int MiktarTon
        {
            get => miktarTon; set
            {
                SetProperty(ref miktarTon, value);
                HesaplamalariYap();
            }
        }


        public decimal MetalBulletin
        {
            get => metalBulletin; set
            {
                SetProperty(ref metalBulletin, value);
                HesaplamalariYap();
            }
        }

        public decimal LmeTon_BF
        {
            get => lmeTon_BF; 
            set
            {
                SetProperty(ref lmeTon_BF, value);
                HesaplamalariYap();

            }
        }
        public decimal PrimTon_BF
        {
            get => primTon_BF; set
            {
                SetProperty(ref primTon_BF, value);
                HesaplamalariYap();
            }
        }

        public string DovizTip { get => dovizTip; set => SetProperty(ref dovizTip, value); }
        public decimal Kontango
        {
            get => kontango;
            set
            {
                SetProperty(ref kontango, value);
                HesaplamalariYap();
            }
        }
        public decimal Parite
        {
            get => parite;
            set
            {
                SetProperty(ref parite, value);
                HesaplamalariYap();
            }
        }


        public DateTime? PariteTarih { get => pariteTarih; set => SetProperty(ref pariteTarih, value); }

        public decimal LmeDovizTipBF
        {
            get
            {
                if (Parite == 0) return 0;
                var tutar = (LmeTon_BF + Kontango) / Parite;
                return Math.Round(tutar, 2);
            }
        }

        public decimal PrimDovizTipBF
        {
            get
            {
                if (Parite == 0) return 0;
                var tutar = (PrimTon_BF+ MetalBulletin) / Parite;
                return Math.Round(tutar, 2);
            }
        }

        public decimal KulceDovizTipBF
        {
            get
            {
                if (parite == 0) return 0;
                var tutar = (LmeTon_BF + PrimTon_BF + Kontango + MetalBulletin) / parite;

                return Math.Round(tutar, 2);
            }
        }

        public decimal ProformaDovizTipToplamTutar => MiktarTon * KulceDovizTipBF;



        public void HesaplamalariYap()
        {

            OnPropertyChanged(nameof(KulceDovizTipBF));
            OnPropertyChanged(nameof(LmeDovizTipBF));
            OnPropertyChanged(nameof(PrimDovizTipBF));
            OnPropertyChanged(nameof(ProformaDovizTipToplamTutar));



            OnPropertyChanged(nameof(FiilKulceTon_BF));
            OnPropertyChanged(nameof(FiilProformaTutari));

            OnPropertyChanged(nameof(FarkMiktar));
            OnPropertyChanged(nameof(FarkTutar));
        }




        public int FiiliGelenMiktarTon
        {
            get => fiiliGelenMiktarTon;
            set
            {
                SetProperty(ref fiiliGelenMiktarTon, value);
                HesaplamalariYap();
            }
        }

        public DateTime? FiiliGelenTarih { get => fiiliGelenTarih; set => SetProperty(ref fiiliGelenTarih, value); }
        public string NakliyeFirmaAd { get => nakliyeFirmaAd; set => SetProperty(ref nakliyeFirmaAd, value); }
        public string NakliyeFaturaNo { get => nakliyeFaturaNo; set => SetProperty(ref nakliyeFaturaNo, value); }


        public decimal? FiilLmeTon_BF
        {
            get => fiilLmeTon_BF;
            set
            {
                SetProperty(ref fiilLmeTon_BF, value);
                HesaplamalariYap();
            }
        }
        public decimal? FiilPrimTon_BF
        {
            get => fiilPrimTon_BF;
            set
            {
                SetProperty(ref fiilPrimTon_BF, value);
                HesaplamalariYap();
            }
        }

        public decimal FiilKulceTon_BF
        {
            get
            {
                return (FiilLmeTon_BF.GetValueOrDefault() + FiilPrimTon_BF.GetValueOrDefault());
            }
        }

        public decimal? FiilProformaTutari => FiiliGelenMiktarTon * (FiilLmeTon_BF + FiilPrimTon_BF);

        public int FarkMiktar => FiiliGelenMiktarTon - MiktarTon;
        public decimal FarkTutar => FiilProformaTutari.GetValueOrDefault() - ProformaDovizTipToplamTutar;




        [JsonIgnore]
        [NotMapped]
        public int MesajSayisi { get; set; }

        [JsonIgnore]
        [NotMapped]
        public int OkunmamisMesajSayisi { get => _okunmamisMesajSayisi1; set => SetProperty(ref _okunmamisMesajSayisi1, value); }

        public Guid RowGuid { get; set; }
        public string Ekleyen { get; set; }

    }
}

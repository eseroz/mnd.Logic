using System;
using System.ComponentModel.DataAnnotations;

namespace mnd.Logic.Model.Operasyon
{
    public class NetsisRiskSon1 : MyBindableBase
    {
        [Key]
        public int P_Id { get; set; }

        public string CariKod { get; set; }
        public string PandapCari { get; set; }
        public decimal? PandaFaturaToplam { get; set; }
        public decimal? SeherliFaturaToplam { get; set; }

        private decimal? d_Bakiye;

        public decimal? D_Bakiye
        {
            get => d_Bakiye;
            set => SetProperty(ref d_Bakiye, value);
        }

        private string dovizTuru;

        public String DovizTuru
        {
            get => dovizTuru;
            set => SetProperty(ref dovizTuru, value);
        }

        private decimal? kullanilabilirRisk;

        public decimal? KullanilabilirRisk
        {
            get
            {
                return kullanilabilirRisk;
            }
            set => SetProperty(ref kullanilabilirRisk, value);
        }

        public decimal? Cek_Asil_Riski { get; set; }
        public decimal? Cek_Ciro_Riski { get; set; }
        public decimal? Teminat { get; set; }

        private decimal? riskLimiti;

        public decimal? RiskLimiti
        {
            get => riskLimiti;
            set
            {
                if (SetProperty(ref riskLimiti, value))
                {
                    OnPropertyChanged(nameof(KullanilabilirLimit));
                };
            }
        }

        private decimal? p_Yonetim;

        public decimal? P_Yonetim
        {
            get => p_Yonetim;
            set
            {
                if (SetProperty(ref p_Yonetim, value))
                {
                    OnPropertyChanged(nameof(KullanilabilirLimit));
                };
            }
        }

        public decimal? Bakiye { get; set; }

        public decimal? BakiyeTek
        {
            get
            {
                return DovizTuru == "TL" ? Bakiye.GetValueOrDefault() : D_Bakiye.GetValueOrDefault();
            }
        }

        public string AliciKod { get; set; }
        public string TicaretSicilNo { get; set; }

        private decimal? p_SeherliLimit;

        public decimal? P_SeherliLimit
        {
            get => p_SeherliLimit;
            set
            {
                if (SetProperty(ref p_SeherliLimit, value))
                {
                    OnPropertyChanged(nameof(KullanilabilirLimit));
                };
            }
        }

        private decimal? p_EximLimit;

        public decimal? P_EximLimit
        {
            get => p_EximLimit;
            set
            {
                if (SetProperty(ref p_EximLimit, value))
                {
                    OnPropertyChanged(nameof(KullanilabilirLimit));
                };
            }
        }

        private decimal? p_GarantiFactoring;

        public decimal? P_GarantiFactoring
        {
            get => p_GarantiFactoring;
            set
            {
                if (SetProperty(ref p_GarantiFactoring, value))
                {
                    OnPropertyChanged(nameof(KullanilabilirLimit));
                };
            }
        }

        private decimal? p_IngFactoring;

        public decimal? P_IngFactoring
        {
            get => p_IngFactoring;
            set
            {
                if (SetProperty(ref p_IngFactoring, value))
                {
                    OnPropertyChanged(nameof(KullanilabilirLimit));
                };
            }
        }

        private decimal? p_DBS_Limit;

        public decimal? P_DBS_Limit
        {
            get => p_DBS_Limit;
            set
            {
                if (SetProperty(ref p_DBS_Limit, value))
                {
                    OnPropertyChanged(nameof(KullanilabilirLimit));
                };
            }
        }

        private decimal? p_Teminat;

        public decimal? P_Teminat
        {
            get => p_Teminat;
            set
            {
                if (SetProperty(ref p_Teminat, value))
                {
                    OnPropertyChanged(nameof(KullanilabilirLimit));
                };
            }
        }

        private decimal? p_Ipotek;

        public decimal? P_Ipotek
        {
            get => p_Ipotek;
            set
            {
                if (SetProperty(ref p_Ipotek, value))
                {
                    OnPropertyChanged(nameof(KullanilabilirLimit));
                };
            }
        }

        public decimal? ToplamLimit
        {
            get
            {
                return
                       P_DBS_Limit.GetValueOrDefault()
                     + P_EximLimit.GetValueOrDefault()
                     + P_GarantiFactoring.GetValueOrDefault()
                     + P_IngFactoring.GetValueOrDefault()
                     + P_Teminat.GetValueOrDefault()
                     + P_SeherliLimit.GetValueOrDefault()
                     + P_Ipotek.GetValueOrDefault()
                     + p_Yonetim.GetValueOrDefault()
                     ;
            }
        }

        public decimal? KullanilabilirLimit
        {
            get
            {
                OnPropertyChanged(nameof(ToplamLimit));
                return
                    BakiyeTek -
                    (
                    P_DBS_Limit.GetValueOrDefault()
                    + P_EximLimit.GetValueOrDefault()
                    + P_GarantiFactoring.GetValueOrDefault()
                    + P_IngFactoring.GetValueOrDefault()
                    + P_Teminat.GetValueOrDefault()
                    + P_SeherliLimit.GetValueOrDefault()
                    + P_Ipotek.GetValueOrDefault()
                    + p_Yonetim.GetValueOrDefault()
                    )
                    ;
            }
        }
    }
}
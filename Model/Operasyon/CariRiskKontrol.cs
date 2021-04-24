using System.ComponentModel.DataAnnotations;

namespace mnd.Logic.Model.Operasyon
{
    public class CariRiskKontrol : MyBindableBase
    {
        [Key]
        public int Id { get; set; }

        public string CariKod { get; set; }
        public string AliciKod { get; set; }
        public string TicaretSicilNo { get; set; }

        private decimal? p_SeherliLimit;

        public decimal? P_SeherliLimit
        {
            get => p_SeherliLimit;
            set => SetProperty(ref p_SeherliLimit, value);
        }

        private decimal? p_Yonetim;

        public decimal? P_Yonetim
        {
            get => p_Yonetim;
            set => SetProperty(ref p_Yonetim, value);
        }

        private decimal? p_EximLimit;

        public decimal? P_EximLimit
        {
            get => p_EximLimit;
            set => SetProperty(ref p_EximLimit, value);
        }

        private decimal? p_GarantiFactoring;

        public decimal? P_GarantiFactoring
        {
            get => p_GarantiFactoring;
            set => SetProperty(ref p_GarantiFactoring, value);
        }

        private decimal? p_IngFactoring;

        public decimal? P_IngFactoring
        {
            get => p_IngFactoring;
            set => SetProperty(ref p_IngFactoring, value);
        }

        private decimal? p_DBS_Limit;

        public decimal? P_DBS_Limit
        {
            get => p_DBS_Limit;
            set => SetProperty(ref p_DBS_Limit, value);
        }

        private decimal? p_Teminat;

        public decimal? P_Teminat
        {
            get => p_Teminat;
            set => SetProperty(ref p_Teminat, value);
        }

        private decimal? p_Ipotek;

        public decimal? P_Ipotek
        {
            get => p_Ipotek;
            set => SetProperty(ref p_Ipotek, value);
        }
    }
}
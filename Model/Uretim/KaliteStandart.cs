using System.ComponentModel.DataAnnotations;

namespace mnd.Logic.Model.Uretim
{
    public class KaliteStandart : MyBindableBase
    {
        [Key]
        public int Id { get; set; }

        public string AlasimKod { get; set; }
        public string KondisyonKod { get; set; }
        public string KullanimAlanlari { get; set; }
        public string KalinlikAralik { get; set; }

        private string kB_Si_Yuzde_Range;

        public string KB_Si_yuzde_range
        {
            get => kB_Si_Yuzde_Range;
            set => SetProperty(ref kB_Si_Yuzde_Range, value);
        }

        private string kB_Fe_Yuzde_Range;

        public string KB_Fe_yuzde_range
        {
            get => kB_Fe_Yuzde_Range;
            set => SetProperty(ref kB_Fe_Yuzde_Range, value);
        }

        private string kB_Cu_Yuzde_Range;

        public string KB_Cu_yuzde_range
        {
            get => kB_Cu_Yuzde_Range;
            set => SetProperty(ref kB_Cu_Yuzde_Range, value);
        }

        private string kB_Mn_Yuzde_Range;

        public string KB_Mn_yuzde_range
        {
            get => kB_Mn_Yuzde_Range;
            set => SetProperty(ref kB_Mn_Yuzde_Range, value);
        }

        private string kB_Ti_Yuzde_Range;

        public string KB_Ti_yuzde_range
        {
            get => kB_Ti_Yuzde_Range;
            set => SetProperty(ref kB_Ti_Yuzde_Range, value);
        }

        private string kB_Zn_Yuzde_Range;

        public string KB_Zn_yuzde_range
        {
            get => kB_Zn_Yuzde_Range;
            set => SetProperty(ref kB_Zn_Yuzde_Range, value);
        }

        private string kB_Mg_Yuzde_Range;

        public string KB_Mg_yuzde_range
        {
            get => kB_Mg_Yuzde_Range;
            set => SetProperty(ref kB_Mg_Yuzde_Range, value);
        }

        private string kB_Pb_Ppm_Range;

        public string KB_Pb_ppm_range
        {
            get => kB_Pb_Ppm_Range;
            set => SetProperty(ref kB_Pb_Ppm_Range, value);
        }

        private string kB_Cr_Ppm_Range;

        public string KB_Cr_ppm_range
        {
            get => kB_Cr_Ppm_Range;
            set => SetProperty(ref kB_Cr_Ppm_Range, value);
        }

        private string kB_Cd_Ppm_Range;

        public string KB_Cd_ppm_range
        {
            get => kB_Cd_Ppm_Range;
            set => SetProperty(ref kB_Cd_Ppm_Range, value);
        }

        private string kB_Al_Yuzde_Range;

        public string KB_Al_yuzde_range
        {
            get => kB_Al_Yuzde_Range;
            set => SetProperty(ref kB_Al_Yuzde_Range, value);
        }

        private string mO_RD_AkmaMukavemeti_N_Mm2_Range;

        public string MO_RD_AkmaMukavemeti_N_mm2_range
        {
            get => mO_RD_AkmaMukavemeti_N_Mm2_Range;
            set => SetProperty(ref mO_RD_AkmaMukavemeti_N_Mm2_Range, value);
        }

        private string mO_RD_MekMukavemet_N_Mm2_Range;

        public string MO_RD_MekMukavemet_N_mm2_range
        {
            get => mO_RD_MekMukavemet_N_Mm2_Range;
            set => SetProperty(ref mO_RD_MekMukavemet_N_Mm2_Range, value);
        }

        private string mO_RD_Uzama_Yuzde_Range;

        public string MO_RD_Uzama_yuzde_range
        {
            get => mO_RD_Uzama_Yuzde_Range;
            set => SetProperty(ref mO_RD_Uzama_Yuzde_Range, value);
        }

        private string mO_TD_AkmaMukavemeti_N_Mm2_Range;

        public string MO_TD_AkmaMukavemeti_N_mm2_range
        {
            get => mO_TD_AkmaMukavemeti_N_Mm2_Range;
            set => SetProperty(ref mO_TD_AkmaMukavemeti_N_Mm2_Range, value);
        }

        private string mO_TD_MekMukavemet_N_Mm2_Range;

        public string MO_TD_MekMukavemet_N_mm2_range
        {
            get => mO_TD_MekMukavemet_N_Mm2_Range;
            set => SetProperty(ref mO_TD_MekMukavemet_N_Mm2_Range, value);
        }

        private string mO_TD_Uzama_Yuzde_Range;

        public string MO_TD_Uzama_yuzde_range
        {
            get => mO_TD_Uzama_Yuzde_Range;
            set => SetProperty(ref mO_TD_Uzama_Yuzde_Range, value);
        }

        private string dI_Erichsen_Mm_Range;

        public string DI_Erichsen_mm_range
        {
            get => dI_Erichsen_Mm_Range;
            set => SetProperty(ref dI_Erichsen_Mm_Range, value);
        }

        private string dI_KaydiriciMiktari_Mgr_M2_Range;

        public string DI_KaydiriciMiktari_mgr_m2_range
        {
            get => dI_KaydiriciMiktari_Mgr_M2_Range;
            set => SetProperty(ref dI_KaydiriciMiktari_Mgr_M2_Range, value);
        }
    }
}
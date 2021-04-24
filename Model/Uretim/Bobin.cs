using Newtonsoft.Json;
using mnd.Common;
using mnd.Logic.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace mnd.Logic.Model.Uretim
{
    public class Bobin : MyBindableBase, IValidatableObject
    {
        [Key]
        public int Id { get; set; }

     
        public int? PaletId { get; set; }

        [JsonIgnore]
        public Palet PaletIdNav { get; set; }

        private string uretimEmriKod;

        public string UretimEmriKod
        {
            get => uretimEmriKod;
            set => SetProperty(ref uretimEmriKod, value);
        }

        public Guid? RowGuid { get; set; }

        private string bobinNo;

        public string CariKod { get; set; }

        public string FirinNo { get => _firinNo; set => SetProperty(ref _firinNo, value); }
        public string SehpaNo { get => _sehpaNo; set => SetProperty(ref _sehpaNo, value); }
        public string TavNo { get => _tavNo; set => SetProperty(ref _tavNo, value); }

        public int? BobinAdet { get => _bobinAdet.GetValueOrDefault(); set => SetProperty(ref _bobinAdet, value); }

        public DateTime? BobinEklenmeTarihi { get; set; }

        private int? agirlik_Kg;

        public int? Agirlik_kg
        {
            get => agirlik_Kg;
            set => SetProperty(ref agirlik_Kg, value);
        }

       

        private string fH_CikisNo;

        public string FH_CikisNo
        {
            get => fH_CikisNo;
            set => SetProperty(ref fH_CikisNo, value);
        }

        public string CariKod_Onceki { get; set; }

        [JsonIgnore]
        public UretimEmri UretimEmriKodNav { get; set; }


        public string Ekleyen { get; set; }

        public int MesajSayisi { get => 1; }



        public string BobinNo
        {
            get => bobinNo;
            set
            {
                SetProperty(ref bobinNo, value);

                BobinAdet = BobinSayiHelper.BobinAdetBul(bobinNo);
            }
        }



        private decimal? kB_Si_Yuzde;

        public decimal? KB_Si_yuzde
        {
            get => kB_Si_Yuzde;
            set => SetProperty(ref kB_Si_Yuzde, value);
        }

        private decimal? kB_Fe_Yuzde;

        public decimal? KB_Fe_yuzde
        {
            get => kB_Fe_Yuzde;
            set => SetProperty(ref kB_Fe_Yuzde, value);
        }

        private decimal? kB_Cu_Yuzde;

        public decimal? KB_Cu_yuzde
        {
            get => kB_Cu_Yuzde;
            set => SetProperty(ref kB_Cu_Yuzde, value);
        }

        private decimal? kB_Mn_Yuzde;

        public decimal? KB_Mn_yuzde
        {
            get => kB_Mn_Yuzde;
            set => SetProperty(ref kB_Mn_Yuzde, value);
        }

        private decimal? kB_Ti_Yuzde;

        public decimal? KB_Ti_yuzde
        {
            get => kB_Ti_Yuzde;
            set => SetProperty(ref kB_Ti_Yuzde, value);
        }

        private decimal? kB_Mg_Yuzde;

        public decimal? KB_Mg_yuzde
        {
            get => kB_Mg_Yuzde;
            set => SetProperty(ref kB_Mg_Yuzde, value);
        }

        private decimal? kB_Zn_Yuzde;

        public decimal? KB_Zn_yuzde
        {
            get => kB_Zn_Yuzde;
            set => SetProperty(ref kB_Zn_Yuzde, value);
        }

        private decimal? kB_Pb_Ppm;

        public decimal? KB_Pb_ppm
        {
            get => kB_Pb_Ppm;
            set => SetProperty(ref kB_Pb_Ppm, value);
        }

        private decimal? kB_Cr_Ppm;

        public decimal? KB_Cr_ppm
        {
            get => kB_Cr_Ppm;
            set => SetProperty(ref kB_Cr_Ppm, value);
        }

        private decimal? kB_Cd_Ppm;

        public decimal? KB_Cd_ppm
        {
            get => kB_Cd_Ppm;
            set => SetProperty(ref kB_Cd_Ppm, value);
        }

        private decimal? kB_Al_Yuzde;

        public decimal? KB_Al_yuzde
        {
            get => kB_Al_Yuzde;
            set => SetProperty(ref kB_Al_Yuzde, value);
        }

        private decimal? mO_RD_AkmaMukavemeti_N_Mm2;

        public decimal? MO_RD_AkmaMukavemeti_N_mm2
        {
            get => mO_RD_AkmaMukavemeti_N_Mm2;
            set => SetProperty(ref mO_RD_AkmaMukavemeti_N_Mm2, value);
        }

        private decimal? mO_RD_MekMukavemet_N_Mm2;

        public decimal? MO_RD_MekMukavemet_N_mm2
        {
            get => mO_RD_MekMukavemet_N_Mm2;
            set => SetProperty(ref mO_RD_MekMukavemet_N_Mm2, value);
        }

        private decimal? mO_RD_Uzama_Yuzde;

        public decimal? MO_RD_Uzama_yuzde
        {
            get => mO_RD_Uzama_Yuzde;
            set => SetProperty(ref mO_RD_Uzama_Yuzde, value);
        }

        private decimal? mO_TD_AkmaMukavemeti_N_Mm2;

        public decimal? MO_TD_AkmaMukavemeti_N_mm2
        {
            get => mO_TD_AkmaMukavemeti_N_Mm2;
            set => SetProperty(ref mO_TD_AkmaMukavemeti_N_Mm2, value);
        }

        private decimal? mO_TD_MekMukavemet_N_Mm2;

        public decimal? MO_TD_MekMukavemet_N_mm2
        {
            get => mO_TD_MekMukavemet_N_Mm2;
            set => SetProperty(ref mO_TD_MekMukavemet_N_Mm2, value);
        }

        private decimal? mO_TD_Uzama_Yuzde;

        public decimal? MO_TD_Uzama_yuzde
        {
            get => mO_TD_Uzama_Yuzde;
            set => SetProperty(ref mO_TD_Uzama_Yuzde, value);
        }

        private decimal? dI_Erichsen_Mm;

        public decimal? DI_Erichsen_mm
        {
            get => dI_Erichsen_Mm;
            set => SetProperty(ref dI_Erichsen_Mm, value);
        }

        private decimal? dI_KaydiriciMiktari_Mgr_M2;

        public decimal? DI_KaydiriciMiktari_mgr_m2
        {
            get => dI_KaydiriciMiktari_Mgr_M2;
            set => SetProperty(ref dI_KaydiriciMiktari_Mgr_M2, value);
        }

        private DateTime? sertifikaTarihi;
        private string _firinNo;
        private string _sehpaNo;
        private string _tavNo;
        private int? _bobinAdet;

        public DateTime? SertifikaTarihi
        {
            get => sertifikaTarihi;
            set => SetProperty(ref sertifikaTarihi, value);
        }

        public string SertifikaNumarasi { get; set; }

        [NotMapped]
        public KaliteStandart KaliteSinirlari { get; set; }

        public Bobin()
        {
            RowGuid = Guid.NewGuid();
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var range_properties = KaliteSinirlari.GetType().GetProperties().Where(c => c.Name.Contains("range")).ToList();

            foreach (var prop in range_properties)
            {
                var prop_deger = PandapObjectHelper.GetPropValue(this, prop.Name.Replace("_range", ""));
                var kaliteAralik = (string)prop.GetValue(KaliteSinirlari);

                if (prop_deger != null && kaliteAralik != null)
                {
                    var isValid = VeriInRange_IsValid((decimal)prop_deger, kaliteAralik, '-');
                    if (isValid == false) yield return new ValidationResult("Min-Max aralığında değil", new string[] { prop.Name.Replace("_range", "") });
                }
            }
        }

        public bool VeriInRange_IsValid(decimal deger, string rangeMetin, char splitChar)
        {
            if (!rangeMetin.Contains(splitChar.ToString()))
                throw new Exception("Aralık için ayraç karakteri girilmemiş");

            decimal a = decimal.Parse(rangeMetin.Split(splitChar)[0]);
            decimal b = decimal.Parse(rangeMetin.Split(splitChar)[1]);

            var isvalid = deger >= a && deger <= b;

            return isvalid;
        }
    }
}
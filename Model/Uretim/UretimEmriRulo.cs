using System.ComponentModel.DataAnnotations;

namespace mnd.Logic.Model.Uretim
{
    public class UretimEmriRulo : MyBindableBase
    {
        private int? dokumEni_mm;
        private int dokmeRuloAgirligi_kg;
        private int baslangicEni_mm;
        private int baslangicNo_kg;
        private string planlamaRuloNo;

        [Key]
        public int Id { get; set; }

        public string DokmeRuloNo { get; set; }
        public string UretimEmriKod { get; set; }
        public string PlanlamaRuloNo { get => planlamaRuloNo; set => SetProperty(ref planlamaRuloNo ,value); }

        public int BaslangicNo_kg { get => baslangicNo_kg; set => SetProperty(ref baslangicNo_kg, value); }
        public int BaslangicEni_mm { get => baslangicEni_mm; set => SetProperty(ref baslangicEni_mm, value); }

        public int DokmeRuloAgirligi_kg { get => dokmeRuloAgirligi_kg; set => SetProperty(ref dokmeRuloAgirligi_kg, value); }

        public int? DokumEni_mm { get => dokumEni_mm; set => SetProperty(ref dokumEni_mm, value); }

        public UretimEmri UretimEmriKodNav { get; set; }
    }
}
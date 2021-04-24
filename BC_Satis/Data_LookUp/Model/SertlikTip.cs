using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace mnd.Logic.BC_Satis.Data_LookUp.Model
{
    // equal referans tipli kıyaslama yapanlarda sorun çıkarıyor. (comboboxlar)
    // o yüzden özel eşitlik Id ler üzerinden ayarlandı

    public partial class SertlikTip
    {

        [Key]
        public string SertlikKod { get; set; }

        public string Aciklama { get; set; }
        public int? CiktiSira { get; set; }



    }
}
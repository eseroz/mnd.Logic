using mnd.Logic.Model.Satis;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace mnd.Logic.Model._Ref
{
    // equal referans tipli kıyaslama yapanlarda sorun çıkarıyor. (comboboxlar)
    // o yüzden özel eşitlik Id ler üzerinden ayarlandı

    public partial class SertlikTip
    {
        public SertlikTip()
        {
            //_SiparisKalem = new HashSet<SiparisKalem>();
        }

        [Key]
        public string SertlikKod { get; set; }

        public string Aciklama { get; set; }
        public int? CiktiSira { get; set; }

        //public ICollection<SiparisKalem> _SiparisKalem { get; set; }

        public override bool Equals(object obj)
        {
            var ikinci = (SertlikTip)obj;


            return this.SertlikKod == ikinci.SertlikKod;


        }

        public override int GetHashCode()
        {
            return base.GetHashCode() * 2323;
        }

    }
}
using mnd.Logic.Model.Satis;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace mnd.Logic.Model._Ref
{
    public partial class NakliyeDurumTip
    {
        public NakliyeDurumTip()
        {
        }

        [Key]
        public string NakliyeDurumTipAdi { get; set; }

    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mnd.Logic.Model.Uretim
{
    public class UretimEmriMakineAsama1
    {
        [Key]
        public int Id { get; set; }

        public string UretimEmriKod { get; set; }
        public string KenarKesme { get; set; }
        public string Bombe { get; set; }
        public int Ek { get; set; }

        public string EzmeYuzde
        {
            get
            {
                if (ProsesMin == null) return null;
                return ((1 - ProsesMin.GetValueOrDefault() / ProsesMax.GetValueOrDefault()) * 100).ToString("n1");
            }
        }

        public DateTime? FiiliBaslamaZaman { get; set; }
        public DateTime? FiiliBitisZaman { get; set; }
        public string Makine { get; set; }
        public decimal Miktar { get; set; }
        public string Notlar { get; set; }
        public string Operator { get; set; }
        public decimal? ProsesMax { get; set; }
        public decimal? ProsesMin { get; set; }

        public string Ra { get; set; }
        public int SatirNo { get; set; }
        public DateTime? Tarih { get; set; }
        public UretimEmri UretimEmriKodNav { get; set; }
    }
}

using System;
using System.ComponentModel.DataAnnotations;

namespace mnd.Logic.Model.Netsis
{
    public partial class DovizKur
    {
        [Key]
        public Guid Id { get; set; }

        public DateTime? Tarih { get; set; }
        public int? Sira { get; set; }
        public double? DovizAlis { get; set; }
        public double? DovizSatis { get; set; }

        public string DovizAd { get; set; }
        public int NetsisSira { get; set; }
    }
}
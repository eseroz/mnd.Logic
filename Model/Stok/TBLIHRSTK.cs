using Newtonsoft.Json;
using mnd.Common;
using mnd.Logic.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace mnd.Logic.Model.Stok
{
    public class TBLIHRSTK : MyBindableBase 
    {
        [Key]
        public int Id { get; set; }
        public string UrunKod { get; set; } 
        public string UrunAdiTR { get; set; }
        public string UrunAdiEN { get; set; }
        public decimal? BirimFiyat { get; set; }
        public decimal? GR { get; set; }
        public decimal? PCS { get; set; } 
        public decimal? BOX { get; set; }
        public decimal? NETKG { get; set; }
        public decimal? GROSS { get; set; }
        public decimal? W { get; set; }
        public decimal? L { get; set; }
        public decimal? H { get; set; } 
        public decimal? M3 { get; set; } 
        public decimal? CRTN { get; set; }
    }

}
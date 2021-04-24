using mnd.Logic.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mnd.Logic.BC_Kalite.Domain
{
    public class KaliteRedMalzeme : MyBindableBase
    {
        private string uretimEmriKod;
        private string musteri;
        private string kartNo;
        private string kalinlik;
        private string alasim;
        private string kondusyon;
        private string en;

        [Key]
        public int Id { get; set; }

        public string UretimEmriKod { get => uretimEmriKod; set => SetProperty(ref uretimEmriKod, value); }

        public string KartNo { get => kartNo; set => SetProperty(ref kartNo, value); }

        public DateTime? Tarih { get; set; }
        public double? Vardiya { get; set; }
        public string Operator { get; set; }
        public string KafileNo { get; set; }
        public string BobinNo { get; set; }
        public string MalzemeNo { get; set; }
        public string Alasim { get => alasim; set => SetProperty(ref alasim, value); }
        public string Kondusyon { get => kondusyon; set => SetProperty(ref kondusyon, value); }
        public string En { get => en; set => SetProperty(ref en , value); }
        public string Kalinlik { get => kalinlik; set => SetProperty(ref kalinlik, value); }
        public string RedYeri { get; set; }
        public int RedMiktarKg { get; set; }
        public string Musteri { get => musteri; set => SetProperty(ref musteri, value); }
        public string RedNedeni { get; set; }
        public string KaliteTeknisyeni { get; set; }

        public Guid RowGuid { get; set; }

        public DateTime? EklenmeTarihi { get; set; }

    }
}

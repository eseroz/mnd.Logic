using mnd.Logic.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mnd.Logic.BC_Dashboard
{
    public class Exw : MyBindableBase
    {
        private decimal? nakliyeFiyatiDVZ;

        public Exw()
        {

        }

        [Key]
        public Guid? Id { get; set; }
        public string NetsisIrsaliyeNo { get; set; }
        public int IrsaliyeId { get; set; }
        public DateTime? IrsaliyeTarihi { get; set; }
        public string FaturaDovizTip { get; set; }
        public decimal? NakliyeFiyati { get; set; }
        public decimal LmeBF_Ton { get; set; }
        public decimal IscilikBF_Ton { get; set; }

        public decimal KulceBF_Ton { get; set; }

        public int? ToplamKg { get; set; }
        public string CariAd { get; set; }
        public string UlkeAd { get; set; }

        public int IrsaliyeGToplamKg { get; set; }


        [NotMapped]
        public decimal? NakliyeFiyatiDVZ { get => nakliyeFiyatiDVZ; set => SetProperty(ref nakliyeFiyatiDVZ , value); }

        [NotMapped]
        public decimal ExwSonuc => IscilikBF_Ton + KulceBF_Ton - (NakliyeFiyatiDVZ.GetValueOrDefault() / ((decimal)ToplamKg / 1000));

    }
}

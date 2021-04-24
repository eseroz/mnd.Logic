using mnd.Logic.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mnd.Logic.BC_Uretim.SH_RotaModel
{
    [Table("SH_RotaKart", Schema = "Uretim")]
    public partial class ShRotaKart : MyBindableBase
    {
        private string shKartNo;
        private string kondisyon;
        private int? kalinlik;

        [Key]
        public string KartNo { get => shKartNo; set => SetProperty(ref shKartNo, value); }

        public DateTime Tarih { get; set; }

        public string Olusturan { get; set; }
        public string Guncelleyen { get; set; }

        public string AlasimKod { get; set; }
        public string Kondisyon { get => kondisyon; set => SetProperty(ref kondisyon, value); }
        public int? Kalinlik { get => kalinlik; set => SetProperty(ref kalinlik, value); }
        public decimal? En { get; set; }
        public int? DokumBobinAdedi { get; set; }

        [NotMapped]
        public string AktifProses { get; set; }

        [NotMapped]
        public int KartBitmeYuzde { get; set; }

        public ObservableCollection<ShRotaKartDokumBobin> DokumBobinler { get; set; }
        public ObservableCollection<ShRotaKartFaz> Fazlar { get; set; }

        public ShRotaKart()
        {
            DokumBobinler = new ObservableCollection<ShRotaKartDokumBobin>();
            Fazlar = new ObservableCollection<ShRotaKartFaz>();
        }


    }
}
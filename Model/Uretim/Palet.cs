using Newtonsoft.Json;
using mnd.Logic.Model.Netsis;
using mnd.Logic.Model.Satis;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace mnd.Logic.Model.Uretim
{
    public class Palet : MyBindableBase
    {
        [Key]
        public int Id { get; set; }

        [NotMapped]
        public bool Sec { get; set; }

        public int? SevkiyatEmriId { get; set; }

        public string SevkSurecDurum { get; set; }

        public string Ekleyen { get; set; }
        public string PaletKonum { get; set; }

        public string PaletEbat { get; set; }
        private int paletDara_kg;



        public string SevkiyatAdresNot { get => _sevkiyatAdresNot; set => SetProperty(ref _sevkiyatAdresNot, value); }

        public string PaletGrupKey
        {
            get;
        }

        private string cariKod;

        public string CariKod { get => cariKod; set => SetProperty(ref cariKod, value); }


        public int PaletDara_Kg
        {
            get => paletDara_kg;
            set
            {
                SetProperty(ref paletDara_kg, value);
                OnPropertyChanged(nameof(PaletBrut_Kg));
            }
        }


        [JsonIgnore]
        public int PaletNet_Kg => Bobinler.Sum(c => c.Agirlik_kg).Value;

        [JsonIgnore]
        public int PaletBrut_Kg => PaletDara_Kg + PaletNet_Kg;


        public ObservableCollection<Bobin> Bobinler { get; set; }

        [JsonIgnore]
        public CariKart CariKartNav { get; set; }



        public string UretimEmriKod { get => uretimEmriKod; set => SetProperty(ref uretimEmriKod, value); }

        [JsonIgnore]
        public UretimEmri UretimEmriKodNav { get; set; }

        public string FiyatKalemKod { get; set; }

        [JsonIgnore]
        public SiparisKalem FiyatKalemKodNav { get; set; }

        public DateTime? DepoOnayaGonderimTarihi { get; set; }

        public DateTime? DepoKabulTarihi { get; set; }

        public DateTime? SevkiyatTarihi { get; set; }

        public DateTime? KarantinaTarihi { get; set; }

        public string Aciklama { get => aciklama; set => SetProperty(ref aciklama , value); }

        private string irsaliyeNo;
        private string _sevkiyatAdresNot;
        private string uretimEmriKod;
        private string aciklama;

        public string NetsisIrsaliyeNo
        {
            get => irsaliyeNo;
            set => SetProperty(ref irsaliyeNo, value);
        }

        public string BobinlerBirlesik => String.Join(";", Bobinler.Select(c => c.BobinNo));

        public int? FirinNo { get; set; }
        public int? TavNo { get; set; }
        public int? SehpaNo { get; set; }
        public string KartNo { get; set; }
        public string PaketlemeNot { get; set; }

        public Palet()
        {
            Bobinler = new ObservableCollection<Bobin>();
        }
    }
}
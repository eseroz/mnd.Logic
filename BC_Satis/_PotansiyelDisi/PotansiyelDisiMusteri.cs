using mnd.Logic.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace mnd.Logic.BC_Satis._PotansiyelDisi
{
    public class PotansiyelDisiMusteri : MyBindableBase
    {
        public PotansiyelDisiMusteri()
        {
            PotansiyelDisiMusteriArama = new ObservableCollection<PotansiyelDisiMusteriArama>();
        }

        [Key]
        public int Id { get; set; }
        public string MusteriUnvan { get; set; }
        public string UlkeAdi { get; set; }
        public string UlkeKodu { get; set; }
        public string PlasiyerKod { get; set; }
        public string MusteriGrubuAdi { get; set; }


        private ObservableCollection<PotansiyelDisiMusteriArama> potansiyelDisiMusteriArama;
        public ObservableCollection<PotansiyelDisiMusteriArama> PotansiyelDisiMusteriArama { 
            get => potansiyelDisiMusteriArama; 
            set => SetProperty(ref potansiyelDisiMusteriArama, value); 
        }

        [NotMapped]
        public string PlasiyerAd { get; }
        [NotMapped]
        public int ToplamGorusmeSayisi { 
            get {
                return this.PotansiyelDisiMusteriArama.Count;
            }
        }
        [NotMapped]
        public string SonGorusmeSuresi { 
            get {
                int yeniGun = 0;
                TimeSpan? gun = (this.PotansiyelDisiMusteriArama.LastOrDefault()?.Tarih - DateTime.Now);              
                if (gun.Value.TotalDays < 0) yeniGun = (int)gun.Value.TotalDays * -1; 
                return yeniGun.ToString();                
            } 
        }
    }
}
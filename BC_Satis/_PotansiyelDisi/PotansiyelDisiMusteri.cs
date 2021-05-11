using mnd.Logic.BC_App.Domain;
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
        public string PlasiyerAd { get; set; }
        public string MusteriGrubuAdi { get; set; }
 

        private ObservableCollection<PotansiyelDisiMusteriArama> potansiyelDisiMusteriArama;
        public ObservableCollection<PotansiyelDisiMusteriArama> PotansiyelDisiMusteriArama
        {
            get => potansiyelDisiMusteriArama;
            set => SetProperty(ref potansiyelDisiMusteriArama, value);
        }

        public string CreatedUserId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string LastEditedBy { get; set; }
        public DateTime? LastEditedDate { get; set; }
        public Guid? RowGuid { get; set; }


        [NotMapped]
        public int ToplamGorusmeSayisi
        {
            get
            {
                return this.PotansiyelDisiMusteriArama.Count;
            }
        }
        [NotMapped]
        public string SonGorusmeSuresi
        {
            get
            {
                if (this.PotansiyelDisiMusteriArama.LastOrDefault()?.Tarih != null)
                {
                    if (this.PotansiyelDisiMusteriArama.Count == 0) return string.Empty;

                    int yeniGun = 0;
                    TimeSpan? gun = (this.PotansiyelDisiMusteriArama.LastOrDefault()?.Tarih - DateTime.Now);
                    if (gun.Value.TotalDays < 0) yeniGun = (int)gun.Value.TotalDays * -1;
                    return yeniGun.ToString();
                }
                return 0.ToString() ;
            }
        }
    }
}
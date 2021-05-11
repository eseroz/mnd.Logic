using mnd.Logic.Model;
using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mnd.Logic.BC_Satis._PotansiyelDisi
{
    public class PotansiyelDisiMusteriArama : MyBindableBase
    {
        [Key]
        public int Id { get; set; }
        public int PotansiyelDisiMusteriId { get => potansiyelDisiMusteriId; set => SetProperty(ref potansiyelDisiMusteriId, value); }
        public DateTime? Tarih { get => tarih; set => SetProperty(ref tarih, value); }
        public string Konu { get => konu; set => SetProperty(ref konu, value); }
        public string KonuDetay { get => konuDetay; set => SetProperty(ref konuDetay, value); }
        public string GorusulenKisiAdi { get => gorusulenKisiAdi; set => SetProperty(ref gorusulenKisiAdi, value); }
        public string GorusulenKisiGorevi { get => gorusulenKisiGorevi; set => SetProperty(ref gorusulenKisiGorevi, value); }
        public string GorusulenKisiTelefon { get => gorusulenKisiTelefon; set => SetProperty(ref gorusulenKisiTelefon, value); }
        public string GorusulenKisiEposta { get => gorusulenKisiEposta; set => SetProperty(ref gorusulenKisiEposta, value); }
        public string PlasiyerKod { get => plasiyerKod; set => SetProperty(ref plasiyerKod, value); }

        [NotMapped]
        public string UlkeKodu { get => ulkeKodu; set => SetProperty(ref ulkeKodu, value); }

        public string CreatedUserId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string LastEditedBy { get; set; }
        public DateTime? LastEditedDate { get; set; }

        public Guid? RowGuid { get; set; }



        private DateTime? tarih;
        private string gorusulenKisiEposta;
        private string gorusulenKisiTelefon;
        private string gorusulenKisiGorevi;
        private string gorusulenKisiAdi;
        private string konu;
        private string konuDetay;
        private string plasiyerKod;
        private int potansiyelDisiMusteriId;

        private string musteriUnvan;
        private string ulkeKodu;

        [NotMapped]
        public string MusteriUnvan
        {
            get => musteriUnvan;
            set => SetProperty(ref musteriUnvan, value);
        }



    }
}

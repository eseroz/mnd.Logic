using mnd.Logic.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mnd.Logic.BC_Satis._PotansiyelDisi
{
    public class PotansiyelDisiMusteriArama : MyBindableBase
    {
        private string gorusulenKisiTelefon;
        private string gorusulenKisiGorevi;
        private string gorusulenKisiAdi;
        private string konu;
        private string konuDetay;
        private string ulkeKodu;
        private string ulkeAdi;
        private string musteriGrubuAdı;
        private string musteriUnvan;
        private DateTime? tarih;
        private string gorusulenKisiEposta;
        private string ekleyen;
        private string plasiyerKod;

        [Key]
        public int Id { get; set; }
        public DateTime? Tarih { get => tarih; set => SetProperty(ref tarih, value); }
        public string MusteriUnvan { get => musteriUnvan; set => SetProperty(ref musteriUnvan, value); }
        public string MusteriGrubuAdı { get => musteriGrubuAdı; set => SetProperty(ref musteriGrubuAdı, value); }
        public string UlkeAdi { get => ulkeAdi; set => SetProperty(ref ulkeAdi, value); }
        public string UlkeKodu { get => ulkeKodu; set => SetProperty(ref ulkeKodu, value); }
        public string KonuDetay { get => konuDetay; set => SetProperty(ref konuDetay, value); }
        public string Konu { get => konu; set => SetProperty(ref konu, value); }
        public string GorusulenKisiAdi { get => gorusulenKisiAdi; set => SetProperty(ref gorusulenKisiAdi, value); }
        public string GorusulenKisiGorevi { get => gorusulenKisiGorevi; set => SetProperty(ref gorusulenKisiGorevi, value); }
        public string GorusulenKisiTelefon
        {
            get => gorusulenKisiTelefon;
            set => SetProperty(ref gorusulenKisiTelefon, value);
        }
        public string GorusulenKisiEposta { get => gorusulenKisiEposta; set => SetProperty(ref gorusulenKisiEposta, value); }

        public string Ekleyen { get => ekleyen; set => SetProperty(ref ekleyen, value); }

        public string PlasiyerKod { get => plasiyerKod; set => SetProperty(ref plasiyerKod, value); }

    }
}

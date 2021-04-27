using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mnd.Logic.BC_Satis._PotansiyelDisi
{
    public class PotansiyelDisiMusteriArama
    {
        [Key]
        public int Id { get; set; }
        public DateTime? Tarih { get; set; }
        public string MusteriUnvan { get; set; }
        public string MusteriGrubuAdı { get; set; }
        public string UlkeAdi { get; set; }
        public string UlkeKodu { get; set; }
        public string KonuDetay { get; set; }
        public string Konu { get; set; }
        public string GorusulenKisiAdi { get; set; }
        public string GorusulenKisiGorevi { get; set; }
        public string GorusulenKisiTelefon { get; set; }
        public string GorusulenKisiEposta { get; set; }

        public string Ekleyen { get; set; }

        public string PlasiyerKod { get; set; }

    }
}

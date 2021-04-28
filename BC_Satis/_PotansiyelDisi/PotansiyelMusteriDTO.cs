using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace mnd.Logic.BC_Satis._PotansiyelDisi
{
    public class PotansiyelMusteriDTO
    {
        private List<PotansiyelDisiMusteriArama> musteriAramalarDTO;

        public int Id { get; set; }
        public string MusteriUnvan { get; set; }
        public string MusteriGrubuAdı { get; set; }
        public string UlkeAdi { get; set; }
        public string UlkeKodu { get; set; }
        public int ToplamGorusmeSayisi { get; set; }
        public string SonGorusmeSuresi { get; set; }
        public List<PotansiyelDisiMusteriArama> MusteriAramalarDTO {
            get => musteriAramalarDTO;
            set { 
                musteriAramalarDTO = value;
                ToplamGorusmeSayisi = musteriAramalarDTO.Count;
            } 
        }

        public PotansiyelMusteriDTO()
        {
            MusteriAramalarDTO = new List<PotansiyelDisiMusteriArama>();
        }
    }

    public class PotansiyelMusteriAramalarDTO
    {
        public DateTime Tarih { get; set; }
        public string Konu { get; set; }
        public string KonuDetay { get; set; }
        public string GorusulenKisiAdi { get; set; }
        public string GorusulenKisiGorevi { get; set; }
        public string GorusulenKisiTelefon { get; set; }
        public string GorusulenKisiEposta { get; set; }


        public PotansiyelMusteriAramalarDTO()
        {

        }
    }
}

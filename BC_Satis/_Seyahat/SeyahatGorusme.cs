using System;
using System.ComponentModel.DataAnnotations;

namespace mnd.Logic.BC_Satis._Seyahat
{
    public class SeyahatGorusme
    {
        [Key]
        public int Id { get; set; }

        public int SeyahatId { get; set; }


        public DateTime? Tarih { get; set; }

        public string  Sehir { get; set; }
 
        public string GorusulenKisiAdSoyad { get; set; }

        public string GorusulenKisiTel { get; set; }

        public string GorusulenKisiEmail { get; set; }

        public string GorusulenKisiGorev { get; set; }

        public string MusteriUnvan { get; set; }

        public string KonuDetay { get; set; }

        public string AlinacakAksiyon { get; set; }


    }

}

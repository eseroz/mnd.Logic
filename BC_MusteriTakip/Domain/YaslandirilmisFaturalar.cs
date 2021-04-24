using System;

namespace mnd.Logic.BC_MusteriTakip.Domain
{
    public class YaslandirilmisFatura
    {

        public string CARI_KOD { get; set; }
        public byte DOVIZ_TURU { get; set; }
        public DateTime TARIH { get; set; }
        public DateTime VADE_TARIHI { get; set; }
        public string BELGE_NO { get; set; }
        public decimal DOVIZBORC_X { get; set; }
        public decimal DOVIZALACAK_X { get; set; }

        public int GUN { get; set; }

        public int BORCTUTAR { get; set; }




    }
}

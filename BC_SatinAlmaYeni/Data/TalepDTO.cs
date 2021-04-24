using System;
using System.Collections.Generic;

namespace mnd.Logic.BC_SatinAlmaYeni.Data
{
    public class TalepDTO
    {
        public int TalepId { get; set; }
        public DateTime TalepTarihi { get; set; }
        public string TalepEdenAdSoyad { get; set; }
        public string IsMerkeziAd { get; set; }
        public string StokGrupAd { get; set; }
        public int MesajSayisi { get;  set; }
        public Guid RowGuid { get;  set; }

        public string TalepTip { get; set; }
        public int OkunmamisMesajSayisi { get;  set; }
        public List<TalepKalemDTO> TalepUrunListe { get; set; }
        public string UrunAdlariBirlesik { get;  set; }
        public int ToplamTalepKalemSayisi { get;  set; }
        public int ToplamSiparisSayisi { get; internal set; }
        public int ToplamTeslimAlinanSiparisSayisi { get;  set; }
        public int ToplamTeslimBekleyenSiparisSayisi { get;  set; }
        public string SurecBilgi { get;  set; }
    }
}
namespace mnd.Logic.BC_SatinAlmaYeni.Data
{
    public class TalepKalemDTO
    {
        public string UrunKod { get; set; }
        public string UrunAd { get; set; }
        public decimal Miktar { get;  set; }
        public string Birim { get;  set; }
        public string TercihMarka { get; internal set; }
    }
}
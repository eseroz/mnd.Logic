using System;

namespace mnd.Logic.Services._DTOs
{
    public class BarkodPaletDto
    {
        public string Musteri { get; set; }
        public string UlkeKod { get; set; }
        public string UlkeAd { get; set; }

        public string MusteriSiparisNo { get; set; }
        public string KontratNo { get; set; }
        public string Ebat { get; set; }
        public string AlasimVeYuzey { get; set; }
        public string UretimEmriNo { get; set; }

        public int NetKg { get; set; }
        public int BrutKg { get; set; }

        public string PandaSiparisNo { get; set; }
        public string PaletNo { get; set; }
        public string MusteriSiparisKalemNo { get; set; }
        public DateTime PaketlenmeTarihi { get; set; }
        public string UretimBobinler { get; set; }
        public string UretimEmriNo_Basit { get; set; }
        public int UretimBobinSayisi { get; set; }
        public string KafileNo { get; set; }
        public string PaletNo_Basit { get; set; }
        public string MusteriAdres { get; set; }
       
    }
}
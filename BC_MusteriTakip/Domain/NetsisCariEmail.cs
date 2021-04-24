using System;
using System.ComponentModel.DataAnnotations;

namespace mnd.Logic.BC_MusteriTakip.Domain
{


    public class NetsisCariEmail
    {
        [Key]
        public int RECID { get; set; }
        public string CARI_KOD { get; set; }
        public string YETKILIKISI { get; set; }

        public string UNVAN { get; set; }
        public string TEL { get; set; }
        public string DAHILITEL { get; set; }
        public string CEPTEL { get; set; }
        public string ADRES { get; set; }
        public string ISLEMTIPI { get; set; }
        public string EMAIL { get; set; }
        public string CCMAIL { get; set; }
        public string DUYURU_KOD { get; set; }
        public string IL { get; set; }
        public string ILCE { get; set; }
        public string POSTAKODU { get; set; }
        public string GOREV { get; set; }
        public string CRMDEN { get; set; }
        public string SMSISLEMTIPI { get; set; }
        public string DIZAYNBILGILERI { get; set; }
        public string ULKETELKODU { get; set; }

        public string EKBILGI { get; set; }
        public bool? AKTIF { get; set; }
        public string CEPTEL2 { get; set; }
        public string TEL2 { get; set; }
        public string ULKETEL2KODU { get; set; }
        public string DAHILITEL2 { get; set; }
        public string DIREKTTEL { get; set; }
        public string ULKEDIREKTTELKODU { get; set; }
        public string OZELEMAIL { get; set; }
        public string KAYITYAPANKUL { get; set; }
        public DateTime? KAYITTARIHI { get; set; }
        public string DUZELTMEYAPANKUL { get; set; }
        public DateTime? DUZELTMETARIHI { get; set; }
        public string EMUTABAKATEMAIL { get; set; }
        public string EKDOSYAISLEMTIPI { get; set; }
    }
}

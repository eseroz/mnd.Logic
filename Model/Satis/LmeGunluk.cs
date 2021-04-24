using System;
using System.ComponentModel.DataAnnotations;

namespace mnd.Logic.Model.Satis
{
    public class LmeGunluk
    {
        [Key]
        public int Id { get; set; }
        public DateTime? Tarih { get; set; }

        public decimal Lme_USD { get; set; }
        public decimal Lme_EUR { get; set; }
        public decimal Lme_GBP { get; set; }

        public decimal LmeDegerGetir(string dovizKod,string cariKod="",string param1=null)
        {
         

            if (dovizKod.ToUpper() == "USD") return Lme_USD;
            if (dovizKod.ToUpper() == "EUR") return Lme_EUR;
            if (dovizKod.ToUpper() == "GBP") return Lme_GBP;

            return 0;

        }

    }
}

using mnd.Logic.Model.Satis;
using System;
using System.ComponentModel.DataAnnotations;

namespace mnd.Logic.Helper
{
    public class RuloDiscapMinMaxKontrol_MetrajGirildiyse_Attribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var siparisKalem = (SiparisKalem)validationContext.ObjectInstance;
            double deger = System.Convert.ToDouble(value);

          
            return ValidationResult.Success;
        }
    }

    public class MetrajKontrol_Attribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            double deger = System.Convert.ToDouble(value);

            var siparisKalem = (SiparisKalem)validationContext.ObjectInstance;


            return ValidationResult.Success;
        }
    }



    public class KalinlikKontrolFromUrunKodAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var siparisKalem = (SiparisKalem)validationContext.ObjectInstance;

            return ValidationResult.Success;
        }
    }

    public class StandartDisiEnToleransAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var siparisKalem = (SiparisKalem)validationContext.ObjectInstance;


            return ValidationResult.Success;
        }
    }

    public class NotZeroKapasitifDegilse : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var siparisKalem = (SiparisKalem)validationContext.ObjectInstance;


            return ValidationResult.Success;
        }
    }

    public class NotZero : ValidationAttribute
    {
        protected override System.ComponentModel.DataAnnotations.ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            double deger = System.Convert.ToDouble(value);

            if (deger == 0) return new ValidationResult("Sıfır Olamaz", new String[] { validationContext.MemberName });

            return ValidationResult.Success;
        }
    }
}
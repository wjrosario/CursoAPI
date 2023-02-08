using System;
using System.ComponentModel.DataAnnotations;

namespace WebApiControlStock.Helpers
{
    public class PrecioAttribute : ValidationAttribute
    {

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null || string.IsNullOrEmpty(value.ToString()))
            {
                return ValidationResult.Success;
            }
            if (Convert.ToDecimal(value) > 0)
            {
                return ValidationResult.Success;
            }
            return new ValidationResult("Precio debe ser mayor a cero!");

        }
    }
}

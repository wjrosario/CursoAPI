using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace WebApiControlStock.Helpers
{
    public class StringRangeAttribute : ValidationAttribute
    {
        public string[] AllowableValues { get; set; }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (AllowableValues?.Contains(value?.ToString()) == true)
            {
                return ValidationResult.Success;
            }

            var msg = $"Por favor ingrese uno de los valores permitidos: {string.Join(", ", (AllowableValues ?? new string[] { "No se encontraron valores permitidos" }))}.";
            return new ValidationResult(msg);
        }
    }
}

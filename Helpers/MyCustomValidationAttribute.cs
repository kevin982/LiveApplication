using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookStorePrueba.Helpers
{
    public class MyCustomValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is not null)
            {
                string bookName = value.ToString();

                if (bookName.Contains("mvc"))
                {
                    return ValidationResult.Success;
                }
                else
                {
                    return new ValidationResult("Value must contain mvc");
                }
            }

            return new ValidationResult("Value is empty ");
        }
    }
}

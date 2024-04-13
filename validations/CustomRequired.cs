using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace guia_2.validations
{
    public class CustomRequired : ValidationAttribute {

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext) {
            if(value is null || value.ToString() == "0"){
                return new ValidationResult(ErrorMessage);
            }
            return ValidationResult.Success;
        }
    }
}
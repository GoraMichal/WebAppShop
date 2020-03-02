using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebAppShop.Models
{
    public class Min18YearsOld : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customer)validationContext.ObjectInstance;

            if (customer.MembershipTypeId == MembershipType.Unknow 
                || customer.MembershipTypeId == MembershipType.Basic)
                return ValidationResult.Success;

            if (customer.Birthdate == null)
                return new ValidationResult("Podanie wieku wymagane!");

            var age = DateTime.Today.Year - customer.Birthdate.Value.Year;

            return (age >= 18) 
                ? ValidationResult.Success 
                : new ValidationResult("Użytkownik powinien mieć więcej niż 18 lat.");
        }
    }
}
  
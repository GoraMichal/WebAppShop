using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebAppShop.Models
{
    public class Customer
    {
        public int Id { get; set; }
        
        [StringLength(255)]
        [Display(Name = "Imię i Nazwisko")]
        [Required(ErrorMessage = "Wprowadź imię i nazwisko użytkownika.")]
        public string Name { get; set; }
        public bool IsSubscribedToNewsletter { get; set; }
        public MembershipType MembershipType { get; set; }
        
        [Display(Name = "Rodzaj członkostwa.")]
        [Required(ErrorMessage = "Rodzaj członkostwa wymagany!")]
        public byte MembershipTypeId { get; set; }

        [Display(Name="Data urodzin")]
        [Min18YearsOld]
        //[DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? Birthdate { get; set; }
    }
}
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
        [Required(ErrorMessage = "Wprowadź imię i nazwisko użytkownika.")]
        [StringLength(255)]
        [Display(Name = "Imię i Nazwisko")]
        public string Name { get; set; }
        public bool IsSubscribedToNewsletter { get; set; }
        public MembershipType MembershipType { get; set; }
        
        [Display(Name = "Rodzaj członkostwa")]
        public byte MembershipTypeId { get; set; }

        [Display(Name="Data urodzin")]
        public DateTime? Birthdate { get; set; }
    }
}
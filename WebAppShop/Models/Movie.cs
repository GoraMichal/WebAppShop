using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebAppShop.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [StringLength(255)]
        [Required(ErrorMessage = "Wprowadź imię i nazwisko użytkownika.")]
        public string Name { get; set; }

        [Display(Name = "Data Dodania")]
        public DateTime DateAdded { get; set; }

        [Display(Name = "Data Wydania")]
        [Required(ErrorMessage = "Wprowadź poprawną datę wydania filmu.")]
        public DateTime ReleaseDate { get; set; }
        
        [Display(Name = "Numer w Zbiorze")]
        [Range(1, 20)]
        [Required(ErrorMessage = "Wybierz liczbę ze zbioru od 1 do 20.")]
        public byte? NumberInStock { get; set; }

        public byte NumberAvailable { get; set; }

        public Genre Genre { get; set; }

        [Display(Name = "Gatunek")]
        [Required(ErrorMessage = "Wybierz gatunek filmu.")]
        public byte GenreId { get; set; }
    }
}
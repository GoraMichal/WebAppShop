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

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Display(Name = "Data Dodania")]
        public DateTime DateAdded { get; set; }

        [Display(Name = "Data Wydania")]
        public DateTime ReleaseDate { get; set; }

        [Display(Name = "Numer w Zbiorze")]
        [Range(1, 20)]
        public byte NumberInStock { get; set; }

        public Genre Genre { get; set; }

        [Display(Name = "Gatunek")]
        [Required]
        public byte GenreId { get; set; }
    }
}
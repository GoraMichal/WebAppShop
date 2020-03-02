using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WebAppShop.Models;

namespace WebAppShop.ModelsView
{
    public class MovieFormModelView
    {
        public IEnumerable<Genre> Genres { get; set; }

        public int? Id { get; set; }

        [StringLength(255)]
        public string Name { get; set; }

        [Display(Name = "Gatunek")]
        public byte? GenreId { get; set; }

        [Display(Name = "Data Dodania")]
        public DateTime DateAdded { get; set; }

        [Display(Name = "Data Wydania")]
        public DateTime ReleaseDate { get; set; }

        [Display(Name = "Numer w Zbiorze")]
        [Range(1, 20)]
        public byte? NumberInStock { get; set; }

        public string Title
        {
            get
            {
                return Id != 0 ? "Edycja filmu" : "Nowy film";
            }
        }

        public MovieFormModelView()
        {
            Id = 0;
        }

        public MovieFormModelView(Movie movie)
        {
            Id = movie.Id;
            Name = movie.Name;
            DateAdded = movie.DateAdded;
            ReleaseDate = movie.ReleaseDate;
            NumberInStock = movie.NumberInStock;
            GenreId = movie.GenreId;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAppShop.Models;

namespace WebAppShop.ModelsView
{
    public class RandomMovieViewModel
    {
        public Movie Movie { get; set; }
        public List<Customer> Customers { get; set; }
    }
}
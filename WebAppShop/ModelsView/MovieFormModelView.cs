using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAppShop.Models;

namespace WebAppShop.ModelsView
{
    public class MovieFormModelView
    {
        public Movie Movie { get; set; }
        public List<Customer> Customers { get; set; }
        //public IEnumerable<MembershipType> MembershipTypes { get; set; }
        public Customer Customer { get; set; }

        //public object Genres { get; internal set; }
        public IEnumerable<Genre> Genres { get; set; }

        public string Title
        {
            get
            {
                if (Movie != null && Movie.Id != 0)
                    return "Edit Movie";

                return "New Movie";
            }
        }
    }
}
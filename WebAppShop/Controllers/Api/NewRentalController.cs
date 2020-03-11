using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Data.Entity;
using WebAppShop.Dtos;
using WebAppShop.Models;
using System.Linq;

namespace WebAppShop.Controllers.Api
{
    public class NewRentalController : ApiController
    {
        private ApplicationDbContext _context;

        public NewRentalController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult CreateNewRentals(NewRentalDto newRental)
        {
            var customer = _context.Customers.Single(c => c.Id == newRental.CustomerId);
            var movies = _context.Movies.Where(c => newRental.MovieIds.Contains(c.Id));
               
            foreach (var movie in movies)
            {
                var rental = new Rental
                {
                    Customer = customer,
                    Movie = movie,
                    DateRented = DateTime.Now
                };

                _context.Rentals.Add(rental);
            }
            _context.SaveChanges();

            //return Ok, kiedy w akcji nie tworzy się pojedynczego obiektu, a wiele
            return Ok();
        }
    }
}

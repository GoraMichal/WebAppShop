using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAppShop.Models;
using WebAppShop.ModelsView;

namespace WebAppShop.Controllers
{
    //[AllowAnonymous]
    public class MoviesController : Controller
    {
        //Kontekst pomocniczy
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ViewResult Index()
        {
            //var movies = _context.Movies.Include(m => m.Genre).ToList();
            //return View(movies);
            if (User.IsInRole("CanManageMovies"))
                return View("List");
            else
                return View("ReadOnlyList");

        }

        public ViewResult New()
        {
            var genres = _context.Genres.ToList();

            var modelView = new MovieFormModelView
            {
                DateAdded = DateTime.Now,
                Genres = genres
            };

            return View("MovieForm", modelView);
        }

        [HttpPost]
        public ActionResult Save(Movie movie)
        {
            //sprawdza poprawność powiązania wartości przychodzących z żądaniami do modelu 
            if (!ModelState.IsValid)
            {
                var modelView = new MovieFormModelView(movie)
                {
                    Genres = _context.Genres.ToList()
                };
                return View("MovieForm", modelView);
            }

            if (movie.Id == 0)
            {
                _context.Movies.Add(movie);
            }
            else
            {
                var movieInDb = _context.Movies.Single(m => m.Id == movie.Id);
                movieInDb.Name = movie.Name;
                movieInDb.GenreId = movie.GenreId;
                movieInDb.NumberInStock = movie.NumberInStock;
                movieInDb.ReleaseDate = movie.ReleaseDate;
            }

            _context.SaveChanges();


            return RedirectToAction("Index", "Movies");
        }

        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.SingleOrDefault(c => c.Id == id);
            var genres = _context.Genres.ToList();

            if (movie == null)
                return HttpNotFound();

            var modelView = new MovieFormModelView(movie)
            {
                Genres = _context.Genres.ToList()
            };

            return View("MovieForm", modelView);
        }

        public ActionResult Remove(int id)
        {
            var removeObject = _context.Movies.Single(m => m.Id == id);

            _context.Movies.Remove(removeObject);

            _context.SaveChanges();
            return RedirectToAction("Index", "Movies");
        }

        public ActionResult Details(int id)
        {
            var movies = _context.Movies.Include(c => c.Genre).SingleOrDefault(c => c.Id == id);

            if (movies == null)
                return HttpNotFound();

            return View(movies);
        }

        //Zrobic usuwanie

        #region rozszerzenia kontrolera
        // GET: Movies/Random
        //public ActionResult Random()
        //{
        //    var movie = new Movie() { Name = "Obcy" };
        //    var customers = new List<Customer>
        //    {
        //        new Customer { Name = "Customer1"},
        //        new Customer { Name = "Customer2"}
        //    };

        //    var viewModel = new MovieFormModelView
        //    {
        //        Movie = movie,
        //        Customers = customers
        //    };

        //    return View(viewModel);
        //}

        //public ActionResult Edit(int id)
        //{
        //    return Content("id= " + id);
        //}

        //public ActionResult Index(int? pageIndex, string sortBy)
        //{
        //    if (!pageIndex.HasValue)
        //        pageIndex = 1;

        //    if (String.IsNullOrWhiteSpace(sortBy))
        //        sortBy = "Name";

        //    return Content(String.Format("pageIndex = {0} & sortBy = {1}", pageIndex, sortBy));
        //}
        #endregion
    }
}
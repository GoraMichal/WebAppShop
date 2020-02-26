using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAppShop.Models;
using WebAppShop.ModelsView;

namespace WebAppShop.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies/Random
        public ActionResult Random()
        {
            var movie = new Movie() { Name = "Obcy" };
            var customers = new List<Customer>
            {
                new Customer { Name = "Customer1"},
                new Customer { Name = "Customer2"}
            };

            var viewModel = new RandomMovieViewModel
            {
                Movie = movie,
                Customers = customers
            };

            return View(viewModel);
        }

        #region rozszerzenia kontrolera
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
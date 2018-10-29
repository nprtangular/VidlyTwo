using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VidlyTwo.Models;
using VidlyTwo.ViewModel;

namespace VidlyTwo.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies/Random
        public ActionResult Random()
        {
            Movie movie = new Movie();
            movie.Name = "Shrek";

            var customers = new List<Customer>();

            var custo = new Customer();
            custo.Name = "Customer 1";

            customers.Add(custo);


            var custoDos = new Customer();
            custoDos.Name = "Customer 2";
            customers.Add(custoDos);

            var viewModel = new RandomMovieViewModel();

            viewModel.Movie = movie;
            viewModel.Customers = customers;

            return View(viewModel);

        }

        [Route("movies/released/{year}/{month:regex(\\d{2}):range(1,12)}")]
        public ActionResult ByReleaseYear(int year, int month)
        {
            return Content(year + "/" + month);
        }

        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/" + month);
        }
        
        public ActionResult Edit(int id)
        {
            return Content("id=" + id);
        }

        public ActionResult Index(int? pageIndex, string sortBy)
        {
            if (!pageIndex.HasValue)
            {
                pageIndex = 1;
            }


            if (String.IsNullOrWhiteSpace(sortBy))
            {
                sortBy = "Name";
            }

            return Content(String.Format("pageIndex={0}&sortBy={1}", pageIndex, sortBy));


        }


    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;
using System.Data.Entity;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
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
            return View();
        }

        public ActionResult Details(int id)
        {
            var movie = _context.Movies.Include(m => m.Genre).SingleOrDefault(m => m.Id == id);

            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        public ViewResult New()
        {
            var genres = _context.Genres.ToList();

            var viewModel = new MovieFormViewModel
            {
                Genres = genres,
                ReleaseDate = DateTime.Now,
                NumberInStock = 0   
        };

            return View("MovieForm",viewModel);
        }

        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.SingleOrDefault(c => c.Id == id);

            if (movie==null)
            {
                return HttpNotFound();
            }

            var viewModel = new MovieFormViewModel(movie)
            {
                Genres = _context.Genres.ToList()
            };

            return View("MovieForm", viewModel);
        }
        [HttpPost]
        public ActionResult Save(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new MovieFormViewModel(movie)
                {
                    Genres = _context.Genres.ToList()
                };

                return View("MovieForm", viewModel);
            }
            if (movie.Id == 0)
            {
                movie.DateAdded = DateTime.Now;
                _context.Movies.Add(movie);
            }
            else
            {
                var movieInDb = _context.Movies.SingleOrDefault(m => m.Id == movie.Id);
                movieInDb.Name = movie.Name;
                movieInDb.GenreId = movie.GenreId;
                movieInDb.NumberInStock = movie.NumberInStock;
                movieInDb.ReleaseDate = movie.ReleaseDate;
            }
            _context.SaveChanges();

            return RedirectToAction("Index", "Movies");
        }


    }

}
//// GET: Movies/Random
//public ActionResult Random()
//{
//    var movie = new Movie() { Name = "Shrek!" };
//    var customers = new List<Customer>
//    {
//        new Customer{Name="Customer 1"},
//        new Customer{Name="Customer 2"}
//    };
//    var viewModel = new RandomMovieViewModel
//    {
//        Movie = movie,
//        Customers = customers
//    };
//    //ViewData["RandomMovie"] = movie;
//    //ViewBag.Movie = movie;  no usar 
//    return View(viewModel);
//    //return Content("Hello world");
//    //return HttpNotFound();
//    //return new EmptyResult();
//    //return RedirectToAction("Index", "Home",new { page = 1, sortby = "name" });
//}

////public ActionResult Edit(int Id)
////{
////    return Content("id="  Id);
////}

////public ActionResult Index(int? pageIndex, string sortBy) //? hace que permita nulos
////{
////    //Si la pagina tiene un valor
////    if (!pageIndex.HasValue)
////        pageIndex = 1;

////    if (string.IsNullOrWhiteSpace(sortBy))
////        sortBy = "Name";

////    return Content(String.Format("pageIndex={0}&sortby{1}", pageIndex, sortBy));
//////}

//public ActionResult ByReleaseDate(int year, int month)
//{
//    return Content(year  "/"month);
//}  

// private IEnumerable<Movie> GetMovies()
// {
//     return new List<Movie>
//     {
//         new Movie { Id = 1, Name = "Shrek" },
//         new Movie { Id = 2, Name = "Wall-e" }
//     };
//}
// GET: Movies/Random
//public ActionResult Random()
//{
//    var movie = new Movie() { Name = "Shrek!" };
//    var customers = new List<Customer>
//    {
//        new Customer{Name="Customer 1"},
//        new Customer{Name="Customer 2"}
//    };
//    var viewModel = new RandomMovieViewModel
//    {
//        Movie = movie,
//        Customers = customers
//    };
//    //ViewData["RandomMovie"] = movie;
//    //ViewBag.Movie = movie;  no usar 
//    return View(viewModel);
//    //return Content("Hello world");
//    //return HttpNotFound();
//    //return new EmptyResult();
//    //return RedirectToAction("Index", "Home",new { page = 1, sortby = "name" });
//}

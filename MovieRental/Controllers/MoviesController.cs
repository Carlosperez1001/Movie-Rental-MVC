using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Antlr.Runtime.Tree;
using MovieRental.Models;
using MovieRental.ViewModel;

namespace MovieRental.Controllers
{
    public class MoviesController : Controller
    {
        // Temp. DB for movies
        public  List<Movie> GetMovieDB() {
            var MovieList = new List<Movie> {
                new Movie{Id = 1, Name = "Shrek!" },
                new Movie{Id = 2, Name = "Wall-e" }
            };
            return (MovieList);
        }


        // Landing page for all movies
        // [localhost:XXXX/Movies]
        public ActionResult Index()
        {
            var viewModelML = new MovieViewModel {
                movieList = GetMovieDB()
            };
            return View(viewModelML);
        }


        // Selecting a movie object page.
        [Route("movies/view/{ID}")]
        public ActionResult SelectedMovie(int ID)
        {
            var list = new List<Movie> { };
            list = GetMovieDB();
            Movie findmovie = list.Find (Movie => Movie.Id == ID);
            var viewModelML1 = new SelectedMovieViewModel
            {
                Movie = findmovie
            };

            return View(viewModelML1);
        }

        [Route("movies/released/{year:regex(\\d{4})}/{month:regex(\\d{2}):range(1,12)}")]
        public ActionResult ByReleaseDate(int year, int month )
        {
            return Content(year + "/" + month);
        }

      

    }
}
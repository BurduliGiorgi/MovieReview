using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using MovieReview.Models;
using MovieReview.Repos;
using MovieReview.Services;
using System.Collections.Specialized;
using System.Net;

namespace MovieReview.Controllers
{
    public class MovieController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IMovieRepository _movieRepository;
        private readonly ILogger<MovieController> _logger;
        public MovieController(ApplicationDbContext context, MovieRepository movieRepository, ILogger<MovieController> logger)
        {
            _movieRepository = movieRepository;
            _context = context;
            _logger = logger;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult GetAllMovies()
        {
            //get all movie
            List<Movie> allMovie = _movieRepository.GetAllMovies();

            //return all movie
            return View(allMovie);
        }

        [HttpGet]
        public IActionResult GetMovieById(int movieId)
        {
            try
            {
                // get movie by id
                Movie movie = _movieRepository.GetMovieById(movieId);
                //if no movie
                if (movie == null)
                {
                    return NotFound();
                }
                return View(movie);
            }
            catch (Exception ex)
            {
                // log the exception
                _logger.LogError($"Error retrieving movie with ID {movieId}: {ex.Message}");
                return StatusCode(500, "A problem occurred while handling your request.");
            }
        }

        [HttpPost]
        public IActionResult AddMovie(string title, string description, decimal rating)
        {
            try
            {

                if (_context.Movies.Any(u => u.Title == title))
                {
                    ModelState.AddModelError("Title", "Movie title already exists.");
                    return View();
                }
                var newMovie = new Movie
                {
                    Title = title,
                    Description = description,
                    Rating = rating,
                    ReleaseDate = DateTime.Now
                };


                // Add movie to the database
                _context.Add(newMovie);
                _context.SaveChanges();

                //show movie details
                return View(newMovie);
            }
            catch (Exception ex)
            {
                // log the exception
                ModelState.AddModelError(string.Empty, "An unexpected error occurred. Please try again later.");
                return View();
            }
        }

        [HttpPut]
        public IActionResult UpdateMovie(string title, string description, decimal rating, int movieId)
        {
            try
            {
                var oldMovie = _movieRepository.GetMovieById(movieId);

                if (oldMovie == null)
                {
                    return NotFound(); // Handle case where movie with given id is not found
                }

                // Update movie properties
                oldMovie.Title = title;
                oldMovie.Description = description;
                oldMovie.Rating = rating;

                // Update movie in the database
                _movieRepository.UpdateMovie(oldMovie); // Assuming UpdateMovie method exists in repository
                _context.SaveChanges(); // If using DbContext directly

                return View(oldMovie);
            }
            catch(Exception ex)
            {
                //log exception
                _logger.LogError($"Error updating movie with ID {movieId}: {ex.Message}");

                return StatusCode(500, "A problem occurred while handling your request.");
            }
        }

        [HttpDelete]
        public IActionResult DeleteMovie(int movieId)
        {
            try
            {
                //see if there is movie to delete
                var movieToDelete = _movieRepository.GetMovieById(movieId);
                if (movieToDelete == null)
                {
                    return NotFound();
                }

                //delete movie
                _movieRepository.DeleteMovie(movieId);
                _context.SaveChanges();

                return View();
            }
            catch (Exception ex)
            {
                //log exception
                _logger.LogError($"Error deleting movie with ID {movieId}: {ex.Message}");

                return StatusCode(500, "A problem occurred while handling your request.");
            }
        }

    }
}
//everything is not finished, please can you add movie list in context. have a good day:)

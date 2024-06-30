using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using MovieReview.Models;
using MovieReview.Repos;
using MovieReview.Services;
using System.Collections.Specialized;
using System.Net;

namespace MovieReview.Controllers
{
    public class RatingController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IRatingRepository _ratingRepository;
        private readonly ILogger<RatingController> _logger;
        public RatingController(ApplicationDbContext context, RatingRepository ratingRepository, ILogger<RatingController> logger)
        {
            _ratingRepository = ratingRepository;
            _context = context;
            _logger = logger;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult GetRatingByMovieId(int movieId)
        {
            try
            {
                // get rating by id
                Rating rating = _ratingRepository.GetRatingsByMovieId(movieId);
                //if no ratings
                if (rating == null)
                {
                    return NotFound();
                }
                return View(rating);
            }
            catch (Exception ex)
            {
                // log the exception
                _logger.LogError($"Error retrieving rating with ID {movieId}: {ex.Message}");
                return StatusCode(500, "A problem occurred while handling your request.");
            }
        }

        [HttpPost]
        public IActionResult AddRating(int userId, int movieId, int ratingValue)
        {
            try
            {
                var newRating = new Rating
                {
                    UserId = userId,
                    MovieId = movieId,
                    RatingValue = ratingValue,
                    CreatedAt = DateTime.Now
                };


                // Add rating to the database
                _context.Add(newRating);
                _context.SaveChanges();

                //show review details
                return View(newRating);
            }
            catch (Exception ex)
            {
                // log the exception
                ModelState.AddModelError(string.Empty, "An unexpected error occurred. Please try again later.");
                return View();
            }
        }

        [HttpPut]
        public IActionResult UpdateRating(int ratingValue, int ratingId)
        {
            try
            {
                var oldRating = _ratingRepository.GetRatingById(ratingId);

                if (oldRating == null)
                {
                    return NotFound();
                }

                // Update rating properties
                oldRating.RatingValue = ratingValue;

                // Update rating in the database
                _ratingRepository.UpdateRating(oldRating);
                _context.SaveChanges();

                return View(oldRating);
            }
            catch (Exception ex)
            {
                //log exception
                _logger.LogError($"Error updating rating with ID {ratingId}: {ex.Message}");

                return StatusCode(500, "A problem occurred while handling your request.");
            }
        }

        [HttpDelete]
        public IActionResult DeleteReview(int ratingId)
        {
            try
            {
                //see if there is rating to delete
                var ratingToDelete = _ratingRepository.GetRatingById(ratingId);
                if (ratingToDelete == null)
                {
                    return NotFound();
                }

                //delete rating
                _ratingRepository.DeleteRating(ratingId);
                _context.SaveChanges();

                return View();
            }
            catch (Exception ex)
            {
                //log exception
                _logger.LogError($"Error deleting rating with ID {ratingId}: {ex.Message}");

                return StatusCode(500, "A problem occurred while handling your request.");
            }
        }

    }
}
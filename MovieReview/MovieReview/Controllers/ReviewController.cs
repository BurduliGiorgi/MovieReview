using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using MovieReview.Models;
using MovieReview.Repos;
using MovieReview.Services;
using System.Collections.Specialized;
using System.Net;

namespace MovieReview.Controllers
{
    public class ReviewController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IReviewRepository _reviewRepository;
        private readonly ILogger<ReviewController> _logger;
        public ReviewController(ApplicationDbContext context, ReviewRepository reviewRepository, ILogger<ReviewController> logger)
        {
            _reviewRepository = reviewRepository;
            _context = context;
            _logger = logger;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult GetReviewByMovieId(int movieId)
        {
            try
            {
                // get review by id
                Review review = _reviewRepository.GetReviewsByMovieId(movieId);
                //if no review
                if (review == null)
                {
                    return NotFound();
                }
                return View(review);
            }
            catch (Exception ex)
            {
                // log the exception
                _logger.LogError($"Error retrieving review with ID {movieId}: {ex.Message}");
                return StatusCode(500, "A problem occurred while handling your request.");
            }
        }

        [HttpPost]
        public IActionResult AddReview(int UserId, int movieId, int rating, string reviewText)
        {
            try
            {
                var newReview = new Review
                {
                    UserId = UserId,
                    MovieId = movieId,
                    Rating = rating,
                    ReviewText = reviewText,
                    CreatedAt = DateTime.Now
                };


                // Add review to the database
                _context.Add(newReview);
                _context.SaveChanges();

                //show review details
                return View(newReview);
            }
            catch (Exception ex)
            {
                // log the exception
                ModelState.AddModelError(string.Empty, "An unexpected error occurred. Please try again later.");
                return View();
            }
        }

        [HttpPut]
        public IActionResult UpdateReview(int rating, string reviewText, int reviewId)
        {
            try
            {
                var oldReview = _reviewRepository.GetReviewById(reviewId);

                if (oldReview == null)
                {
                    return NotFound();
                }

                // Update review properties
                oldReview.Rating = rating;
                oldReview.ReviewText = reviewText;

                // Update review in the database
                _reviewRepository.UpdateReview(oldReview);
                _context.SaveChanges();

                return View(oldReview);
            }
            catch (Exception ex)
            {
                //log exception
                _logger.LogError($"Error updating review with ID {reviewId}: {ex.Message}");

                return StatusCode(500, "A problem occurred while handling your request.");
            }
        }

        [HttpDelete]
        public IActionResult DeleteReview(int reviewId)
        {
            try
            {
                //see if there is rating to delete
                var reviewToDelete = _reviewRepository.GetReviewById(reviewId);
                if (reviewToDelete == null)
                {
                    return NotFound();
                }

                //delete rating
                _reviewRepository.DeleteReview(reviewId);
                _context.SaveChanges();

                return View();
            }
            catch (Exception ex)
            {
                //log exception
                _logger.LogError($"Error deleting review with ID {reviewId}: {ex.Message}");

                return StatusCode(500, "A problem occurred while handling your request.");
            }
        }

    }
}
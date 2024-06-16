using MovieReview.Models;
using MovieReview.Repos;
using System.Collections.Generic;

namespace MovieReview.Services
{
    public class ReviewService
    {
        private readonly IReviewRepository _reviewRepository;

        public ReviewService(IReviewRepository reviewRepository)
        {
            _reviewRepository = reviewRepository;
        }

        public Review GetReviewById(int reviewId)
        {
            return _reviewRepository.GetReviewById(reviewId);
        }

        public List<Review> GetReviewsByMovieId(int movieId)
        {
            return _reviewRepository.GetReviewsByMovieId(movieId);
        }

        public void AddReview(Review newReview)
        {
            _reviewRepository.AddReview(newReview);
        }

        public Review UpdateReview(Review updatedReview)
        {
            return _reviewRepository.UpdateReview(updatedReview);
        }

        public void DeleteReview(int reviewId)
        {
            _reviewRepository.DeleteReview(reviewId);
        }
    }
}

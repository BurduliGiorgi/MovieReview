using System.Collections.Specialized;
using MovieReview.Models;

namespace MovieReview.Repos
{
    public interface IReviewRepository
    {
        public Review GetReviewById(int reviewId);
        public List<Review> GetReviewsByMovieId(int movieId);
        public void AddReview(Review newReview);
        public Review UpdateReview(Review updatedReview);
        public void DeleteReview(int reviewId);
    }
}

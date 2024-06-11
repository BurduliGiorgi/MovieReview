using MovieReview.Models;

namespace MovieReview.Repos
{
    public class ReviewRepository : IReviewRepository
    {
        private List<Review> reviews;

        public ReviewRepository()
        {
            reviews = new List<Review>();

        }

        // get review by id
        public Review GetReviewById(int reviewId)
        {
            return reviews.Find(review => review.Id == reviewId.ToString());
        }

        // get reviews by movie id
        public List<Review> GetReviewsByMovieId(int movieId)
        {
            return reviews.find(review=> review.movieId == movieId.ToString());
        }

        // add new review
        public void AddReview(Review newReview)
        {
            reviews.Add(newReview);
        }

        // update review
        public Review UpdateReview(Review updatedReview)
        {
            int index = reviews.FindIndex(review => review.Id == updatedReview.Id);
            reviews[index] = updatedReview;
            return updatedReview;
        }

        // delete review by id
        public void DeleteReview(int reviewId)
        {
            int index = reviews.FindIndex(review => review.Id == reviewId.ToString());
            reviews.RemoveAt(index);
        }
    }
}

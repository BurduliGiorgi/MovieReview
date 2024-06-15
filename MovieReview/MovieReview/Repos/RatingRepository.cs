using MovieReview.Models;

namespace MovieReview.Repos
{
    public class RatingRepository : IRatingRepository
    {
        private List<Rating> ratings;

        public RatingRepository()
        {
            ratings = new List<Rating>();

        }

        // get rating by id
        public Rating GetRatingById(int ratingId)
        {
            return ratings.Find(rating => rating.Id == ratingId.ToString());
        }

        // get reviews by movie id
        public List<Rating> GetRatingsByMovieId(int movieId)
        {
            return ratings.find(rating => rating.movieId == movieId.ToString());
        }

        // add new review
        public void AddRating(Rating newRatings)
        {
            ratings.Add(newRatings);
        }

        // update review
        public Rating UpdateRating(Rating updatedRating)
        {
            int index = ratings.FindIndex(rating => rating.Id == updatedRating.Id);
            reviews[index] = updatedRating;
            return updatedRating;
        }

        // delete review by id
        public void DeleteReview(int ratingId)
        {
            int index = ratings.FindIndex(rating => rating.Id == ratingId.ToString());
            ratings.RemoveAt(index);
        }
    }
}

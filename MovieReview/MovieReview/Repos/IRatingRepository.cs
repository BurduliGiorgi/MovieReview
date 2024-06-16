using MovieReview.Models;
using System.Collections.Generic;

namespace MovieReview.Repos
{
    public interface IRatingRepository
    {
        public Rating GetRatingById(int ratingId); 
        public List<Rating> GetRatingsByMovieId(int movieId);
        public void AddRating(Rating newRating);
        public Rating UpdateRating(Rating updatedRating);
        public void DeleteRating(int ratingId);
    }
}

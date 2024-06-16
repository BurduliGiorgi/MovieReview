using MovieReview.Models;
using System.Collections.Generic;

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
            return ratings.Find(rating => rating.Id == ratingId);
        }

        // get ratings by movie id
        public List<Rating> GetRatingsByMovieId(int movieId)
        {
            return ratings.FindAll(rating => rating.MovieId == movieId);
        }

        // add new rating
        public void AddRating(Rating newRating)
        {
            ratings.Add(newRating);
        }

        // update rating
        public Rating UpdateRating(Rating updatedRating)
        {
            int index = ratings.FindIndex(rating => rating.Id == updatedRating.Id);
            if (index != -1)
            {
                ratings[index] = updatedRating;
            }
            return updatedRating;
        }

        // delete rating by id
        public void DeleteRating(int ratingId)
        {
            int index = ratings.FindIndex(rating => rating.Id == ratingId);
            if (index != -1)
            {
                ratings.RemoveAt(index);
            }
        }
    }
}

using MovieReview.Models;
using MovieReview.Repos;
using System.Collections.Generic;

namespace MovieReview.Services
{
    public class RatingService
    {
        private readonly IRatingRepository _ratingRepository;

        public RatingService(IRatingRepository ratingRepository)
        {
            _ratingRepository = ratingRepository;
        }

        public Rating GetRatingById(int ratingId)
        {
            return _ratingRepository.GetRatingById(ratingId);
        }

        public List<Rating> GetRatingsByMovieId(int movieId)
        {
            return _ratingRepository.GetRatingsByMovieId(movieId);
        }

        public void AddRating(Rating newRating)
        {
            _ratingRepository.AddRating(newRating);
        }

        public Rating UpdateRating(Rating updatedRating)
        {
            return _ratingRepository.UpdateRating(updatedRating);
        }

        public void DeleteRating(int ratingId)
        {
            _ratingRepository.DeleteRating(ratingId);
        }
    }
}


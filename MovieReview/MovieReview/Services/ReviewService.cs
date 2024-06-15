using System;
using MovieReview.Models;
using MovieReview.Repos;

public class ReviewService
{
    private readonly IReviewRepository _reviewRepository;
    private readonly IUserRepository _userRepository;
    private readonly IMovieRepository _movieRepository;

    public ReviewService(IReviewRepository reviewRepository, IUserRepository userRepository, IMovieRepository movieRepository)
    {
        _reviewRepository = reviewRepository;
        _userRepository = userRepository;
        _movieRepository = movieRepository;
    }

    public bool AddReview(int userId, int movieId, int rating, string reviewText)
    {
        if (_userRepository.GetUserById(userId) == null)
            throw new ArgumentException("User does not exist.");

        if (_movieRepository.GetMovieById(movieId) == null)
            throw new ArgumentException("Movie does not exist.");

        if (rating < 1 || rating > 5)
            throw new ArgumentException("Rating must be between 1 and 5.");

        if (string.IsNullOrWhiteSpace(reviewText))
            throw new ArgumentException("Review text cannot be empty.");

        var review = new Review
        {
            UserId = userId,
            MovieId = movieId,
            Rating = rating,
            ReviewText = reviewText,
            CreatedAt = DateTime.UtcNow
        };

        _reviewRepository.AddReview(review);
        return true;
    }

    public bool UpdateReview(int reviewId, int userId, string newReviewText, int newRating)
    {
        var review = _reviewRepository.GetReviewById(reviewId);
        if (review == null || review.UserId != userId)
            throw new ArgumentException("Review does not exist or does not belong to user.");

        if (newRating < 1 || newRating > 5)
            throw new ArgumentException("New rating must be between 1 and 5.");

        if (string.IsNullOrWhiteSpace(newReviewText))
            throw new ArgumentException("New review text cannot be empty.");

        review.ReviewText = newReviewText;
        review.Rating = newRating;
        _reviewRepository.UpdateReview(review);
        return true;
    }

    public bool DeleteReview(int reviewId, int userId)
    {
        var review = _reviewRepository.GetReviewById(reviewId);
        if (review == null || review.UserId != userId)
            throw new ArgumentException("Review does not exist or does not belong to user.");

        _reviewRepository.DeleteReview(reviewId);
        return true;
    }

    public List<Review> GetReviewsByMovieId(int movieId)
    {
        return _reviewRepository.GetReviewsByMovieId(movieId);
    }
}

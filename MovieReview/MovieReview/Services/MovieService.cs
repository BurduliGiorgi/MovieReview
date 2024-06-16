using MovieReview.Models;
using MovieReview.Repos;
using System.Collections.Generic;

namespace MovieReview.Services
{
    public class MovieService
    {
        private readonly IMovieRepository _movieRepository;

        public MovieService(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public Movie GetMovieById(int movieId)
        {
            return _movieRepository.GetMovieById(movieId);
        }

        public List<Movie> GetAllMovies()
        {
            return _movieRepository.GetAllMovies();
        }

        public void AddMovie(Movie newMovie)
        {
            _movieRepository.AddMovie(newMovie);
        }

        public Movie UpdateMovie(Movie updatedMovie)
        {
            return _movieRepository.UpdateMovie(updatedMovie);
        }

        public void DeleteMovie(int movieId)
        {
            _movieRepository.DeleteMovie(movieId);
        }
    }
}

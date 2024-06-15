using System;
using MovieReview.Models;
using MovieReview.Repos;

public class MovieService
{
    private readonly IMovieRepository _movieRepository;

    public MovieService(IMovieRepository movieRepository)
    {
        _movieRepository = movieRepository;
    }

    public void AddMovie(string title, string description, DateTime releaseDate)
    {
        if (string.IsNullOrWhiteSpace(title))
            throw new ArgumentException("Title cannot be empty.");

        if (releaseDate > DateTime.Now)
            throw new ArgumentException("Release date cannot be in the future.");

        var newMovie = new Movie
        {
            Title = title,
            Description = description,
            ReleaseDate = releaseDate
        };

        _movieRepository.AddMovie(newMovie);
    }

    public void UpdateMovie(int movieId, string title, string description, DateTime releaseDate)
    {
        var movie = _movieRepository.GetMovieById(movieId);
        if (movie == null)
            throw new ArgumentException("Movie not found.");

        if (string.IsNullOrWhiteSpace(title))
            throw new ArgumentException("Title cannot be empty.");

        if (releaseDate > DateTime.Now)
            throw new ArgumentException("Release date cannot be in the future.");

        movie.Title = title;
        movie.Description = description;
        movie.ReleaseDate = releaseDate;

        _movieRepository.UpdateMovie(movie);
    }

    public Movie GetMovieDetails(int movieId)
    {
        return _movieRepository.GetMovieById(movieId);
    }

    public void DeleteMovie(int movieId)
    {
        var movie = _movieRepository.GetMovieById(movieId);
        if (movie == null)
            throw new ArgumentException("Movie not found.");

        _movieRepository.DeleteMovie(movieId);
    }
}

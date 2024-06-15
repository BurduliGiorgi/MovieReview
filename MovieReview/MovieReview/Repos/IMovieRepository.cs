using MovieReview.Models;

namespace MovieReview.Repos
{
    public interface IMovieRepository
    {
        public Movie GetMovieById(int movieId);
        public List<Movie> GetAllMovies();
        public void AddMovie(Movie newMovie);
        public Movie UpdateMovie(Movie updatedMovie);
        public void DeleteMovie(int movieId);

    }
}

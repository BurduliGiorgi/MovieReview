using MovieReview.Models;

namespace MovieReview.Repos
{
    public class MovieRepository : IMovieRepository
    {
        private List<Movie> movies;

        public MovieRepository()
        {
            movies = new List<Movie>();
        }

        // get movie by id
        public Movie GetMovieById(int movieId)
        {
            return movies.Find(movie => movie.Id == movieId);
        }

        // get all movies
        public List<Movie> GetAllMovies()
        {
            return movies;
        }

        // add new movie
        public void AddMovie(Movie newMovie)
        {
            movies.Add(newMovie);
        }

        // update movie
        public Movie UpdateMovie(Movie updatedMovie)
        {
            int index = movies.FindIndex(movie => movie.Id == updatedMovie.Id);
            if (index != -1)
            {
                movies[index] = updatedMovie;
            }
            return updatedMovie;
        }

        // delete movie by id
        public void DeleteMovie(int movieId)
        {
            int index = movies.FindIndex(movie => movie.Id == movieId);
            if (index != -1)
            {
                movies.RemoveAt(index);
            }
        }
    }
}

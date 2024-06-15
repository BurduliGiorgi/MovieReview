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

        // get user by id
        public ApplicationUser GetMovieById(int movieId)
        {
            return movies.Find(movie => movie.Id == userId.ToString());
        }

        // get all users
        public List<Movie> GetAllMovies()
        {
            return movies;
        }

        // add new user
        public void AddMovie(Movie newMovie)
        {
            users.Add(newMovie);
        }

        // update user
        public Movie UpdateMovie(Movie updatedMovie)
        {
            int index = movies.FindIndex(movie => movie.Id == updatedMovie.Id);
            movies[index] = updatedMovie;
            return updatedMovie;
        }

        // delete user by id
        public void DeleteUser(int movieId)
        {
            int index = users.FindIndex(movie => movie.Id == movieId.ToString());
            movies.RemoveAt(index);
        }
    }
}

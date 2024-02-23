using RepositoryPatternTemplate.Context;
using RepositoryPatternTemplate.Models;

namespace RepositoryPatternTemplate.Repository
{
    public class MovieRepository : IMovieRepository
    {
        private readonly IMovieContext _movieContext;

        public MovieRepository(IMovieContext movieContext)
        {
            _movieContext = movieContext;
        }

        public void AddMovie(Movie movie)
        {
            _movieContext.AddMovie(movie);
            Console.WriteLine("Added movie: " + movie.Title);
        }

        public Movie GetMovie(long id)
        {
            var retrievedMovie = _movieContext.GetMovie(id);
            Console.WriteLine("Retrieved movie: " + retrievedMovie.Title);
            return retrievedMovie;
        }

        public void UpdateMovie(Movie movie)
        {
            _movieContext.UpdateMovie(movie);
            Console.WriteLine("Updated movie genres: " + string.Join(", ", movie.Genres));
        }

        public void DeleteMovie(long id)
        {
            _movieContext.DeleteMovie(id);
            Console.WriteLine("Deleted movie with ID " + id);
        }

        public List<Movie> GetAllMovies()
        {
            var allMovies = _movieContext.GetAllMovies();
            Console.WriteLine("All movies:");
            foreach (var m in allMovies)
            {
                Console.WriteLine($"{m.Id}: {m.Title} - {string.Join(", ", m.Genres)}");
            }

            return allMovies;
        }
    }
}

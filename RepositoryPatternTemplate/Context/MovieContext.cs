using RepositoryPatternTemplate.Models;
using RepositoryPatternTemplate.Repository;

namespace RepositoryPatternTemplate.Context
{
    public class MovieContext : IMovieContext
    {
        private readonly IMovieRepository _movieRepository;

        public MovieContext(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public void AddMovie(Movie movie)
        {
            _movieRepository.AddMovie(movie);
            Console.WriteLine("Added movie: " + movie.Title);
        }

        public Movie GetMovie(long id)
        {
            var retrievedMovie = _movieRepository.GetMovie(id);
            Console.WriteLine("Retrieved movie: " + retrievedMovie.Title);
            return retrievedMovie;
        }

        public void UpdateMovie(Movie movie)
        {
            _movieRepository.UpdateMovie(movie);
            Console.WriteLine("Updated movie genres: " + string.Join(", ", movie.Genres));
        }

        public void DeleteMovie(long id)
        {
            _movieRepository.DeleteMovie(id);
            Console.WriteLine("Deleted movie with ID " + id);
        }

        public List<Movie> GetAllMovies()
        {
            var allMovies = _movieRepository.GetAllMovies();
            Console.WriteLine("All movies:");
            foreach (var m in allMovies)
            {
                Console.WriteLine($"{m.Id}: {m.Title} - {string.Join(", ", m.Genres)}");
            }

            return allMovies;
        }
    }
}

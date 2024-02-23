using RepositoryPatternTemplate.Models;
using RepositoryPatternTemplate.Repository;

namespace RepositoryPatternTemplate.Services
{
    public class MainService : IMainService
    {
        private readonly IMovieRepository _movieRepository;

        public MainService(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public void Invoke()
        {
            // Simple implementation: Add a new movie
            var newMovie = new Movie
            {
                Id = 1,
                Title = "New Movie",
                Genres = new List<string> { "Action", "Adventure" }
            };

            _movieRepository.AddMovie(newMovie);
        }
    }
}

using RepositoryPatternTemplate.Models;
using RepositoryPatternTemplate.Context;

namespace RepositoryPatternTemplate.Services
{
    public class MainService : IMainService
    {
        private readonly IMovieContext _movieContext;

        public MainService(IMovieContext movieContext)
        {
            _movieContext = movieContext;
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

            _movieContext.AddMovie(newMovie);
        }
    }
}

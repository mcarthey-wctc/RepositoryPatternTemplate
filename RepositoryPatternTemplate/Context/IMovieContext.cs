using RepositoryPatternTemplate.Models;

namespace RepositoryPatternTemplate.Context
{
    public interface IMovieContext
    {
        void AddMovie(Movie movie);
        Movie GetMovie(long id);
        void UpdateMovie(Movie movie);
        void DeleteMovie(long id);
        List<Movie> GetAllMovies();
    }
}

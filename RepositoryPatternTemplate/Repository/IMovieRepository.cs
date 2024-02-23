using RepositoryPatternTemplate.Models;

namespace RepositoryPatternTemplate.Repository
{
    public interface IMovieRepository
    {
        void AddMovie(Movie movie);
        Movie GetMovie(long id);
        void UpdateMovie(Movie movie);
        void DeleteMovie(long id);
        List<Movie> GetAllMovies();
    }
}

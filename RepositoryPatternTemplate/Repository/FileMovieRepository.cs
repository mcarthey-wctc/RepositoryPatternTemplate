using Newtonsoft.Json;
using RepositoryPatternTemplate.Models;

namespace RepositoryPatternTemplate.Repository;

public class FileMovieRepository : IMovieRepository
{
    private readonly string _filePath;

    public FileMovieRepository(string filePath)
    {
        _filePath = filePath;

        // Create the directory and file if they do not exist
        var directory = Path.GetDirectoryName(_filePath);
        if (!Directory.Exists(directory))
        {
            Directory.CreateDirectory(directory);
        }
        if (!File.Exists(_filePath))
        {
            File.Create(_filePath).Close();
        }
    }

    public void AddMovie(Movie movie)
    {
        //// TODO : Implement this method
    }

    public Movie GetMovie(long id)
    {
        // TODO : Implement this method
        return new Movie();
    }

    public void UpdateMovie(Movie movie)
    {
        // TODO : Implement this method
    }

    public void DeleteMovie(long id)
    {
        // TODO : Implement this method
    }

    public List<Movie> GetAllMovies()
    {
        if (!File.Exists(_filePath))
            return new List<Movie>();

        var json = File.ReadAllText(_filePath);
        return JsonConvert.DeserializeObject<List<Movie>>(json) ?? new List<Movie>();
    }

    private void SaveMoviesToFile(List<Movie> movies)
    {
        var json = JsonConvert.SerializeObject(movies, Formatting.Indented);
        File.WriteAllText(_filePath, json);
    }
}
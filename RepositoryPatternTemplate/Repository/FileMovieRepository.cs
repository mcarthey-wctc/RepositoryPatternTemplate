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
        // TODO : Implement this method
        // 1. Get all movies from the file using GetAllMovies method
        // 2. Add the new movie to the list
        // 3. Save the updated list back to the file using SaveMoviesToFile method
    }

    public Movie GetMovie(long id)
    {
        // TODO : Implement this method
        // 1. Get all movies from the file using GetAllMovies method
        // 2. Find the movie with the given id in the list
        // 3. Return the found movie
        return null;
    }

    public void UpdateMovie(Movie movie)
    {
        // TODO : Implement this method
        // 1. Get all movies from the file using GetAllMovies method
        // 2. Find the index of the movie with the same id as the given movie
        // 3. Replace the movie at the found index with the given movie
        // 4. Save the updated list back to the file using SaveMoviesToFile method
    }

    public void DeleteMovie(long id)
    {
        // TODO : Implement this method
        // 1. Get all movies from the file using GetAllMovies method
        // 2. Remove the movie with the given id from the list
        // 3. Save the updated list back to the file using SaveMoviesToFile method
    }

    public List<Movie> GetAllMovies()
    {
        // If the file does not exist, return an empty list
        if (!File.Exists(_filePath))
            return new List<Movie>();

        // Read the content of the file and deserialize it to a list of movies
        var json = File.ReadAllText(_filePath);
        return JsonConvert.DeserializeObject<List<Movie>>(json) ?? new List<Movie>();
    }

    private void SaveMoviesToFile(List<Movie> movies)
    {
        // Serialize the list of movies to JSON and write it to the file
        var json = JsonConvert.SerializeObject(movies, Formatting.Indented);
        File.WriteAllText(_filePath, json);
    }
}

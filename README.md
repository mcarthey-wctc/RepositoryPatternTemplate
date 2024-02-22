# Assignment: Implementing a File-Based Movie Repository

In this assignment, you will be implementing a file-based movie repository using C#. The repository will be responsible for performing CRUD operations (Create, Read, Update, Delete) on a collection of movies.

## Instructions

1. **Familiarize yourself with the provided code:** The provided code is a skeleton for a file-based movie repository. The repository is initialized with a file path, and it ensures that the file exists before any operations are performed.

2. **Implement the `AddMovie` method:** This method should add a new movie to the repository. You will need to:
    - Get all movies from the file using the `GetAllMovies` method.
    - Add the new movie to the list.
    - Save the updated list back to the file using the `SaveMoviesToFile` method.

3. **Implement the `GetMovie` method:** This method should return a movie with a given id. You will need to:
    - Get all movies from the file using the `GetAllMovies` method.
    - Find the movie with the given id in the list.
    - Return the found movie.

4. **Implement the `UpdateMovie` method:** This method should update a movie in the repository. You will need to:
    - Get all movies from the file using the `GetAllMovies` method.
    - Find the index of the movie with the same id as the given movie.
    - Replace the movie at the found index with the given movie.
    - Save the updated list back to the file using the `SaveMoviesToFile` method.

5. **Implement the `DeleteMovie` method:** This method should delete a movie with a given id from the repository. You will need to:
    - Get all movies from the file using the `GetAllMovies` method.
    - Remove the movie with the given id from the list.
    - Save the updated list back to the file using the `SaveMoviesToFile` method.

## Evaluation

Your assignment will be evaluated based on the following criteria:

- Correctness: Does your code correctly implement the required functionality?
- Readability: Is your code easy to understand?
- Code organization: Is your code well-structured and logically organized?

## Submission

Please submit your completed `FileMovieRepository.cs` file by the due date. Good luck!

## Resources

- [C# Documentation](https://docs.microsoft.com/en-us/dotnet/csharp/)
- [JSON.NET Documentation](https://www.newtonsoft.com/json/help/html/Introduction.htm)
- [File I/O in C#](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/file-system/how-to-read-from-and-write-to-a-text-file)

using Moq;
using RepositoryPatternTemplate.Models;
using RepositoryPatternTemplate.Context;
using RepositoryPatternTemplate.Services;

namespace RepositoryPatternTemplate.Tests
{
    public class RepositoryPatternTemplateUnitTests
    {
        private readonly Mock<IMovieContext> _mockMovieContext;
        private readonly MainService _mainService;

        public RepositoryPatternTemplateUnitTests()
        {
            _mockMovieContext = new Mock<IMovieContext>();
            _mainService = new MainService(_mockMovieContext.Object);
        }

        [Fact]
        public void Invoke_AddsNewMovie()
        {
            // Arrange
            var expectedMovie = new Movie
            {
                Id = 1,
                Title = "New Movie",
                Genres = new List<string> { "Action", "Adventure" }
            };

            // Act
            _mainService.Invoke();

            // Assert
            _mockMovieContext.Verify(mc => mc.AddMovie(It.Is<Movie>(m =>
                m.Id == expectedMovie.Id &&
                m.Title == expectedMovie.Title &&
                m.Genres.SequenceEqual(expectedMovie.Genres))), Times.Once);
        }
    }
}

namespace RepositoryPatternTemplate.Models
{
    public class Movie
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public List<string> Genres { get; set; }
    }
}

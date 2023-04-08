namespace Conduit1.Models
{
    public class Article
    {
        public int ArticleId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Body { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool IsPublished { get; set; }

        public User? Author { get; set; }
        public int UserId { get; set; }
        public ICollection<Comment>? Comments { get; set; }
        public ICollection<Favorite>? Favorites { get; set; }
    }

}

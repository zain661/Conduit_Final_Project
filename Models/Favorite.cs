namespace Conduit1.Models
{
    public class Favorite
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ArticleId { get; set; }
        public User User { get; set; }
        public Article Article { get; set; }
    }
}

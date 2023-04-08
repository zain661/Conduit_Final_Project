using Microsoft.AspNetCore.Identity;

namespace Conduit1.Models
{
    public class User
    {
        public int UserId { get; set; }
        public int FollowerId { get; set; }
        public int FollowingId { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string? Bio { get; set; }
        public string? Image { get; set; }
        public ICollection<Article>? Articles { get; set; }
        public ICollection<Favorite>? Favorites { get; set; }
        public ICollection<Follow>? Followers { get; set; }
        public ICollection<Follow>? Following { get; set; }
        public ICollection<Comment>? Comments { get; set; }

    }

}

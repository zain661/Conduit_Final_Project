using Microsoft.EntityFrameworkCore;
using System.Runtime.Intrinsics.X86;

namespace Conduit1.Models
{
    public static class DbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            
            ConduitContext context = applicationBuilder.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<ConduitContext>();
            var users = new List<User>();


            if (!context.Users.Any())
            {
                users = new List<User>
                 {
               new User { Username = "user1", Email = "user1@example.com", Password = "password1" },
               new User { Username = "user2", Email = "user2@example.com", Password = "password2" },
               new User { Username = "user3", Email = "user3@example.com", Password = "password3" },
                 };

                context.Users.AddRange(users);
            }
            var articles = new List<Article>();
            if (!context.Articles.Any())
            {
                articles = new List<Article>
                {
              new Article { Title = "Article 1", Description = "This is the first article",
                Body = "Lorem ipsum dolor sit amet",
                CreatedAt= DateTime.Now,
                UpdatedAt= DateTime.Now,
                IsPublished = true,
                Author = users[0]
 },
            new Article { Title = "Article 2", Description = "This is the second article",
                Body = "consectetur adipiscing elit" ,
                IsPublished = true,Author = users[1]
                },
            new Article { Title = "Article 3", Description = "This is the third article",
                Body = "sed do eiusmod tempor incididunt" ,
                IsPublished = true,Author = users[2] }
        };

                context.Articles.AddRange(articles);
            }

            if (!context.Follows.Any())
            {
                var follow1 = new Follow { FollowerId = users[0].UserId, FollowingId = users[1].UserId };
                var follow2 = new Follow { FollowerId = users[0].UserId, FollowingId = users[2].UserId };
                var follow3 = new Follow { FollowerId = users[1].UserId, FollowingId = users[2].UserId };

                
                context.Follows.AddRange(follow1, follow2, follow3);
            }
                if (!context.Comments.Any())
            {
                var comments = new List<Comment>
        {
            new Comment { Body = "Comment 1",

            CreatedAt= DateTime.Now,
            UpdatedAt = DateTime.Now,
                User = users[0], Article = articles[1]},
            new Comment { Body = "Comment 2",User = users[1], Article = articles[2]},
            new Comment { Body = "Comment 3", User = users[2], Article = articles[0]},
        };

                context.Comments.AddRange(comments);

            }
            if (!context.Favorites.Any())
            {
                var favorites = new List<Favorite>
        {
            new Favorite {  User = users[0], Article = articles[1]},
            new Favorite {  User = users[1], Article = articles[2]},
            new Favorite {User = users[2], Article = articles[0]},
        };

                context.Favorites.AddRange(favorites);
            }










            context.SaveChanges();
        }
    }
}

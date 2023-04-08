using Microsoft.EntityFrameworkCore;

namespace Conduit1.Models
{
    public class ConduitContext : DbContext
    {
        public ConduitContext(DbContextOptions<ConduitContext> options) : base(options) { }

        public DbSet<Article> Articles { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Favorite> Favorites { get; set; }
        public DbSet<Follow> Follows { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Article>()
                .HasOne(a => a.Author)
                .WithMany(u => u.Articles)
                .HasForeignKey(a => a.UserId);


            modelBuilder.Entity<Follow>()
                    .HasKey(f => new { f.FollowerId, f.FollowingId });

            modelBuilder.Entity<Follow>()
                .HasOne(f => f.Follower)
                .WithMany(u => u.Followers)
                .HasForeignKey(f => f.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Follow>()
                .HasOne(f => f.Following)
                .WithMany(u => u.Following)
                .HasForeignKey(f => f.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Comment>()
                .HasOne(c => c.User)
                .WithMany(u => u.Comments)
                .HasForeignKey(c => c.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Comment>()
                 .HasOne(c => c.Article)
                 .WithMany(u => u.Comments)
                 .HasForeignKey(c => c.ArticleId)
                 .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Favorite>()
                 .HasKey(bc => new { bc.UserId, bc.ArticleId });

            modelBuilder.Entity<Favorite>()
                .HasOne(bc => bc.User)
                .WithMany(b => b.Favorites)
                .HasForeignKey(bc => bc.UserId)
                .OnDelete(DeleteBehavior.NoAction);


            modelBuilder.Entity<Favorite>()
                .HasOne(bc => bc.Article)
                .WithMany(c => c.Favorites)
                .HasForeignKey(bc => bc.ArticleId)
                .OnDelete(DeleteBehavior.NoAction);


        }



    }
}

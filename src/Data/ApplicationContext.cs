using Microsoft.EntityFrameworkCore;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Follow> Follows { get; set; }
        public DbSet<Like> Likes { get; set; }
        public DbSet<Repost> Reposts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // ========== USER ==========
            modelBuilder.Entity<User>()
                .HasIndex(u => u.Username)
                .IsUnique();

            // ========== FOLLOW ==========
            modelBuilder.Entity<Follow>()
                .HasOne(f => f.Follower)
                .WithMany(u => u.Following)
                .HasForeignKey(f => f.FollowerId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Follow>()
                .HasOne(f => f.Followed)
                .WithMany(u => u.Followers)
                .HasForeignKey(f => f.FollowedId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Follow>()
                .HasIndex(f => new { f.FollowerId, f.FollowedId })
                .IsUnique();

            // ========== POST ==========
            modelBuilder.Entity<Post>()
                .HasOne(p => p.User)
                .WithMany(u => u.Posts)
                .HasForeignKey(p => p.UserId);

            modelBuilder.Entity<Post>()
                .HasOne(p => p.ParentPost)
                .WithMany(p => p.Replies)
                .HasForeignKey(p => p.ParentPostId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Post>()
                .HasOne(p => p.QuotedPost)
                .WithMany(p => p.Quotes)
                .HasForeignKey(p => p.QuotedPostId)
                .OnDelete(DeleteBehavior.Restrict);

            // ========== LIKE ==========
            modelBuilder.Entity<Like>()
                .HasOne(l => l.Post)
                .WithMany(p => p.Likes)
                .HasForeignKey(l => l.PostId);

            modelBuilder.Entity<Like>()
                .HasOne(l => l.User)
                .WithMany(u => u.Likes)
                .HasForeignKey(l => l.UserId);

            modelBuilder.Entity<Like>()
                .HasIndex(l => new { l.PostId, l.UserId })
                .IsUnique();

            // ========== REPOST ==========
            modelBuilder.Entity<Repost>()
                .HasOne(r => r.Post)
                .WithMany(p => p.Reposts)
                .HasForeignKey(r => r.PostId);

            modelBuilder.Entity<Repost>()
                .HasOne(r => r.User)
                .WithMany(u => u.Reposts)
                .HasForeignKey(r => r.UserId);

            modelBuilder.Entity<Repost>()
                .HasIndex(r => new { r.PostId, r.UserId })
                .IsUnique();
        }
    }
}

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using YT_Community.Models;

namespace YT_Community.DBContext
{
    public class YoutubeCommunityContext : IdentityDbContext
    {
        public YoutubeCommunityContext(DbContextOptions<YoutubeCommunityContext> options) : base(options)
        {
        }

        public DbSet<VideoLink> VideoLinks { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<VideoLink>().HasData(
                new VideoLink
                {
                    VideoLinkId = new System.Guid("00000000-0000-0000-0000-000000000001"),
                    Domain = "Youtube",
                    Url = "https://www.youtube.com/watch?v=123456",
                    Description = "This is a video link",
                    PostedDate = DateTime.Parse("01-01-2025"),
                    UserId = new System.Guid("00000000-0000-0000-0000-000000000001")
                },
                new VideoLink
                {
                    VideoLinkId = new System.Guid("00000000-0000-0000-0000-000000000002"),
                    Domain = "Youtube",
                    Url = "https://www.youtube.com/watch?v=123457",
                    Description = "This is a video link",
                    PostedDate = DateTime.Parse("01-01-2025"),
                    UserId = new System.Guid("00000000-0000-0000-0000-000000000002")
                },
                new VideoLink
                {
                    VideoLinkId = new System.Guid("00000000-0000-0000-0000-000000000003"),
                    Domain = "Youtube",
                    Url = "https://www.youtube.com/watch?v=123458",
                    Description = "This is a video link",
                    PostedDate = DateTime.Parse("01-01-2025"),
                    UserId = new System.Guid("00000000-0000-0000-0000-000000000003")
                }
                );
            modelBuilder.Entity<User>().HasData(

                new User
                {
                    UserId = new System.Guid("00000000-0000-0000-0000-000000000001"),
                    UserName = "User1",
                    DateOfBirth = DateTime.Parse("01-01-2025"),
                    MobileNumber = 1234567890,
                    Email = "karthic@gmail.com",
                    PasswordHash = "123"
                },
                new User
                {
                    UserId = new System.Guid("00000000-0000-0000-0000-000000000002"),
                    UserName = "User2",
                    DateOfBirth = DateTime.Parse("01-01-2025"),
                    MobileNumber = 1234567890,
                    Email = "raja@gmail.com",
                    PasswordHash = "123"
                },
                new User
                {
                    UserId = new System.Guid("00000000-0000-0000-0000-000000000003"),
                    UserName = "User3",
                    DateOfBirth = DateTime.Parse("01-01-2025"),
                    MobileNumber = 1234567890,
                    Email = "kr@gmail.com",
                    PasswordHash = "123"
                });
        } 
    } 
}

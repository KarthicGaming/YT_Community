using System.ComponentModel.DataAnnotations;

namespace YT_Community.Models
{
    public class User
    {
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public DateTime DateOfBirth { get; set; }
        [MaxLength(10)]
        public long MobileNumber { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }

    }
}

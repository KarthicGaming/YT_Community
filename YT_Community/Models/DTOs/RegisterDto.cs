namespace YT_Community.Models.DTOs
{
    public class RegisterDto
    {
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int MobileNumber { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
    }
}

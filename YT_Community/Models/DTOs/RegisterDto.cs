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
        public Guid VideoLinkId { get; set; }
        public string Domain { get; set; }
        public string Url { get; set; }
        public string Description { get; set; }
        public DateTime PostedDate { get; set; }
    }
}

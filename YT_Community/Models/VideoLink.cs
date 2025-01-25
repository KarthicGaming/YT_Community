using System.ComponentModel.DataAnnotations.Schema;

namespace YT_Community.Models
{
    public class VideoLink
    {
        public Guid VideoLinkId { get; set; }
        public string Domain { get; set; }
        public string Url { get; set; }
        public string Description { get; set; }
        public DateTime PostedDate { get; set; }
        public Guid UserId { get; set; }
        [ForeignKey("UserId")]
        User User { get; set; }
    }
}

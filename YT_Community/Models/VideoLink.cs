﻿using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace YT_Community.Models
{
    public class VideoLink
    {
        public Guid VideoLinkId { get; set; }
        public string Domain { get; set; }
        public string Url { get; set; }
        public string? Description { get; set; }
        public DateTime PostedDate { get; set; }
        [ValidateNever]
        public Guid UserId { get; set; }
        [ForeignKey("UserId")]
        [ValidateNever]
        public User User { get; set; }
    }
}

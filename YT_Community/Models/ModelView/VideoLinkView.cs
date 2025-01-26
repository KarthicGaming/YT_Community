using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace YT_Community.Models.ModelView
{
    public class VideoLinkView
    {
        public VideoLink videoLink{ get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> UserList { get; set; }
    }
}

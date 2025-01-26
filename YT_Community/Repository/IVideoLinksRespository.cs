using YT_Community.Models;

namespace YT_Community.Repository
{
    public interface IVideoLinksRespository
    {
        public Task<List<VideoLink>> GetAll(string? includeProperties = null);
        public Task<VideoLink> GetById(Guid? id, string? includeProperties = null);
        public VideoLink CreateLink(VideoLink user);
        public VideoLink UpdateLink(VideoLink user);
        public VideoLink DeleteLink(VideoLink user);
    }
}

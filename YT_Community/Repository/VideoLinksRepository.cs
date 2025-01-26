using System;
using Microsoft.EntityFrameworkCore;
using YT_Community.DBContext;
using YT_Community.Models;

namespace YT_Community.Repository
{
    public class VideoLinksRepository : IVideoLinksRespository
    {
        private readonly YoutubeCommunityContext _context;

        public VideoLinksRepository(YoutubeCommunityContext youtubeCommunityContext)
        {
            _context = youtubeCommunityContext;
            _context.VideoLinks.Include(u => u.User); 
        }
        public VideoLink CreateLink(VideoLink videoLink)
        {
            videoLink.VideoLinkId = new Guid();
            _context.VideoLinks.Add(videoLink);
            _context.SaveChanges();
            return videoLink;
        }

        public VideoLink DeleteLink(VideoLink user)
        {
            _context.VideoLinks.Remove(user);
            _context.SaveChanges();
            return user;
        }

        public async Task<List<VideoLink>> GetAll(string? includeProperties = null)
        {
            IQueryable<VideoLink> query = _context.VideoLinks;
            if (includeProperties != null)
            {
                foreach (var includeProperty in includeProperties
                    .Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }
            }
            var result = await query.ToListAsync();
            return result;
        }

        public async Task<VideoLink> GetById(Guid? guid, string? includeProperties = null)
        {
            IQueryable<VideoLink> query = _context.VideoLinks;
            if (includeProperties != null)
            {
                foreach (var includeProperty in includeProperties
                    .Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }
            }
            var user = await query.FirstOrDefaultAsync(u => u.VideoLinkId == guid);
            if (user != null)
            {
                return user;
            }
            return new VideoLink();
        }

        public VideoLink UpdateLink(VideoLink video)
        {
            _context.VideoLinks.Update(video);
            _context.SaveChanges();
            return video;
        }
    }
}

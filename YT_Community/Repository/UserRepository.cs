using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using YT_Community.DBContext;
using YT_Community.Models;

namespace YT_Community.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly YoutubeCommunityContext _context;

        public UserRepository(YoutubeCommunityContext context)
        {
            _context = context;
        }

        public User CreateUser(User user)
        {
            user.UserId = Guid.NewGuid();
            _context.Users.Add(user);
            _context.SaveChanges();
            return user;
        }

        public User DeleteUser(User user)
        {
            _context.Users.Remove(user);
            _context.SaveChanges();
            return user;
        }

        public async Task<List<User>> GetAll()
        {
            var users = await _context.Users.ToListAsync();
            if (users != null && users.Count > 0) {
                return users;
            }
            return [new()];
        }

        public async Task<User> GetById(Guid? guid)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.UserId == guid);
            if (user != null)
            {
                return user;
            }
            return new User();
        }

        public User UpdateUser(User user)
        {
            _context.Users.Update(user);
            _context.SaveChanges();
            return user;
        }
    }
}

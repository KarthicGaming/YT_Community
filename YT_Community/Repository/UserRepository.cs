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

        public User DeleteUser(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<User>> GetAll()
        {
            var users = await _context.Users.ToListAsync();
            if (users != null && users.Count > 0) {
                return users;
            }
            return new List<User> { new() };
        }

        public User GetByEmail(string email)
        {
            throw new NotImplementedException();
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

        public User GetByUserName(string userName)
        {
            throw new NotImplementedException();
        }

        public User UpdateUser(User user)
        {
            _context.Users.Update(user);
            _context.SaveChanges();
            return user;
        }
    }


}

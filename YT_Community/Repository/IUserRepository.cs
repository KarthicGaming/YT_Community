﻿using YT_Community.Models;

namespace YT_Community.Repository
{
    public interface IUserRepository
    {
        public Task<List<User>> GetAll();
        public Task<User> GetById(Guid? id);
        public User CreateUser(User user);
        public User UpdateUser (User user);
        public User DeleteUser (User user);
    }
}

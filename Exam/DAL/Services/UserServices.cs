using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

namespace DAL.Services
{
    public class UserServices : IUserRepositoryDal
    {
       
        EntityDatabase _database;

        public UserServices(EntityDatabase database)
        {
            _database = database;

        }
        public async Task<bool> Create(User entity)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Delete(User entity)
        {
            throw new NotImplementedException();
        }

        public async Task<User> GetByEmail(string email)
        {
            using (EntityDatabase database = _database)
            {
                return await database.Users.FirstOrDefaultAsync(user => user.Email == email);
            }
        }

        public async Task<User> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<User> GetByName(string name)
        {
            using (EntityDatabase database = _database)
            {
                return await database.Users.FirstOrDefaultAsync(user => user.Name == name);
            }
        }

        public async Task<List<User>> Select()
        {
            using (EntityDatabase database = _database)
            {
                var users = await database.Users.ToListAsync();
                return users;
            }
        }

        public async Task<User> Update(User entity)
        {
            throw new NotImplementedException();
        }
    }
}

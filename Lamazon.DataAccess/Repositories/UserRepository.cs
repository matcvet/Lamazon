using Lamazon.DataAccess.Abstraction;
using Lamazon.DomainModels.Entities;
using Microsoft.EntityFrameworkCore;

namespace Lamazon.DataAccess.Repositories
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        public UserRepository(LamazonDbContext dbContext) : base(dbContext) { }

        public void Add(User entity)
        {
            _dbContext.Users.Add(entity);
            _dbContext.SaveChanges();
        }

        public void DeleteById(int id)
        {
            var user = _dbContext.Users.FirstOrDefault(x => x.Id == id);

            if(user == null)
            {
                throw new Exception($"User with id {id} does not exist");
            }

            _dbContext.Users.Remove(user);
            _dbContext.SaveChanges();
        }

        public IEnumerable<User> GetAll()
        {
            return _dbContext.Users.Include(x => x.Role);
        }

        public User GetByEmail(string email)
        {
            return _dbContext.Users.Include(x => x.Role).FirstOrDefault(x => x.Email == email);
        }

        public User GetById(int id)
        {
            return _dbContext.Users.Include(x => x.Role).FirstOrDefault(x => x.Id == id);
        }

        public void Update(User entity)
        {
            if (!_dbContext.Users.Any(x => x.Id == entity.Id))
            {
                throw new Exception($"User with id {entity.Id} was not found.");
            }

            _dbContext.Users.Update(entity);
            _dbContext.SaveChanges();
        }
    }
}

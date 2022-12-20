using Lamazon.DomainModels.Entities;

namespace Lamazon.DataAccess.Abstraction
{
    public interface IUserRepository
    {
        public User GetById(int id);
        public User GetByEmail(string email);
        public IEnumerable<User> GetAll();
        public void Add(User entity);
        public void Update(User entity);
        public void DeleteById(int id);
    }
}

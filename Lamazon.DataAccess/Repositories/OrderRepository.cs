using Lamazon.DataAccess.Abstraction;
using Lamazon.DomainModels.Entities;

namespace Lamazon.DataAccess.Repositories
{
    public class OrderRepository : BaseRepository, IRepository<Order>
    {
        public OrderRepository(LamazonDbContext dbContext) : base(dbContext) {}

        public void Add(Order entity)
        {
            _dbContext.Orders.Add(entity);
            _dbContext.SaveChanges();
        }

        public void DeleteById(int id)
        {
            var order = _dbContext.Orders.FirstOrDefault(o => o.Id == id);

            if(order == null)
            {
                throw new Exception($"Order with id {id} does not exist.");
            }

            _dbContext.Orders.Remove(order);
            _dbContext.SaveChanges();
        }

        public IEnumerable<Order> GetAll()
        {
            return _dbContext.Orders;
        }

        public Order GetById(int id)
        {
            return _dbContext.Orders.FirstOrDefault(x => x.Id == id);
        }

        public void Update(Order entity)
        {
            var order = _dbContext.Orders.FirstOrDefault(x => x.Id == entity.Id);

            if (order == null)
            {
                throw new Exception($"Order with id {entity.Id} does not exist");
            }

            _dbContext.Orders.Update(order);
            _dbContext.SaveChanges();
        }
    }
}

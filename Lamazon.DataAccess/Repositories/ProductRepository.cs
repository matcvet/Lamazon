using Lamazon.DataAccess.Abstraction;
using Lamazon.DomainModels.Entities;
using Microsoft.EntityFrameworkCore;

namespace Lamazon.DataAccess.Repositories
{
    public class ProductRepository : BaseRepository, IRepository<Product>
    {
        public ProductRepository(LamazonDbContext dbContext) : base(dbContext) { }

        public void Add(Product entity)
        {
            _dbContext.Products.Add(entity);
            _dbContext.SaveChanges();
        }

        public void DeleteById(int id)
        {
            var product = _dbContext.Products.FirstOrDefault(x => x.Id == id);

            if (product == null)
            {
                throw new Exception($"Product with id of {id} does not exist");
            }

            _dbContext.Products.Remove(product);
            _dbContext.SaveChanges();
        }

        public IEnumerable<Product> GetAll()
        {
            return _dbContext.Products;
        }

        public Product GetById(int id)
        {
            return _dbContext.Products.FirstOrDefault(x => x.Id == id);
        }

        public void Update(Product entity)
        {
            var product = _dbContext.Products.FirstOrDefault(x => x.Id == entity.Id);

            if (product == null)
            {
                throw new Exception($"Product with id of {entity.Id} does not exist");
            }

            _dbContext.Products.Update(product);
            _dbContext.SaveChanges();
        }
    }
}

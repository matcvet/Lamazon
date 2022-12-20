using Lamazon.DataAccess.Abstraction;
using Lamazon.DomainModels.Entities;

namespace Lamazon.DataAccess.Repositories
{
    public class ProductCategoryRepository : BaseRepository, IRepository<ProductCategory>
    {
        public ProductCategoryRepository(LamazonDbContext dbContext) : base(dbContext) {}

        public void Add(ProductCategory entity)
        {
            _dbContext.ProductCategories.Add(entity);
            _dbContext.SaveChanges();
        }

        public void DeleteById(int id)
        {
            var productCategory = _dbContext.ProductCategories.FirstOrDefault(x => x.Id == id);

            if (productCategory == null)
            {
                throw new Exception($"ProductCategory with id {id} was not found");
            }

            _dbContext.ProductCategories.Remove(productCategory);
            _dbContext.SaveChanges();

        }

        public IEnumerable<ProductCategory> GetAll()
        {
            return _dbContext.ProductCategories;
        }

        public ProductCategory GetById(int id)
        {
            return _dbContext.ProductCategories.FirstOrDefault(x => x.Id == id);
        }

        public void Update(ProductCategory entity)
        {
            var productCategory = _dbContext.ProductCategories.FirstOrDefault(x => x.Id == entity.Id);

            if (productCategory == null)
            {
                throw new Exception($"ProductCategory with id {entity.Id} was not found");
            }

            _dbContext.ProductCategories.Update(productCategory);
            _dbContext.SaveChanges();
        }
    }
}

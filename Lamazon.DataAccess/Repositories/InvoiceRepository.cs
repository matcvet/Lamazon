using Lamazon.DataAccess.Abstraction;
using Lamazon.DomainModels.Entities;

namespace Lamazon.DataAccess.Repositories
{
    public class InvoiceRepository : BaseRepository, IRepository<Invoice>
    {
        public InvoiceRepository(LamazonDbContext dbContext) : base(dbContext) {}

        public void Add(Invoice entity)
        {
            _dbContext.Invoices.Add(entity);
            _dbContext.SaveChanges();
        }

        public void DeleteById(int id)
        {
            var invoice = _dbContext.Invoices.FirstOrDefault(x => x.Id == id);

            if (invoice == null)
            {
                throw new Exception($"Invoice with id {id} was not found");
            }

            _dbContext.Invoices.Remove(invoice);
            _dbContext.SaveChanges();
        }

        public IEnumerable<Invoice> GetAll()
        {
            return _dbContext.Invoices;
        }

        public Invoice GetById(int id)
        {
            return _dbContext.Invoices.FirstOrDefault(x => x.Id == id);
        }

        public void Update(Invoice entity)
        {
            var invoice = _dbContext.Invoices.FirstOrDefault(x => x.Id == entity.Id);

            if (invoice == null)
            {
                throw new Exception($"Invoice with id {entity.Id} was not found.");
            }

            _dbContext.Invoices.Update(invoice);
            _dbContext.SaveChanges();

        }
    }
}

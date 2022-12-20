namespace Lamazon.DataAccess.Abstraction
{
    public interface IRepository<T>
    {
        public T GetById(int id);
        public IEnumerable<T> GetAll();
        public void Add(T entity);
        public void Update(T entity);
        public void DeleteById(int id);
    }
}

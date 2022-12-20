namespace Lamazon.DataAccess
{
    public class BaseRepository
    {
        protected readonly LamazonDbContext _dbContext;

        public BaseRepository(LamazonDbContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}

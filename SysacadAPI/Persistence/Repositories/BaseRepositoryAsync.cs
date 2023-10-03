using Application.Interfaces;
using Ardalis.Specification.EntityFrameworkCore;
using Persistence.Contexts;

namespace Persistence.Repositories
{
    public class BaseRepositoryAsync<T> : RepositoryBase<T>, IRepositoryAsync<T> where T : class
    {
        private readonly ApplicationDbContext _dbContext;

        public BaseRepositoryAsync(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}

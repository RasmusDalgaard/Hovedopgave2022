using EMSuiteVisualConfigurator.Application.Interfaces.Repositories;
using EMSuiteVisualConfigurator.CoreBusiness.Primitives;
using EMSuiteVisualConfigurator.Data.DataAccess;
using Microsoft.EntityFrameworkCore;


namespace EMSuiteVisualConfigurator.Data.Repositories
{
    public class Repository<T> : IRepository<T> where T : Entity
    {
        protected readonly EMSuiteVisualConfiguratorDbContext _dbContext;
        private DbSet<T> table = null;

        public Repository(EMSuiteVisualConfiguratorDbContext dbContext)
        {
            _dbContext = dbContext;
            table = dbContext.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await table.ToListAsync();
        }

        public async Task CreateAsync(T entity)
        {
            await table.AddAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            T existing = await table.FindAsync(id);
            table.Remove(existing);
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await table.FindAsync(id);
        }

    }
}
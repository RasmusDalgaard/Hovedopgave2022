using EMSuiteVisualConfigurator.Application.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMSuiteVisualConfigurator.Data.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        public async Task<IEnumerable<T>> AllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<T> CreateAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public async Task<string> DeleteAsync(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<T> GetByIdAsync(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<T> UpdateAsync(T entity)
        {
            throw new NotImplementedException();
        }
    }
}

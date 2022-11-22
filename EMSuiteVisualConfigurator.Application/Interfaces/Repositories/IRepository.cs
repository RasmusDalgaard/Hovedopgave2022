using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMSuiteVisualConfigurator.Application.Interfaces.Repositories
{
    public interface IRepository<T> where T : class
    {
        public Task<IEnumerable<T>> AllAsync();
        public Task<T> GetByIdAsync(string id);
        public Task<T> CreateAsync(T entity);
        public Task<T> UpdateAsync(T entity);
        public Task<string> DeleteAsync(string id);
        
    }
}

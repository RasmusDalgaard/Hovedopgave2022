using EMSuiteVisualConfigurator.Application.DTOs;
using EMSuiteVisualConfigurator.Application.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMSuiteVisualConfigurator.Data.Repositories
{
    public class AccessPointRepository : Repository<AccessPoint>, IAccessPointRepository
    {
        public AccessPointRepository()
        {

        }
        public async Task<IEnumerable<AccessPoint>> GetAllAccessPoints()
        {
            throw new NotImplementedException();
        }
    }
}

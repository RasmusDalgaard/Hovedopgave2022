using EMSuiteVisualConfigurator.Application.Interfaces.Repositories;
using EMSuiteVisualConfigurator.CoreBusiness.Entities;
using EMSuiteVisualConfigurator.Data.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace EMSuiteVisualConfigurator.Data.Repositories
{
    public class AccessPointRepository : Repository<AccessPoint>, IAccessPointRepository
    {
        public AccessPointRepository(EMSuiteVisualConfiguratorDbContext dbContext) : base(dbContext)
        {
        }

        public Task<AccessPoint> CreateAccessPoint(AccessPoint accessPoint)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAccessPoint(int id)
        {
            throw new NotImplementedException();
        }

        public Task<AccessPoint> GetAccessPointById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<AccessPoint>> GetAllAccessPoints()
        {
            throw new NotImplementedException();
        }
    }
}

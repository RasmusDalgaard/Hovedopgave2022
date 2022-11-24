
using EMSuiteVisualConfigurator.Application.Interfaces.Repositories;
using EMSuiteVisualConfigurator.CoreBusiness.Entities;
using EMSuiteVisualConfigurator.Data.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMSuiteVisualConfigurator.Data.Repositories
{
    public class AccessPointRepository : Repository<AccessPoint>, IAccessPointRepository
    {
        public AccessPointRepository(EMSuiteVisualConfiguratorDbContext dbContext) : base(dbContext)
        {
        }       

        public async Task<IEnumerable<AccessPoint>> GetAllAccessPoints()
        {
            return await _dbContext.accessPoints.ToListAsync();
        }

        public async Task<AccessPoint> GetAccessPointById(int id)
        {
            return await _dbContext.accessPoints.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<AccessPoint> CreateAccessPoint(AccessPoint accessPoint)
        {
            _dbContext.Add(accessPoint);
            await _dbContext.SaveChangesAsync();
            return accessPoint;
        }

        public async Task DeleteAccessPoint(int id)
        {            
            var accessPoint = await _dbContext.accessPoints
                .FirstOrDefaultAsync(a => a.Id == id);
            if (accessPoint == null) return;

            _dbContext.accessPoints.Remove(accessPoint);
            await _dbContext.SaveChangesAsync();
            //Retrieve Sensors and delete
        }     
    }
}

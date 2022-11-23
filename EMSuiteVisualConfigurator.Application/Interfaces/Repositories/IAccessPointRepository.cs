using EMSuiteVisualConfigurator.CoreBusiness.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMSuiteVisualConfigurator.Application.Interfaces.Repositories
{
    public interface IAccessPointRepository : IRepository<AccessPoint>
    {
        Task<IEnumerable<AccessPoint>> GetAllAccessPoints();

        Task<AccessPoint> GetAccessPointById(int id);

        Task<AccessPoint> CreateAccessPoint(AccessPoint accessPoint);

        Task DeleteAccessPoint(int id);

    }
}

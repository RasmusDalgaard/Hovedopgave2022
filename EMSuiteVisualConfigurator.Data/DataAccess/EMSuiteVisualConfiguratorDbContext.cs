using EMSuiteVisualConfigurator.CoreBusiness.Entities;
using EMSuiteVisualConfigurator.CoreBusiness.Primitives;
using Microsoft.EntityFrameworkCore;


namespace EMSuiteVisualConfigurator.Data.DataAccess
{
    public class EMSuiteVisualConfiguratorDbContext : DbContext
    {

        public EMSuiteVisualConfiguratorDbContext(DbContextOptions opt) : base(opt)
        {
        }

    }
}

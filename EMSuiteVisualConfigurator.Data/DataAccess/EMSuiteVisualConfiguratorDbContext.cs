using EMSuiteVisualConfigurator.CoreBusiness.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMSuiteVisualConfigurator.Data.DataAccess
{
    public class EMSuiteVisualConfiguratorDbContext : DbContext
    {
        public EMSuiteVisualConfiguratorDbContext(DbContextOptions opt) : base(opt)
        {

        }

        public DbSet<Zone> zones { get; set; }
        public DbSet<AccessPoint> accessPoints { get; set; }
        public DbSet<Sensor> sensors { get; set; }
    }
}

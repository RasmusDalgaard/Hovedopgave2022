﻿using EMSuiteVisualConfigurator.CoreBusiness.Entities;
using EMSuiteVisualConfigurator.CoreBusiness.Primitives;
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
        public DbSet<AccessPoint> accessPoints { get; set; }
        public EMSuiteVisualConfiguratorDbContext(DbContextOptions opt) : base(opt)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Entity>().HasKey(e => e.Id);
            modelBuilder.Entity<Entity>().UseTpcMappingStrategy();
            modelBuilder.Entity<AccessPoint>().HasBaseType<Entity>();            
        }
    }
}

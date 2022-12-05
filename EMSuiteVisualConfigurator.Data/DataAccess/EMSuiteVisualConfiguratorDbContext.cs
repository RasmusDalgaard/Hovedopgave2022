using EMSuiteVisualConfigurator.CoreBusiness.Entities;
using EMSuiteVisualConfigurator.CoreBusiness.Primitives;
using Microsoft.EntityFrameworkCore;


namespace EMSuiteVisualConfigurator.Data.DataAccess
{
    public class EMSuiteVisualConfiguratorDbContext : DbContext
    {
        public DbSet<EMSuiteConfiguration> emsuiteConfigurations { get; set; }
        public DbSet<Site> sites { get; set; }

        public DbSet<Zone> zones { get; set; }
        public DbSet<AccessPoint> accessPoints { get; set; }
        public DbSet<Logger> loggers { get; set; }
        public DbSet<Port> ports { get; set; }
        public DbSet<Channel> channels { get; set; }

        public EMSuiteVisualConfiguratorDbContext(DbContextOptions opt) : base(opt)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Entity>().HasKey(e => e.Id);
            modelBuilder.Entity<Entity>().UseTpcMappingStrategy();
            //modelBuilder.Entity<EMSuiteConfiguration>().HasBaseType<Entity>();        
            //modelBuilder.Entity<Site>().HasBaseType<Entity>();        
            //modelBuilder.Entity<Zone>().HasBaseType<Entity>();        
            modelBuilder.Entity<AccessPoint>()
                .HasBaseType<Entity>()
                .HasMany(a => a.Loggers);

            modelBuilder.Entity<Logger>()
                .HasBaseType<Entity>()
                .HasMany(l => l.Ports);

            modelBuilder.Entity<Port>()
                .HasBaseType<Entity>()
                .HasMany(p => p.Channels);

            modelBuilder.Entity<Channel>().HasBaseType<Entity>();      
        }
    }
}

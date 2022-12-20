using EMSuiteVisualConfigurator.Application.DTOs;
using EMSuiteVisualConfigurator.Application.Features.EMSuiteConfigurations.Commands;
using EMSuiteVisualConfigurator.Application.Interfaces.Repositories;
using EMSuiteVisualConfigurator.CoreBusiness.Entities;
using EMSuiteVisualConfigurator.Data.DataAccess;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMSuiteVisualConfigurator.Data.Repositories
{
    public class ConfigurationRepository : IConfigurationRepository
    {
        private readonly EMSuiteVisualConfiguratorDbContext _dbContext;

        public ConfigurationRepository(EMSuiteVisualConfiguratorDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task InsertEquipment(CreateEMSuiteConfigurationCommand command)
        {
            List<AccessPointDTO> accessPoints = command.AccessPointDTOs;
            string SPJSON = "[";

            foreach (AccessPointDTO ap in accessPoints)
            {
                SPJSON += "{\"au\":true,\"ls\":[";

                foreach (LoggerDTO logger in ap.Loggers)
                {
                    SPJSON += "{";
                    SPJSON += "\"ps\":[";
                    foreach (PortDTO port in logger.Ports)
                    {
                        SPJSON += "{";
                        SPJSON += "\"cs\":[";

                        SPJSON += "{\"au\": " + port.Channels[0].IsAuthorized.ToString().ToLower() + ",";
                        SPJSON += "\"n\": 0,";
                        SPJSON += "\"t\": " + port.Channels[0].Temperature + "}";


                        SPJSON += "],";
                        SPJSON += "\"pn\": 0,";
                        SPJSON += "\"ssn\": " + port.SensorSerialNumber + ",";
                        var time = DateTime.SpecifyKind(port.CreateDate, DateTimeKind.Utc);
                        string y = "{0:O}";
                        string x = string.Format(y, port.CreateDate);
                        SPJSON += "\"cd\": \"" + x + "\"}";
                        if (port != logger.Ports.Last())
                        {
                            SPJSON += ",";
                        }
                        else
                        {
                            SPJSON += "]";
                        }
                    }

                    SPJSON += ", \"sn\":" + logger.Id;
                    SPJSON += ", \"bt\":" + logger.Battery;
                    SPJSON += ", \"ss\":" + logger.SignalStrength;
                    SPJSON += "}";
                    if (logger != ap.Loggers.Last())
                    {
                        SPJSON += ",";
                    }
                }

                SPJSON += "],\"sn\": " + ap.Id + "}";
                if (ap != accessPoints.Last())
                {
                    SPJSON += ",";
                }
            }
            SPJSON += "]";
            
            using (var cmd = _dbContext.Database.GetDbConnection().CreateCommand())
            {
                cmd.CommandText = "SP_InsertEquipment";
                cmd.CommandType = CommandType.StoredProcedure;
                _dbContext.Database.OpenConnection();
                // Create output parameter. "-1" is used for nvarchar(max)
                cmd.Parameters.Add(new SqlParameter("@jsondata", SPJSON));

                // Execute the command
                cmd.ExecuteNonQuery();
                _dbContext.Database.CloseConnection();
            }
        }

        public async Task CreateSites(CreateEMSuiteConfigurationCommand command)
        {

            foreach(SiteDTO site in command.ConfigurationDTO.Sites)
            {
                string sql = $"INSERT INTO Site (Name, Address, PostCode, TimeZoneID, ScreenTop, ScreenLeft, ID) VALUES ('{site.Name}', '{site.Address}', '{site.PostCode}', '{site.TimeZoneId}' ,0 ,0, {site.Id})";
                await _dbContext.Database.ExecuteSqlRawAsync(sql);

                //await _dbContext.Database.ExecuteSqlRawAsync($"INSERT INTO Site (Name, Address, PostCode, TimeZoneID, ScreenTop, ScreenLeft) VALUES ('{0}', '{1}', '{2}', '{3}' ,0 ,0)", site.Name, site.Address, site.PostCode, site.TimeZoneId);
                /*using (var cmd = _dbContext.Database.GetDbConnection().CreateCommand())
                {
                    cmd.CommandText = CommandType.Text;
                    _dbContext.Database.OpenConnection();
                    // Create output parameter. "-1" is used for nvarchar(max)
                    cmd.Parameters.Add(new SqlParameter("@Name", site.Name));
                    cmd.Parameters.Add(new SqlParameter("@Address", site.Address));
                    cmd.Parameters.Add(new SqlParameter("@PostCode", site.PostCode));
                    cmd.Parameters.Add(new SqlParameter("@TimeZoneID", site.TimeZoneId));
                    cmd.Parameters.Add(new SqlParameter("@ScreenTop", 0));
                    cmd.Parameters.Add(new SqlParameter("@ScreenLeft", 0));
                    // Execute the command
                    cmd.ExecuteNonQuery();
                    _dbContext.Database.CloseConnection();
                }*/
                    
                //await _dbContext.Database.ExecuteSqlInterpolatedAsync($"INSERT INTO Site (Name, Address, PostCode, TimeZoneID, ScreenTop, ScreenLeft) VALUES ('{site.Name}', '{site.Address}', '{site.PostCode}', '{site.TimeZoneId}' ,0 ,0)");
                //site.Id = _dbContext.Database.SqlQuery<int>($"select [ID] from [emsuite].[dbo].[Site] where Name = '{site.Name}'").AsEnumerable().ElementAt(0);
                //Console.WriteLine(site.Id);
                //Debug.WriteLine(site.Id);
                //Debug.WriteLine(_dbContext.Database.SqlQuery<int>($"select [ID] from [emsuite].[dbo].[Site] where Name = '{site.Name}'").AsEnumerable().ElementAt(0));
            }
        }

        public async Task CreateAndAddZones(CreateEMSuiteConfigurationCommand command)
        {
            foreach (SiteDTO site in command.ConfigurationDTO.Sites)
            {
                foreach (ZoneDTO zone in site.Zones)
                {
                    string sql = $"INSERT INTO Zone (Name, SiteID, ID) VALUES ({zone.Name}, {site.Id})";
                    await _dbContext.Database.ExecuteSqlRawAsync(sql);
                    FormattableString sql1 = $"select [ID] from [emsuite].[dbo].[Zone] where Name = '{zone.Name}'";
                    zone.Id = _dbContext.Database.SqlQuery<int>(sql1).ElementAt(0);
                }
            }
        }

        public async Task AddUserToSite(CreateEMSuiteConfigurationCommand command)
        {
            string userId = _dbContext.Database.SqlQuery<string>($"select [ID] from [emsuite].[dbo].[AspNetUsers] where UserName = 'SystemAdmin'").ElementAt(0);
            string sql;
            foreach (SiteDTO site in command.ConfigurationDTO.Sites)
            {
                sql = $"INSERT INTO[emsuite].[dbo].[UserSiteAllocation](UserId, SiteID) values('{userId}', {site.Id});";
                await _dbContext.Database.ExecuteSqlRawAsync(sql);
             }
           


        }


    }
}

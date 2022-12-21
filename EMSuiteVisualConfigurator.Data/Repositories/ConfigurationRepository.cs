using EMSuiteVisualConfigurator.Application.DTOs;
using EMSuiteVisualConfigurator.Application.Features.EMSuiteConfigurations.Commands;
using EMSuiteVisualConfigurator.Application.Interfaces.Repositories;
using EMSuiteVisualConfigurator.CoreBusiness.Entities;
using EMSuiteVisualConfigurator.Data.DataAccess;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
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
            //string connString = "Server=localhost;Database=emsuite;Trusted_Connection=True;MultipleActiveResultSets=true;Trust Server Certificate=true";
            string connString = _dbContext.Database.GetConnectionString();
            SqlConnection cnn = new SqlConnection(connString);
            cnn.Open();

            foreach(SiteDTO site in command.ConfigurationDTO.Sites)
            {
                string sql = $"INSERT INTO Site (Name, Address, PostCode, TimeZoneID, ScreenTop, ScreenLeft) VALUES ('{site.Name}', '{site.Address}', '{site.PostCode}', '{site.TimeZoneId}' ,0 ,0)";
                
                SqlCommand cmd = new SqlCommand(sql, cnn);
                await cmd.ExecuteNonQueryAsync();

                sql = $"select [ID] from [emsuite].[dbo].[Site] where Name = '{site.Name}'";
                cmd = new SqlCommand(sql, cnn);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    site.Id = (int) reader.GetValue(0);
                }

            }
            cnn.Close();
        }

        public async Task CreateAndAddZones(CreateEMSuiteConfigurationCommand command)
        {
            string connString = "Server=localhost;Database=emsuite;Trusted_Connection=True;MultipleActiveResultSets=true;Trust Server Certificate=true";
            SqlConnection cnn = new SqlConnection(connString);
            cnn.Open();


            foreach (SiteDTO site in command.ConfigurationDTO.Sites)
            {
                foreach (ZoneDTO zone in site.Zones)
                {
                    string sql = $"INSERT INTO Zone (Name, SiteID) VALUES ('{zone.Name}', {site.Id})";
                    SqlCommand cmd = new SqlCommand(sql, cnn);
                    await cmd.ExecuteNonQueryAsync();


                    sql = $"select [ID] from [emsuite].[dbo].[Zone] where Name = '{zone.Name}'";
                    cmd = new SqlCommand(sql, cnn);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        zone.Id = (int)reader.GetValue(0);
                    }
                }
            }
            cnn.Close();
        }

        public async Task AddUserToSite(CreateEMSuiteConfigurationCommand command)
        {
            string connString = "Server=localhost;Database=emsuite;Trusted_Connection=True;MultipleActiveResultSets=true;Trust Server Certificate=true";
            SqlConnection cnn = new SqlConnection(connString);
            cnn.Open();

            string sql = $"select [ID] from [emsuite].[dbo].[AspNetUsers] where UserName = 'SystemAdmin'";
            SqlCommand cmd = new SqlCommand(sql, cnn);

            string userId = "";
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                userId = (string)reader.GetValue(0);
            }

            foreach (SiteDTO site in command.ConfigurationDTO.Sites)
            {
                sql = $"INSERT INTO[emsuite].[dbo].[UserSiteAllocation](UserId, SiteID) values('{userId}', {site.Id});";
                cmd = new SqlCommand(sql, cnn);
                await cmd.ExecuteNonQueryAsync();
             }
           cnn.Close();


        }

        public async Task AddUserToZone(CreateEMSuiteConfigurationCommand command)
        {
            string connString = "Server=localhost;Database=emsuite;Trusted_Connection=True;MultipleActiveResultSets=true;Trust Server Certificate=true";
            SqlConnection cnn = new SqlConnection(connString);
            cnn.Open();

            string sql = $"select [ID] from [emsuite].[dbo].[AspNetUsers] where UserName = 'SystemAdmin'";
            SqlCommand cmd = new SqlCommand(sql, cnn);

            string userId = "";
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                userId = (string)reader.GetValue(0);
            }

            foreach (SiteDTO site in command.ConfigurationDTO.Sites)
            {
                foreach (ZoneDTO zone in site.Zones)
                {
                    sql = $"insert into[emsuite].[dbo].[UserZoneAllocation](UserId, ZoneID) values('{userId}', {zone.Id})";
                    cmd = new SqlCommand(sql, cnn);
                    await cmd.ExecuteNonQueryAsync();
                }
                
            }
            cnn.Close();
        }

        public async Task AllocateLoggerZone(CreateEMSuiteConfigurationCommand command)
        {
            string connString = "Server=localhost;Database=emsuite;Trusted_Connection=True;MultipleActiveResultSets=true;Trust Server Certificate=true";
            SqlConnection cnn = new SqlConnection(connString);
            cnn.Open();
            int chnNr = 1;
            foreach (SiteDTO site in command.ConfigurationDTO.Sites)
            {
                foreach (ZoneDTO zone in site.Zones)
                {
                    foreach (ChannelDTO channel in zone.Channels)
                    {
                        string sql = $"insert into [emsuite].[dbo].[ZoneLoggerChannelAllocation] (LoggerChannelID, ZoneID) values ((select [ID] from [emsuite].[dbo].[LoggerChannel] where DefaultName = '{chnNr} - 1'), {zone.Id})";
                        SqlCommand cmd = new SqlCommand(sql, cnn);
                        await cmd.ExecuteNonQueryAsync();
                        chnNr++;
                    }
                }
            }
            cnn.Close();
        }
    }
}

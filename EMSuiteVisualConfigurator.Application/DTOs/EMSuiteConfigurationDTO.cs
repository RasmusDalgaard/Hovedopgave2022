using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMSuiteVisualConfigurator.Application.DTOs
{
    public class EMSuiteConfigurationDTO : ConfigurationItem
    {
        public string ConfigurationName { get; set; } = $"EMSuiteConfiguration{IdCount}";
        public List<SiteDTO> Sites { get; set; } = new List<SiteDTO>();
        public static int IdCount { get; set; } = 0;


        public EMSuiteConfigurationDTO()
        {
            IdCount++;
            Id = IdCount;
            Sites.Add(new SiteDTO());
        }
    }
}

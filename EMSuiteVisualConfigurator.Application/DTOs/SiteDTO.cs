using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMSuiteVisualConfigurator.Application.DTOs
{
    public class SiteDTO : ConfigurationItem
    {
        public string Display = "inline";
        public string Name { get; set; } = $"ConfigurationName{IdCount}";
        public string Address { get; set; } = $"ConfigurationAddress{IdCount}";
        public string PostCode { get; set; } = $"PC{IdCount}";
        public string TimeZoneId { get; set; } = $"UTC";
        public List<ZoneDTO> Zones { get; set; } = new List<ZoneDTO>();
        public static int IdCount { get; set; } = 0;


        public SiteDTO()
        {
            IdCount++;
            Id = IdCount;            
        }

        public SiteDTO(string display)
        {
            IdCount++;
            Id = IdCount;
            Display = display;
        }
    }
}

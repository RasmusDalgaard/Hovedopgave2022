using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMSuiteVisualConfigurator.Application.DTOs
{
    public class ZoneDTO : ConfigurationItem
    {
        public string Name { get; set; } = $"Zone{IdCount}";
        public List<ChannelDTO> Channels { get; set; }
        public static int IdCount { get; set; } = 0;


        public ZoneDTO()
        {
            IdCount++;
            Id = IdCount;
        }
    }
}

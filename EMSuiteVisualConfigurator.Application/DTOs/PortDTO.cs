using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMSuiteVisualConfigurator.Application.DTOs
{
    public class PortDTO : ConfigurationItem
    {
        public List<ChannelDTO> Channels { get; set; } = new List<ChannelDTO>();
        public int SensorSerialNumber { get; set; } = IdCount;
        public DateTime CreateDate { get; set; } = DateTime.Now;
        public static int IdCount { get; set; } = 0;


        public PortDTO()
        {
            IdCount++;
            Id = IdCount;            
        }
    }
}

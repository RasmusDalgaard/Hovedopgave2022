using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMSuiteVisualConfigurator.Application.DTOs
{
    public class LoggerDTO : ConfigurationItem
    {
        public List<PortDTO> Ports { get; set; } = new List<PortDTO>();
        public int Battery { get; set; } = 0;
        public int SignalStrength { get; set; } = 0;
        public static int IdCount { get; set; } = 0;


        public LoggerDTO()
        {
            IdCount++;
            Id = IdCount;
            Ports.Add(new PortDTO());
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMSuiteVisualConfigurator.Application.DTOs
{
    public class ChannelDTO : ConfigurationItem
    {
        public bool IsAuthorized { get; set; } = true;
        public int Temperature { get; set; } = 1;
        public static int IdCount { get; set; } = 0;


        public ChannelDTO()
        {
            IdCount++;
            Id = IdCount;
        }
    }
}

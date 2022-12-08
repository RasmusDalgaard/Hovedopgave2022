using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMSuiteVisualConfigurator.Application.DTOs
{
    public class AccessPointDTO : ConfigurationItem
    {
        public List<LoggerDTO> Loggers { get; set; } = new List<LoggerDTO>();
        public bool IsAuthorized { get; set; } = true;
        public static int IdCount {get; set;} = 0;

        public AccessPointDTO()
        {
            IdCount++;
            Id = IdCount;
        }
    }
}

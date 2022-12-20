using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMSuiteVisualConfigurator.Application.DTOs
{
    public abstract class ConfigurationItem
    {
        public int Id { get; set; }
        protected ConfigurationItem()
        {
        }
    }
}

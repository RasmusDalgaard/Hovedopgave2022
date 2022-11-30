using EMSuiteVisualConfigurator.CoreBusiness.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMSuiteVisualConfigurator.CoreBusiness.Entities
{
    public class EMSuiteConfiguration : Entity
    {
        public List<Site> Sites { get; protected set; }

        public EMSuiteConfiguration()
        {
            Sites = new List<Site>();
        }
    }
}

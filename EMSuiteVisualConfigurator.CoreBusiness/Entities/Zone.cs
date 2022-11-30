using EMSuiteVisualConfigurator.CoreBusiness.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMSuiteVisualConfigurator.CoreBusiness.Entities
{
    public class Zone : Entity
    {
        public List<AccessPoint> AccessPoints { get; protected set; }

        public Zone()
        {
            AccessPoints = new List<AccessPoint>();
        }
    }
}

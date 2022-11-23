using EMSuiteVisualConfigurator.CoreBusiness.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMSuiteVisualConfigurator.CoreBusiness.Entities
{
    public class AccessPoint : Entity
    {
        public string Name { get; protected set; }

        public AccessPoint(int id, string name)
        {
            Name = name;
        }

        private AccessPoint()
        {

        }

    }
}

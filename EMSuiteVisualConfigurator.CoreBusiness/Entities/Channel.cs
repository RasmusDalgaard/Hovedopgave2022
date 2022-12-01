using EMSuiteVisualConfigurator.CoreBusiness.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMSuiteVisualConfigurator.CoreBusiness.Entities
{
    public class Channel : Entity
    {
        public bool IsAuthorized { get; protected set; }

        public int Temperature { get; protected set; }

        public Channel()
        {

        }
    }
}

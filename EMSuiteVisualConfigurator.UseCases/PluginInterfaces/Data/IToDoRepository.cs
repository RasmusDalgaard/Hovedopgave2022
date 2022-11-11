using EMSuiteVisualConfigurator.CoreBusiness.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMSuiteVisualConfigurator.UseCases.PluginInterfaces
{
    public interface IToDoRepository
    {
        public ToDo GetToDo();
    }
}
